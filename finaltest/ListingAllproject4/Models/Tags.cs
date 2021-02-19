using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ListingAllproject4.Models
{
   
      [Table("Tags")]
        public class Tags
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int TagId { get; set; }
            [ForeignKey("TagId")]
            public int BankId { get; set; }
            [ForeignKey("CustomerId")]
            public int CustomerId { get; set; }
            public Decimal Balance { get; set; }
            public Customers Customers { get; set; }
        }

    }

