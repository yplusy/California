using California.WebAPI.Entities;

namespace California.WebAPI.API.User.Login
{
    public class Mapper : Mapper<Request, Response, UserInfoEntity>
    {
        public override async Task<UserInfoEntity> ToEntityAsync(Request r)
        {
            return new UserInfoEntity()
            {
                UserId = r.UserId,
                UserName = r.UserName,
                Pwd = r.Pwd,
            };
        }
    }
}