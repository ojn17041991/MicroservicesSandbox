using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;
using UserService.Models;

namespace UserService.DataAccess.Responses
{
    public class UserResponse : IDataResponse<User>
    {
        public User Entity => throw new NotImplementedException();

        public DataResponseCode ResponseCode => throw new NotImplementedException();
    }
}
