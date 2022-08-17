using System;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace NykantMVC.Services
{
    public static class AwsCertService
    {
        private static ExportCertificateResponse Certificate { get; set; }
        public static async Task<ExportCertificateResponse> GetCertificateAsync()
        {
            if(Certificate == null)
            {
                try
                {
                    UnicodeEncoding uniEncoding = new UnicodeEncoding();
                    byte[] secret = uniEncoding.GetBytes(
            "MySecretShit");
                    var stream = new System.IO.MemoryStream();
                    stream.Write(secret);
                    var client = new AmazonCertificateManagerClient();
                    var res = await client.ExportCertificateAsync(new Amazon.CertificateManager.Model.ExportCertificateRequest { CertificateArn = "arn:aws:acm:eu-north-1:841058810333:certificate/98247236-87aa-4823-87ff-8dfdfb36dbac", Passphrase = stream });
                    Certificate = res;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return Certificate;
        }
    }

    public interface IAwsCertService
    {
        Task<string> GetCertificateAsync();
    }
}
