using System.ComponentModel.DataAnnotations;
namespace BlazorApp1.Shared;

public class Contact{

    [Key]
    public int id           {get;set;}
    public string name      {get;set;}
    public string phone     {get;set;}
    public string cellphone {get;set;}

    public override string ToString(){
        return "Nombre: " + name + " Telefono: " + phone + " Celular: " + cellphone;
    }
}