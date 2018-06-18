using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace capstoneproject

{
    public static class Emailsender
    {
        private const string From = "claimapril2018dotnet@gmail.com";
        private const string Pass = "sfqdvalvyqxwnzhk";
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;

        public static void Send(String To, String Subject, String Body)
        {
            using (var client = new SmtpClient(Host, Port))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(From, Pass);

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(From);
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = false;

                    var toAddresses = To.Split(';');
                    foreach (var adress in toAddresses)
                    {
                        message.To.Add(new MailAddress(adress));
                    }

                    client.Send(message);
                }
            }
        }

    }
}
