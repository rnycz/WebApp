using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magazyn.Models
{
    public class User
    {
        public int ID { get; set; }
        //nazwa użytkownika
        [Required(ErrorMessage ="Podaj nazwę użytkownika")]
        [DisplayName("Nazwa użytkownika")]
        public string UserName { get; set; }
        //hasło
        [Required(ErrorMessage ="Wpisz hasło")]
        [DisplayName("Hasło")]
        public string Password { get; set; }
        //typ konta użytkownika
        [Required]
        [DisplayName("Typ konta użytkownika")]
        public bool UserType { get; set; }
    }
}