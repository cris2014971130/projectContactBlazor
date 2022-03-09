using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase{

    private readonly ContactDbContext _context;
    private Controller controller;

    public ContactController(ContactDbContext context){
        _context = context;
        controller = new Controller(_context);
    }

    // GET: api/Contact
    [HttpGet("list")]
    public IEnumerable<Contact> GetAllContacts(){  
        return controller.getContacts();
    }

    [HttpPost]
    public string AddContact(Contact contact){
        return controller.addContact(contact);
    }

    [HttpGet("{name}")]
    public Contact GetContactByName(string name){
        return controller.searchContact(name);
    }

    [HttpGet("isExist/{name}")]
    public bool isExist(string name){
        return controller.isExist(name);
    }

    [HttpGet("space")]
    public int spaceOcuped(){
        return controller.spaceOcuped();
    }

    [HttpPost("delete")]
    public string DeleteContact(Contact _contact){
        return controller.DeleteContact(_contact);
    }
}
