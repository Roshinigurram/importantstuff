using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ListingAllproject4.Models
{
  
        [Table("Customers")]
        public class Customers
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAdress { get; set; }
        }
       
    }

