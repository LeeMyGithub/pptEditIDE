using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
namespace jg.Editor.Library
{
   public class EmailAction
    {

       /// <summary>
       /// 初始化Email操作类
       /// </summary>
       /// <param name="Agreement">协议</param>
       public EmailAction(string Agreement)
       {
           System.Net.Mail.SmtpClient client = new SmtpClient(Agreement);
       }

    }
}
