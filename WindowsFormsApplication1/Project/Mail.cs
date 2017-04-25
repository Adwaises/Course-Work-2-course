using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project
{
    class Mail
    {
        public void SendMail(string s, int id)
        {
            DataForBD.iter = 0;
            //int id = 1;
            DateTime second = DateTime.Now;
            SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 587);
            Smtp.Credentials = new NetworkCredential("lexa2171@mail.ru", "123A456B789c!");
            Smtp.EnableSsl = true;
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("lexa2171@mail.ru");
            Message.To.Add(new MailAddress(s));
            DataForBD.iter = 1;
            Message.Subject = "Заказ №" + Convert.ToString(id);
            Message.Body = "Бланк заказа №" + Convert.ToString(id) + Environment.NewLine + "Дата формирования письма: " + second;
            string file = "Document.pdf";
            Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
            Message.Attachments.Add(attach);
            DataForBD.iter = 2;
            try
            {
                Smtp.Send(Message);
                attach.Dispose();
                DataForBD.iter = 3;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
