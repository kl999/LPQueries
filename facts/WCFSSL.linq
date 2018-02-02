<Query Kind="Program">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var rez = ServiceSoapClient(binding, remoteAddress);

    var chf = rez.ChannelFactory;
    chf.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
    if (chf.Credentials.ServiceCertificate.SslCertificateAuthentication == null)
    {
        chf.Credentials.ServiceCertificate.SslCertificateAuthentication = new System.ServiceModel.Security.X509ServiceCertificateAuthentication();
    }
    chf.Credentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
    chf.Credentials.ServiceCertificate.SslCertificateAuthentication.CustomCertificateValidator = new cvalid();
}

class cvalid : System.IdentityModel.Selectors.X509CertificateValidator
{
    public override void Validate(X509Certificate2 certificate)
    {
        throw new NotImplementedException();
    }
}