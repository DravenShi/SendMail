using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SendMail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 以下是使用 Google SMTP 伺服器的設定
            string senderEmail = "寄件人@gmail.com";
            string senderPassword = "去Google Account註冊應用程式密碼"; // 應用程式密碼或帳戶密碼

            // 創建SMTP客戶端
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, // 587 是 TLS 加密的端口號
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true, // 啟用 SSL 加密
            };

            string recipientEmail = "收件人@gmail.com"; // 收件人的電子郵件地址
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = "信件主旨",
                Body = "信件內容",
            };
            mailMessage.To.Add(recipientEmail);

            try
            {
                // 發送郵件
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
