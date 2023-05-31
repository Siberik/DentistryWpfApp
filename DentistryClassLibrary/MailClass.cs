using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DentistryClassLibrary
{
    public class MailClass
    {
        public static bool SendMail(string to, string login, string password)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 25))
                {
                    smtpClient.Credentials = new NetworkCredential("t.pochta@vladgubarev.site", "G0S3inDTHG4G3sG2TuGi");
                    smtpClient.EnableSsl = true;

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("t.pochta@vladgubarev.site");
                        mailMessage.To.Add(new MailAddress(to));
                        mailMessage.Subject = "Восстановление пароля.";
                        mailMessage.Body = $"Восстановление пароля произошло успешно. Ваш логин: {login}.\nВаш пароль: {password}.\nЕсли вы не подавали заявку на восстановление пароля, напишите на почту: t.pochta@vladgubarev.site";

                        smtpClient.Send(mailMessage);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке письма: {ex.Message}");
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
