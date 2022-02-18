using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationContact.Models;

namespace WebApplicationContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var lst = new object();
            try
            {
                using (bdContactContext db = new bdContactContext())
                {
                    lst = db.Contacts.ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            return Ok(lst);

        }

        [HttpPost]
        public IActionResult Add(ContactReq info)
        {
            var lst = new object();
            try
            {
                using (bdContactContext db = new bdContactContext())
                {
                    Contact contact = new Contact();
                    contact.name = info.name;
                    contact.phone = info.phone;
                    contact.cellphone = info.cellphone;
                    db.Contacts.Add(contact);
                    db.SaveChanges();

                    lst = db.Contacts.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return Ok(lst);

        }
    }
}
