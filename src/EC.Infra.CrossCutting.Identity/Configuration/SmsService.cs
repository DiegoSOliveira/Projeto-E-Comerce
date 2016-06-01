using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;

namespace EC.Infra.CrossCutting.Identity.Configuration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["Internet"] == "true")
            {
                // Utilizando TWILIO como SMS Provider.
                // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

                const string accountSid = "AC335cdd8222a6588cb0ac8e2d8062aa1f";
                const string authToken = "c1ac905a518f3a1da48ec4868a115ec8";

                var client = new TwilioRestClient(accountSid, authToken);

                client.SendMessage("69-99924-8522", message.Destination, message.Body);
            }

            return Task.FromResult(0);
        }
    }
}