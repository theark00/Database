using ConsoleAppDatabase.Entities;



namespace ConsoleAppDatabase.Repositories
{
    internal class UserInfoAddressRepository : Repo<UserInfoAddress>
    {
        public UserInfoAddressRepository(Program.ContactDbContext context) : base(context)
        {
        }
    }
}
