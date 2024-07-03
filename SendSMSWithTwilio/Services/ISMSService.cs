using Twilio.Rest.Api.V2010.Account;

namespace SendSMSWithTwilio.Services
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body);  //this Class is Available by default in Dot Net install twilio Package
    }
}