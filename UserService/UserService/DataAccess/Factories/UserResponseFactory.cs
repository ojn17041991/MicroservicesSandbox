using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using UserService.DataAccess.Responses;
using UserService.Models;

namespace UserService.DataAccess.Factories
{
    public class UserResponseFactory : IDataResponseFactory<User>
    {
        public IDataResponse<User> CreateResponse(User entity, DataResponseCode responseCode)
        {
            return new UserResponse(entity, responseCode);
        }
    }
}
