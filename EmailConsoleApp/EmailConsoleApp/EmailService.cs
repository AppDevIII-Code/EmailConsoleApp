using MailKit;
using MimeKit;


namespace EmailConsoleApp
{
    /// <summary>
    /// Class <c>EmailService</c> provides the implementation of the IEmailService interface to send and 
    /// receive messages from a mailing service using the MailKit and MimeKit libraries. 
    /// </summary>
    public class EmailService : IEmailService
    {

        IMailConfig _config;
        IMailTransport _sendClient;
        IMailStore _receiveClient;

        #region CONSTRUCTOR
        public EmailService(IMailTransport sendClient, IMailStore receiveClient, IMailConfig config) 
        { 
            _config = config;
            _sendClient = sendClient;
            _receiveClient = receiveClient;
           
        }

        #endregion
        #region CONNECTION AND AUTHENTICATION
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
                    await _sendClient.AuthenticateAsync(_config.EmailAddress, _config.Password);
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
                    await _receiveClient.AuthenticateAsync(_config.EmailAddress, _config.Password);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
        public async Task DisconnectSendClientAsync() => await _sendClient.DisconnectAsync(true);
        public async Task DisconnectReceiveClient() => await _receiveClient.DisconnectAsync(true);

        #endregion
        #region EMAILING FUNCTIONALITIES
        public async Task<IEnumerable<MimeMessage>?> DownloadAllEmailsAsync()
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
                return null;
            }
            finally
            {
                await DisconnectSendClientAsync();
            }
        }


        public async Task SendMessageAsync(MimeMessage message)
        {
            try
            {
                await StartSendClientAsync();
                await _sendClient.SendAsync(message);
                await DisconnectReceiveClient();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error sending message {ex.Message}");
            }
            finally
            {
                await DisconnectSendClientAsync();
            }
        }

        public async Task DeleteMessageAsync(int uid)
        {
            try
            {
                await StartReceiveClientAsync();
                var inbox = _receiveClient.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadWrite);
                var deleteRequest = new StoreFlagsRequest(StoreAction.Add, MessageFlags.Deleted) { Silent = true };
                await inbox.StoreAsync(uid, deleteRequest);
                await inbox.ExpungeAsync();
                await DisconnectReceiveClient();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting message {ex.Message}");
            }
            finally
            {
                await DisconnectReceiveClient();
            }
        }

        #endregion
    }
}
