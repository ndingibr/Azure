using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Tests
{
    [TestClass]
    public class SendGrid
    {
        [TestMethod]
        public async void Send_Message_With_sendGrid()
        {

            IIdentityMessageService msg = new EmailService();
            
            var message = new IdentityMessage
            {
                Destination = "ndingibr@gmail.com",
                Subject = "EmailConfirmation",
                Body = "Please confirm your account by clicking <a href=\"" + "callbackUrl" + "\">here</a>"
            };
            await msg.SendAsync(message);
           

        }
    }
}
