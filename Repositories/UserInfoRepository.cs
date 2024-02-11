using ConsoleAppDatabase.Entities;




namespace ConsoleAppDatabase.Repositories
{
    internal class UserInfoRepository : Repo<UserInfo>
    {
        public UserInfoRepository(Program.ContactDbContext context) : base(context)
        {
        }
    }
}
