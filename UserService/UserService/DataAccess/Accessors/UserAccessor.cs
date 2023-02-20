using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using System.Data.Common;
using UserService.DataAccess.Accessors.Abstract;
using UserService.Models;

namespace UserService.DataAccess.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        DbConnection connection;
        IDataResponseFactory<User> responseFactory;
        ILogger<UserAccessor> logger;

        public UserAccessor(DbConnection connection, IDataResponseFactory<User> responseFactory, ILogger<UserAccessor> logger)
        {
            this.connection = connection;
            this.responseFactory = responseFactory;
            this.logger = logger;
        }

        public IDataResponse<User> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
