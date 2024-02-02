using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using California.WebAPI;

namespace API.Email
{
    public static class Data
    {
        public static void CreateMessageWithAttachment(string addressee)
        {
            // 创建邮件
            MailMessage message = new MailMessage();
            message.From = new MailAddress("505755935@qq.com");// 发件人
            message.To.Add(new MailAddress(addressee));// 收件人
            message.Subject = "标题测试";// 邮件标题
            message.SubjectEncoding = Encoding.UTF8; // 邮件标题编码
            message.IsBodyHtml = true; // 邮件正文是否是HTML格式
            message.BodyEncoding = Encoding.UTF8; // 邮件正文的编码，设置不正确，接收者会收到乱码
            message.Body = "<font color=\"red\">邮件测试</font>"; // 邮件正文
            // message.Attachments.Add(new Attachment(@"c:\d\1.doc", System.Net.Mime.MediaTypeNames.Application.Rtf));

            // 附件路径
            string file = @"C:\Users\Joker\Desktop\data.xlsx";
            // 创建此电子邮件的文件附件
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // 为文件添加时间戳信息 
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // 将文件附件添加到此电子邮件
            // message.Attachments.Add(data);

            // 发送消息
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.qq.com";// SMTP服务器地址
            client.Port = 25; // 端口号
            client.UseDefaultCredentials = true;// SMTP服务器SSL认证
            client.Credentials = new NetworkCredential("username@qq.com", "授权码code"); // 发件人邮箱的用户和密码(授权码，并不是发件邮箱的密码)
            client.Credentials = CredentialCache.DefaultNetworkCredentials;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email方法中捕获到异常: {0}", ex.ToString());
            }


            // 显示附件的ContentDisposition中的值
            ContentDisposition cd = data.ContentDisposition;
            Console.WriteLine("内容处置");
            Console.WriteLine(cd.ToString());
            Console.WriteLine("File {0}", cd.FileName);
            Console.WriteLine("Size {0}", cd.Size);
            Console.WriteLine("Creation {0}", cd.CreationDate);
            Console.WriteLine("Modification {0}", cd.ModificationDate);
            Console.WriteLine("Read {0}", cd.ReadDate);
            Console.WriteLine("Inline {0}", cd.Inline);
            Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
            foreach (DictionaryEntry d in cd.Parameters)
            {
                Console.WriteLine("{0} = {1}", d.Key, d.Value);
            }
            data.Dispose();
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sendTo">收件人地址</param>
        /// <param name="sendCC">抄送人地址（多人）</param>
        /// <param name="fromEmail">发件人邮箱</param>
        /// <param name="fromName">发件人名称</param>
        /// <param name="title">邮件标题</param>
        /// <param name="body">邮件内容（支持html格式）</param>
        public static bool SendEmail(string sendTo)
        {

            string fromEmail = AppSettings.Configuration.GetSection("Email:FromEmail").Value;/*GetConnectionString("FromEmail");*/
            string fromName = AppSettings.Configuration.GetSection("Email:FromName").Value;
            string sendCC = AppSettings.Configuration.GetSection("Email:SendCC").Value;
            MailMessage msg = new MailMessage();
            String[] sendCCArr = null;
            // 设置收件人地址
            msg.To.Add(sendTo); // 收件人地址
            // 设置抄送人地址
            if (sendCC != null)
            {
                sendCCArr = sendCC.Split(';');
                if (sendCCArr.Length > 0)
                {
                    foreach (String cc in sendCCArr)
                    {
                        msg.CC.Add(cc);
                    }
                }
            }
            // 设置发件人邮箱及名称
            msg.From = new MailAddress(fromEmail, fromName);

            msg.Subject = "table"; // 邮件标题 
            msg.SubjectEncoding = Encoding.UTF8; // 标题格式为UTF8 

            msg.Body = "body"; // 邮件内容
            msg.BodyEncoding = Encoding.UTF8; // 内容格式为UTF8 
            msg.IsBodyHtml = true; // 设置邮件格式为html格式

            // string filePath = @"E:\导出数据.xls";// 添加附件
            // msg.Attachments.Add(new Attachment(filePath));

            SmtpClient client = new SmtpClient();

            // 发送邮箱信息
            client.Host = AppSettings.Configuration.GetSection("Email:SmtpClient:Host").Value; // SMTP服务器地址 
            client.Port = int.Parse(AppSettings.Configuration.GetSection("Email:SmtpClient:Port").Value);  // SMTP端口，QQ邮箱填写587 

            client.EnableSsl = true; // 启用SSL加密

            // 发件人邮箱账号，授权码
            client.Credentials = new System.Net.NetworkCredential(fromEmail, AppSettings.Configuration.GetSection("Email:SmtpClient:Password").Value);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            try
            {
                client.Send(msg); // 发送邮件
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}