using ConsoleAppDatabase.Entities;




namespace ConsoleAppDatabase.Repositories
{
    internal class ContactsRolesRepository : Repo<ContactsRoles>
    {
        public ContactsRolesRepository(Program.ContactDbContext context) : base(context)
        {
        }
    }
}
