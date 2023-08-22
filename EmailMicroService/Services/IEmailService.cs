using EmailMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMicroService.Services
{
  public interface IEmailService
    {
        public void SendEmail(Message message);
    }
}
