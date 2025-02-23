using MailKit.Net.Imap;
using MailKit.Security;

namespace EmailConsoleApp
{
    public class MailConfig : IMailConfig
    {
        public required string ReceiveHost { get; set; }
        public SecureSocketOptions RecieveSocketOptions { get; set; }

        public int ReceivePort { get; set; }

        public required string SendHost { get; set; }

        public SecureSocketOptions SendSocketOptions { get; set; }

        public int SendPort { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public string? OAuth2ClientId { get; set; }
        public string? OAuth2ClientSecret { get; set; }
        public string? OAuth2RefreshToken { get; set; }
    }
}
