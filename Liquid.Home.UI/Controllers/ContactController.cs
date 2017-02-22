using Liquid.Home.UI.Configuration;
using Liquid.Home.UI.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web.Http;

namespace Liquid.Home.UI.Controllers
{
    public class ContactController : ApiController
    {
        [HttpGet]
        [Route("api/contact")]
        public IHttpActionResult Get()
        {
            return Ok(new ContactModel());
        }

        [HttpPost]
        [Route("api/contact")]
        public IHttpActionResult Post([FromBody]ContactModel model)
        {
            if (model == null)
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
#if !DEBUG
                IEmailConfiguration configuration = EnvironmentConfiguration.Email;

                SmtpClient smtpClient = new SmtpClient(configuration.Host, 25);
                smtpClient.Credentials = new NetworkCredential(configuration.Username, configuration.Password);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = true;

                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(configuration.SendTo, configuration.SendToName));
                mail.From = new MailAddress(configuration.SendFrom, configuration.SendFromName);
                mail.Subject = "New message";
                mail.Body = string.Format("The follow message has been sent by {0}:\n\r\n\r{1}\n\r\n\rThey can be contacted at the following: {2} - {3}",
                        model.Name,
                        model.Message,
                        model.EmailAddress,
                        model.PhoneNumber);

                smtpClient.Send(mail);
#endif
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}