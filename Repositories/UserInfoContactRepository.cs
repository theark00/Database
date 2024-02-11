using ConsoleAppDatabase.Entities;




namespace ConsoleAppDatabase.Repositories
{
    internal class UserInfoContactRepository : Repo<UserInfoContact>
    {
        public UserInfoContactRepository(Program.ContactDbContext context) : base(context)
        {
        }
    }
}
