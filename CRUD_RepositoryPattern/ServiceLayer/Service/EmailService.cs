using CRUD_Operations_Product_and_Category.Models;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace ServiceLayer.Service
{
   public class EmailService:IEmailService
    {
        private readonly ISendEmail _sendEmail;
        public EmailService(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }
       public void sendMail(User user)
        {
            _sendEmail.sendMail(user);
        }
    }
}
