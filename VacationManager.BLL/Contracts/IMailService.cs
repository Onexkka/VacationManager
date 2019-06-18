using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.BLL.Contracts
{
    public interface IMailService
    {
        void SendMail(string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string body, bool isBodyHtml = true, bool async = false);
        void SendMail(MailMessage mail, bool async = false);
    }

}
