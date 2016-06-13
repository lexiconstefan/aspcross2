using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccounts.Entities
{
   public class UserAccount
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string municipality { get; set; }


        public virtual int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department department { get; set; }

        public virtual int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account account { get; set; }
    }
}
