using BlazorApp1.Shared;

namespace BlazorApp1.Server.Controllers;

public class Controller{
    
    private readonly ContactDbContext _context;

    public Controller(ContactDbContext context){
        _context = context;
    }

    public List<Contact> getContacts(){
        return _context.Contacts.ToList();
    }

    public string addContact(Contact contact){
        if(isExist(contact.name)){
            return "Contacto ya existe. No se puede registrar";
        }else{
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return "Contacto Agregado.. Redireccionando a la Lista";
        }
    }

    public Contact searchContact(string name){
        Contact contact = _context.Contacts.SingleOrDefault(e => e.name.ToLower().Equals(name.ToLower()));
        if(contact == null){
            return new Contact();
        }
        return contact;
    }

    public bool isExist(string name){
        if(_context.Contacts.SingleOrDefault(e => e.name.ToLower().Equals(name.ToLower()))!= null){
            return true;
        }
        return false;
    }

    public int spaceOcuped(){
        return _context.Contacts.ToList().Count;
    }

    public string DeleteContact(Contact _contact){
        if (_contact == null){
            return "Contacto No Encontrado";
        }
        _context.Contacts.Remove(_contact);
        _context.SaveChangesAsync();
        return "Contacto Encontrado y Eliminado Correctamente";
    }
}