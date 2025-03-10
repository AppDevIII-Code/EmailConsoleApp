using MailKit.Net.Imap;
using MailKit.Security;

namespace EmailConsoleApp
{
    public class MailConfig : IMailConfig
    {
        /// <summary>
        /// Class <c>MailConfig</c> container class for an email client configuration. 
        /// </summary>

        #region USER CREDENTIALS
        public required string EmailAddress { get; set; }

        public required string Password { get; set; }
        #endregion
        #region RECEIVE CIENT CONFIGS
        public required string ReceiveHost { get; set; }
        public SecureSocketOptions RecieveSocketOptions { get; set; }

        public int ReceivePort { get; set; }
        #endregion
        #region SEND CLIENT CONFIGS
        public required string SendHost { get; set; }

        public SecureSocketOptions SendSocketOptions { get; set; }

        public int SendPort { get; set; }
        #endregion
        # region OPTIONAL 0AUTH 2.0 CONFIGS
        public string? OAuth2ClientId { get; set; }
        public string? OAuth2ClientSecret { get; set; }
        public string? OAuth2RefreshToken { get; set; }
        #endregion
    }
}
