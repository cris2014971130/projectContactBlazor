using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared;
using System.Net;

namespace BlazorApp1.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase{
    
    private readonly ContactDbContext _context;
    public ContactController(ContactDbContext context){
        _context = context;
    }

    // GET: api/Contact
    [HttpGet]
    public IEnumerable<Contact> GetAllContacts(){
        try{
            return _context.Contacts.ToList();
        }catch (Exception e){
            throw;
        }
    }

    [HttpPost]
    public IActionResult AddContact(Contact contact){
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet("{name}")]
    public Contact GetContactByName(string name){
        return _context.Contacts.SingleOrDefault(e => e.name == name);
    }

    [HttpGet("isExist/{name}")]
    public bool isExist(string name){
        print(name);
        Contact c = _context.Contacts.SingleOrDefault(e => e.name == name);
      
        if(c != null){
            print(name+ "" + c.ToString());
            return true;
        }
        return false;
    }

    [HttpDelete("{name}")]
    public string DeleteContact(string name){
        Contact contact = _context.Contacts.Find(getContact(name));
        if (contact == null){
             return "NotFound";
        }
        _context.Contacts.Remove(contact);
        _context.SaveChangesAsync();
       return "jaja";
    }

    public int getContact(string name){
        foreach (var item in _context.Contacts){
            if (item.name.Equals(name)){
                return item.id;
            }
        }
        return -1;
    }

    public void print(string value){
        Console.WriteLine(value);
    }
}
