using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccounts.Entities
{
   public class Department
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }
}
