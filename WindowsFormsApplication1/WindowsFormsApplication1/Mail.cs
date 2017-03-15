using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Mail
    {
        public void SendMail()
        {
            int id = 1;
            DateTime second = DateTime.Now;
            SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 587);
            Smtp.Credentials = new NetworkCredential("lexa2171@mail.ru", "123A456B789c!");
            Smtp.EnableSsl = true;
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("lexa2171@mail.ru");//от кого
            Message.To.Add(new MailAddress("adwaises@mail.ru"));//кому
            Message.Subject = "Заказ №" + Convert.ToString(id);//тема
            Message.Body = "Бланк заказа №" + Convert.ToString(id) + Environment.NewLine + "Дата формирования письма: " + second;//текст письма
            string file = "Document.pdf";
            Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
            Message.Attachments.Add(attach);
            try
            {
                Smtp.Send(Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
