using System.ComponentModel.DataAnnotations;
namespace BlazorApp1.Shared;

public class Contact{

    [Key]
    public int id           {get;set;}

    [Required(ErrorMessage = "El nombre es Obligatorio")]
    public string name      {get;set;}

    [Required(ErrorMessage = "El Telefono es Obligatorio")]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Por favor ingrese numeros validos")] 
    public string phone     {get;set;}
    
    [Required(ErrorMessage = "El Celular es Obligatorio")]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Por favor ingrese numeros validos")] 
    public string cellphone {get;set;}

    public override string ToString(){
        return "Nombre: " + name + " Telefono: " + phone + " Celular: " + cellphone;
    }
}