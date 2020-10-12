using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products_Catergories.Models
{
    public class Association
    {
        [Key]
        public int AssciationId {get; set;}
        public int ProductId {get; set;}

        public int CategoryId {get; set;}
        public Catergory Category {get; set;}
        public Product Product {get; set;}
    }
}