using Microsoft.Extensions.Options;
using SendSMSWithTwilio.Helpers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SendSMSWithTwilio.Services
{
    public class SMSService : ISMSService
    {
        //how to inject the service setting class using IOptions interface class
        private readonly TwilioSettings _twilio;

        public SMSService(IOptions<TwilioSettings> twilio)
        {
            _twilio = twilio.Value; //to map each value name with property name on app Setting file
        }

        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken); //access the values on the app Settings

            var result = MessageResource.Create(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber), //access values in the app Settings
                    to: mobileNumber
                );        

            return result;
        }
    }
}