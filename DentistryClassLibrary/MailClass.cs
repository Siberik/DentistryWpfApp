using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace DentistryClassLibrary
{
    
    public class MailClass
    {
        /// <summary>
        ///  Отправка логина и пароля на почту 
        /// </summary>
        /// <param name="to">
        /// Кому (наш адресат)
        /// </param>
        /// <param name="login">
        /// Логин пользователя
        /// </param>
        /// <param name="password">
        /// Новый пароль пользователя
        /// </param>
        /// <returns>
        /// Возвращает true, если письмо отправлено и false, если нет
        /// </returns>
        public static bool SendMail(string to,string login, string password)
        {
            try
            {
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25);
            smtpClient.Credentials = new NetworkCredential("t.pochta@vladgubarev.site", "G0S3inDTHG4G3sG2TuGi");
            smtpClient.EnableSsl = true;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("t.pochta@vladgubarev.site");
            mailMessage.To.Add(new MailAddress($"{to}"));
            mailMessage.Subject = $"Восстановление пароля.";
            mailMessage.Body = $"Восстановление пароля произшло успешно. Ваш логин: {login}.\n Ваш пароль: {password}. \n Если вы не подавали заявку на восстановление пароля, то напишите на почту: t.pochta@vladgubarev.site";
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
