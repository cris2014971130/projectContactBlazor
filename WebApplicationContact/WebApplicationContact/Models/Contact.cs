using System;
using System.Collections.Generic;

namespace WebApplicationContact.Models
{
    public partial class Contact
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string phone { get; set; } = null!;
        public string cellphone { get; set; } = null!;
    }
}
