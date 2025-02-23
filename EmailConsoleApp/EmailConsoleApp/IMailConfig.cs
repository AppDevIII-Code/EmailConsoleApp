using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailConsoleApp
{
    public interface IMailConfig
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ReceiveHost { get; set; }
        public SecureSocketOptions RecieveSocketOptions { get; set; }
        public int ReceivePort { get; set; }

        public string SendHost { get; set; }

        public SecureSocketOptions SendSocketOptions { get; set; }

        public int SendPort { get; set; }
        public string? OAuth2ClientId { get; set; }
        public string? OAuth2ClientSecret { get; set; }
        public string? OAuth2RefreshToken { get; set; }
    }
}
