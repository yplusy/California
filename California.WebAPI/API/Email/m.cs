using System.Net.Mail;

namespace California.WebAPI.API.Mail
{
    public static class Data
    {
        public static void SendEmail(string sendTo)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.To.Add(sendTo);//发件人名称
            //抄送人邮箱
            String[] sendCCArr = null;
            if (sendCC != null)
            {
                sendCCArr = sendCC.Split(';');
                if (sendCCArr.Length > 0)
                {
                    foreach (String cc in sendCCArr)
                    {
                        mailMsg.CC.Add(cc);
                    }
                }
            }
            //发件人邮箱及名称
            mailMsg.From = new MailAddress(builder.Configuration.GetConnectionString("FromEmail"), builder.Configuration.GetConnectionString("FromName"));

            string file = "data.xls";
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            mailMsg.Attachments.Add(data);

            SmtpClient client = new SmtpClient(server);
            client.Credentials = CredentialCache.DefaultNetworkCredentials;

            try
            {
                client.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("邮箱错误: {0}",
                    ex.ToString());
            }
        }
    }
}