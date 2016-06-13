using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Accounts.Web.DataContexts
{
    public class UserAccountsDb : DbContext
    {
        public UserAccountsDb()
            :base("DefaultConnection")
        {

        }

        public DbSet<UserAccounts.Entities.Department> Departments { get; set; }

        public DbSet<UserAccounts.Entities.UserAccount> UserAccounts { get; set; }

        public DbSet<UserAccounts.Entities.Account>  Accounts { get; set; }
    }
}