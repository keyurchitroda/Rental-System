using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyOperations.DAL
{
    public class CommanFunction
    {
        public static string GenerateCode(int length)
        {
            string numbers = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string characters = numbers;
            string OTP = string.Empty;
            for(int i=0;i<length;i++)
            {
                string character = string.Empty;
                do
                {
                    int Index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[Index].ToString();
                } while (OTP.IndexOf(character) != -1);
                OTP += character;

            }
            return OTP;
        }

        public static void SendEmail(string toemail, string subject, string details)
        {
            
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("keyurchitroda@gmail.com");
                Msg.To.Add(toemail);
                Msg.Subject = subject;
                Msg.Body = " <br/> Your EmailId=" + toemail + "<br/>Your OTP=<div style='color:red;font-size:35px;'>" + details + "";
                Msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("keyurchitroda@gmail.com", "keyur95371");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
            
        }
        public static string Alert_MessageBox(string sMsg)
        {
            return "<div class='alert alert-danger'>" + sMsg + "</div>";
        }
        public static string Success_MessageBox(string sMsg)
        {
            return "<div class='alert alert-success'>" + sMsg + "</div>";
        }

    }
}
