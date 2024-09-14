using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.IO;
using TwoFactorAuthNet;
using TwoFactorAuthNet.Providers.Qr;

namespace FRONTEND_TEMPLATE.Classes
{
    public class _2FAAuth
    {
        public bool VerifyOtp(string Issuer, string secret, string otp)
        {
            try
            {
                // Create an instance of the TwoFactorAuth class
                var tfa = new TwoFactorAuth(Issuer);

                // Verify the provided OTP
                bool isValid = tfa.VerifyCode(secret, otp);
                if (isValid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public string GenerateUri([FromBody] string User)
        {
            try
            {
                var Issuer = "MyApp";
                // Create an instance of the TwoFactorAuth class
                var tfa = new TwoFactorAuth(Issuer);

                // Generate a secret key for the user
                string secret = tfa.CreateSecret(160); // 160 bits secret

                // Generate the otpauth URI
                string otpauthUri = tfa.GetQrCodeImageAsDataUri(User, secret);
                return otpauthUri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
