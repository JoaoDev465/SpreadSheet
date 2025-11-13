using System.Net;
using System.Net.Mail;

namespace Spreadsheet.Services;

public class Smtp
{
    private readonly IConfiguration _configuration;

    public Smtp(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void SendEmail(string subject,
        byte [] pdf,
        string fromEmail,
        string ToEmail)
    {
      var NameCredential =  _configuration.GetValue<string>("Smtp:NameCredential");
      var KeyCredential = _configuration.GetValue<string>("Smtp:Key");
        try
        {
            var Mail = new MailMessage();
            Mail.From = new MailAddress(fromEmail);
            Mail.To.Add(ToEmail);
            Mail.Subject = subject;
            Mail.Body = "Segue o Anexo do pdf aqui em baixo";
            Mail.IsBodyHtml = false;

            var stream = new MemoryStream(pdf);
            
                var attachment = new Attachment(stream, "documento.pdf", "application/pdf");
                Mail.Attachments.Add(attachment);
        
            var smtp = new SmtpClient("smtp-relay.brevo.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(NameCredential,KeyCredential),
                EnableSsl = true
            };
            
            smtp.Send(Mail);
        }
        catch (Exception e)
        {
            Console.WriteLine("Send Message Error" + e.Message);
        }
    }
    
}