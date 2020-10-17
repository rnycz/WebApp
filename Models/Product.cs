using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magazyn.Models
{
    public class Product
    {
        // ID 
        public int ID { get; set; }
        // nazwa
        [DisplayName("Nazwa produktu")]
        [Required(ErrorMessage ="Podaj nazwę produktu")]
        public string Name { get; set; }
        // kod kreskowy
        [DisplayName("Kod kreskowy EAN")]
        [Required(ErrorMessage = "Wpisz kod kreskowy")]
        [StringLength(14, ErrorMessage ="EAN musi zawierać 14 liczb", MinimumLength =14)]
        public string EAN { get; set; }
        // cena jednostkowa
        [RegularExpression(@"^\d{1,10}.\d{2}$", ErrorMessage ="Zły format danych. Przykładowa cena: 9.99")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00# zł}")]
        [Required(ErrorMessage = "Podaj cenę produktu")]
        [DisplayName("Cena jednostkowa")]
        public double Price { get; set; }
        // jednostka
        [Required(ErrorMessage = "Podaj w jakiej jednostce jest określony")]
        [DisplayName("Jednostka")]
        public string Unit { get; set; }
        // stan magazynowy
        [Required(ErrorMessage = "Podaj ilość produktu jaką rejestrujesz")]
        [DisplayName("Ilość na magazynie")]
        public int Availability { get; set; }
        // kategoria
        [Required(ErrorMessage = "Podaj do jakiej kategorii produktów należy")]
        [DisplayName("Kategoria produktu")]
        public string Category { get; set; } 
    }
}