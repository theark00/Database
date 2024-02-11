using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleAppDatabase.Entities;

namespace ConsoleAppDatabase.Repositories
{
    internal class UserRepository : Repo<User>
    {
        public UserRepository(Program.ContactDbContext context) : base(context)
        {
        }
    }
}
