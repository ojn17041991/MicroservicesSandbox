using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;
using UserService.Models;

namespace UserService.DataAccess.Responses
{
    public class UserResponse : IDataResponse<User>
    {
        public UserResponse(User entity, DataResponseCode responseCode)
        {
            Entity = entity;
            ResponseCode = responseCode;
        }



        public User Entity { get; }

        public DataResponseCode ResponseCode { get; }
    }
}
