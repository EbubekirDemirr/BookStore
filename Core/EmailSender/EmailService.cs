using Entities.Concrete.Authentication;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;
using System.Net.Mail;

namespace Core.EmailSender;

public class EmailService
{
    public void SendEmail(string email, int otpCode, string userId )
    {
    //https://localhost:44319/api/Users/verify-userEmail?userId=100&otpCode=111111&id=200

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("gelirdimamadelirdimana27@gmail.com");
        msg.To.Add(email);
        msg.IsBodyHtml = true;
        msg.Subject = "E-posta doğrulama";
        msg.Body = "<h1> Mail Doğrulama </h1> <b> Mail Doğrulama işlemi için </b> <a href=https://localhost:44319/api/Users/verify-userEmail?userId=" +userId+ "&otpCode=" + otpCode+ "> Tıklayınız </a>";

        SmtpClient smtpClient = new SmtpClient("in-v3.mailjet.com", 587)
        {
            Credentials = new NetworkCredential("5218bd4cfe74a89e58bb4aaecdb3785a", "12467dbc0f6bab68b42758ccf6a53749"),
            EnableSsl = true,
            
        };
        try
        {
            smtpClient.Send(msg);
        }
        catch (Exception)
        {

            throw;
        }

    }
    

}

    