using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace ews_test
{
    public partial class Form1 : Form, ITraceListener
    {
        private bool _running;
        private bool _allowHttpUrls;

        public Form1()
        {
            InitializeComponent();
            EnableButtons();

            ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
        }

        private async void buttonAutoDiscover_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
            _allowHttpUrls = checkBoxAllowHttp.Checked;

            _running = true;
            EnableButtons();

            await System.Threading.Tasks.Task.Run(() => AutoDiscover());

            _running = false;
            EnableButtons();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            buttonAutoDiscover.Enabled = _running == false && string.IsNullOrEmpty(textBoxEmail.Text) == false;
        }

        public void AutoDiscover()
        {
            string emailAddress = textBoxEmail.Text.Trim();

            ExchangeCredentials credential = null;
            if (string.IsNullOrEmpty(textBoxPassword.Text) == false)
            {
                string password = textBoxPassword.Text.Trim();
                credential = new NetworkCredential(emailAddress, password);
            }

            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010, TimeZoneInfo.Utc);

            if (credential != null)
            {
                service.Credentials = credential;
            }

            try
            {
                // Auto-discover works for both on-prem an cloud Office 365 accounts
                LogMessage(string.Format(CultureInfo.InvariantCulture,
                        "Attempting to auto-discover Exchange Server for account '{0}'...", emailAddress));

                // SCP lookup is slow
                service.EnableScpLookup = false;

                service.TraceFlags = TraceFlags.All;
                service.TraceEnabled = true;
                service.TraceEnablePrettyPrinting = true;
                service.TraceListener = this;

                // Attempt autodiscovery
                service.AutodiscoverUrl(emailAddress, RedirectionUrlValidationCallback);

                service.TraceEnabled = false;
            }
            catch (AutodiscoverLocalException ex)
            {
                LogMessage($"AutodiscoverLocalException: {ex.Message}");
            }
            catch (AutodiscoverRemoteException ex)
            {
                LogMessage($"AutodiscoverRemoteException: {ex.Message}");
            }
            catch (ServiceLocalException ex)
            {
                LogMessage($"ServiceLocalException: {ex.Message}");
            }

            if (service.Url == null)
            {
                LogMessage($"{Environment.NewLine}Unable to auto-discover URL");
            }
            else
            {
                LogMessage($"{Environment.NewLine}Discovered Exchange URL: {service.Url}");
            }
        }


        private void LogMessage(string message)
        {
            textBoxLog.Invoke(new Action(()=> textBoxLog.AppendText(message + Environment.NewLine)));
        }

        private bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            else if (redirectionUri.Scheme == "http" && _allowHttpUrls)
            {
                result = true;
            }

            string valid = result ? "Valid" : "Invalid";
            LogMessage($"RedirectionUrlValidationCallback - {valid} URL");

            return result;
        }

        public void Trace(string traceType, string traceMessage)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(traceMessage);

                XmlNodeList commandNodes = doc.GetElementsByTagName("Trace");
                foreach (XmlNode node in commandNodes)
                {
                    LogMessage($"EWS Autodiscover: {node.InnerText.Replace("\r", "").Replace("\n", "")}");
                }
            }
            catch (XmlException)
            {
                // Unfortunately, sometimes the trace XML is corrupted by improper encoding of an 
                // embedded SOAP message.
                LogMessage($"EWS Autodiscover: {traceType}");
            }
        }


        private bool CertificateValidationCallBack(
            object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                LogMessage("CertificateValidationCallBack: SSL Certificate valid");
                return true;
            }

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            LogMessage("CertificateValidationCallBack: SSL Certificate valid - self signed with untrusted root, treating as valid");
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                LogMessage($"CertificateValidationCallBack: SSL Certificate invalid - errors in certificate chain: {status.StatusInformation}");
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certificates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                LogMessage($"CertificateValidationCallBack: SSL Certificate invalid: {sslPolicyErrors}");
                return false;
            }
        }

    }
}
