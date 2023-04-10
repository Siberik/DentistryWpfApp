using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DentistryClassLibrary
{
    public class MailClass
    {
        public static bool SendMail(string to,string password)
        {
            try
            {
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25);
            smtpClient.Credentials = new NetworkCredential("t.pochta@vladgubarev.site", "U8n9miiaZRyjVBvag4Q6");
            smtpClient.EnableSsl = true;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("t.pochta@vladgubarev.site");
            mailMessage.To.Add(new MailAddress($"{to}"));
            mailMessage.Subject = $"Восстановление пароля.";
            mailMessage.Body = $"Восстановление пароля произшло успешно.\n Ваш новый пароль: {password}. \n Если вы не подавали заявку на восстановление пароля, то напишите на почту:t.pochta@vladgubarev.site";
            smtpClient.Send(mailMessage);
            return true;
            }

            catch
            {
                return false;
            }
           
        }
        public static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

        public static void Main()
        {
            int length = 10;

            string password = GetRandomPassword(length);
            Console.WriteLine(password);
        }
    }
}
