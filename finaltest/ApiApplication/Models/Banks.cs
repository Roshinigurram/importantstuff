using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Models
{

    [Table("Banks")]
    public class Banks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BankAdress { get; set; }
    }
}
