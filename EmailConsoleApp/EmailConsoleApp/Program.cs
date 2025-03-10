using MailKit.Net.Imap;
using MailKit.Net.Smtp;

namespace EmailConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new MailConfig() { ReceiveHost = "", SendHost = "", EmailAddress = "", Password = "" };
            var sendClient = new SmtpClient();
            var receiveClient = new ImapClient();
            var service = new EmailService(sendClient, receiveClient, config);
        }
    }
}
