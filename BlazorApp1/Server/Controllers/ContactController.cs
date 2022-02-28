using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase{

    private readonly ContactDbContext _context;

    public ContactController(ContactDbContext context){
        _context = context;
    }

    // GET: api/Contact
    [HttpGet("list")]
    public IEnumerable<Contact> GetAllContacts(){  
            return _context.Contacts.ToList();
    }

    [HttpPost]
    public string AddContact(Contact contact){
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return "Contacto Agregado.. Redireccionando a la Lista";
    }

    [HttpGet("{name}")]
    public Contact GetContactByName(string name){
        Contact contact = _context.Contacts.SingleOrDefault(e => e.name == name);
        if(contact == null){
            return new Contact();
        }
        return contact;
    }

    [HttpGet("isExist/{name}")]
    public bool isExist(string name){
        if(_context.Contacts.SingleOrDefault(e => e.name == name)!= null){
            return true;
        }
        return false;
    }

    [HttpGet("space")]
    public int spaceOcuped(){
        return _context.Contacts.ToList().Count;
    }

    [HttpPost("delete")]
    public string DeleteContact(Contact _contact){
        if (_contact == null){
            return "Contacto No Encontrado";
        }
        _context.Contacts.Remove(_contact);
        _context.SaveChangesAsync();
        return "Contacto Encontrado y Eliminado Correctamente";
    }

    public int getContact(Contact _contact){
        foreach (var item in _context.Contacts){
            if (item.name.Equals(_contact.name)){
                return item.id;
            }
        }
        return -1;
    }
}
