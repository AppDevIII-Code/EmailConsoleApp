using MailKit;
using MimeKit;

namespace EmailConsoleApp
{
    public interface IEmailService
    {
        Task StartSendClientAsync();
        Task DisconnectSendClientAsync();
        Task StartReceiveClientAsync();
        Task DisconnectReceiveClient();

        Task SendMessageAsync(MimeMessage message);
        Task<IEnumerable<MimeMessage>?> DownloadAllEmailsAsync();

        Task DeleteMessageAsync(int uid);

    }
}
