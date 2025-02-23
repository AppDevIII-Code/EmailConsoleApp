using MailKit;
using MailKit.Net.Imap;
using MimeKit;


namespace EmailConsoleApp
{
    public class EmailService : IEmailService
    {
        IMailConfig _config;
        IMailTransport _sendClient;
        IMailStore _receiveClient;

        // Constructor
        public EmailService(IMailTransport sendClient, IMailStore imapClient, IMailConfig config) 
        { 
            _config = config;
            _sendClient = sendClient;
            _receiveClient = imapClient;
           
        }

        public async Task StartSendClientAsync()
        {
            try
            {
                if (!_sendClient.IsConnected)
                {
                    await _sendClient.ConnectAsync(_config.SendHost, _config.SendPort, _config.SendSocketOptions);
                }
                if (!_sendClient.IsAuthenticated)
                {
                    await _sendClient.AuthenticateAsync(_config.Email, _config.Password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task StartReceiveClientAsync()
        {
            try
            {
                if (!_receiveClient.IsConnected)
                {
                    await _receiveClient.ConnectAsync(_config.ReceiveHost, _config.ReceivePort, _config.RecieveSocketOptions);
                }
                if (!_receiveClient.IsAuthenticated)
                {
                    await _receiveClient.AuthenticateAsync(_config.Email, _config.Password);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
        public async Task DisconnectSendClientAsync() => await _sendClient.DisconnectAsync(true);
        public async Task DisconnectReceiveClient() => await _receiveClient.DisconnectAsync(true);
        
        public async Task<IEnumerable<MimeMessage>> DownloadAllEmailsAsync()
        {
            try
            {
                List<MimeMessage> emails = new List<MimeMessage>();

                await StartReceiveClientAsync();
                var inbox = _receiveClient.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);
                
                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = await inbox.GetMessageAsync(i);
                    emails.Add(message);
                }

                _receiveClient.Disconnect(true);
                return emails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MimeMessage>();
            }
        }

        public async Task SendMessageAsync(MimeMessage message)
        {
            await StartSendClientAsync();
            await _sendClient.SendAsync(message);
            await DisconnectReceiveClient();
        }

        public async Task DeleteMessageAsync(int uid)
        {
            await StartReceiveClientAsync();
            var inbox = _receiveClient.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadWrite);
            var deleteRequest = new StoreFlagsRequest(StoreAction.Add, MessageFlags.Deleted) { Silent = true };
            await inbox.StoreAsync(uid, deleteRequest);
            await inbox.ExpungeAsync();
            await DisconnectReceiveClient();
        }
        
    }
}
