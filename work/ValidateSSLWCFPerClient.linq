<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.IdentityModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IdentityModel.Selectors.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IdentityModel.Services.dll</Reference>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IdentityModel.Selectors</Namespace>
  <Namespace>System.IdentityModel.Tokens.X509NTAuthChainTrustValidator</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//From 4.5
// initialize the ssl certificate authentication
client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
{
   CertificateValidationMode = X509CertificateValidationMode.Custom,
   CustomCertificateValidator = new CustomValidator(serverCert)
};

// simple custom validator, only valid against a specific thumbprint
class CustomValidator : X509CertificateValidator
{
    private readonly X509Certificate2 knownCertificate;

    public CustomValidator(X509Certificate2 knownCertificate)
    {
        this.knownCertificate = knownCertificate;
    }

    public override void Validate(X509Certificate2 certificate)
    {
        if (this.knownCertificate.Thumbprint != certificate.Thumbprint)
        {
            throw new SecurityTokenValidationException("Unknown certificate");
        }
    }
}