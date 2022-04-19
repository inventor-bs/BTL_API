using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RegisterController : ApiController
    {
        [HttpPost]
        public bool InsertNewAccount(string username, string password, string email, string status)
        {
            try
            {
                CHQADataContext dB = new CHQADataContext();
                User user = new User();
                user.U_id = "";
                user.U_email = email;
                user.U_status = status;
                user.U_name = username;
                user.U_pass = password;
                dB.Users.InsertOnSubmit(user);
                dB.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
