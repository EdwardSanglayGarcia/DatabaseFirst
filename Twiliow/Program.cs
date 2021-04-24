using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twiliow
{
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    class Program
    {
        static void Main(string[] args)
        {
            string accountSid = "ACbc91df0ba1a1ff0c856e0fcd4194e1a3";
            string authToken = "44922dc890e1c90a2d549d677529b442";


            // Initialize the Twilio client
            TwilioClient.Init(accountSid, authToken);

            // make an associative array of people we know, indexed by phone number
            var people = new Dictionary<string, string>() {
                {"+639065006155", "Edward Garcia"},
            };

            // Iterate over all our friends
            foreach (var person in people)
            {
                // Send a new outgoing SMS by POSTing to the Messages resource
                MessageResource.Create(
                    from: new PhoneNumber("+14158424070"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
                                                     // Message content
                    body: $"Huy");

                Console.WriteLine($"Sent message to {person.Value}");
            }

        }
    }
}
