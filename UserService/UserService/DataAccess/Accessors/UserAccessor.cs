using MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using UserService.DataAccess.Accessors.Abstract;
using UserService.DataAccess.DbContexts;
using UserService.Models;
using UserService.ServiceAccess.Accessors.Abstract;

namespace UserService.DataAccess.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        UserDbContext context;
        IBasketServiceAccessor basketAccessor;
        ISingleDataResponseFactory<User> responseFactory;
        ILogger<UserAccessor> logger;

        public UserAccessor(
            UserDbContext context,
            IBasketServiceAccessor basketAccessor,
            ISingleDataResponseFactory<User> responseFactory,
            ILogger<UserAccessor> logger)
        {
            this.context = context;
            this.basketAccessor = basketAccessor;
            this.responseFactory = responseFactory;
            this.logger = logger;
        }

        public IDataResponse<User> Get(int id)
        {
            User? user = context.users.SingleOrDefault(u => u.id == id);

            if (user == null)
            {
                return responseFactory.CreateResponse(new User(), DataResponseCode.ResourceNotFound);
            }
            else
            {
                return responseFactory.CreateResponse(user, DataResponseCode.OK);
            }
        }

        public IDataResponse<User> Post(User entity)
        {
            IDataResponse<User> existingUser = Get(entity.id);
            if (existingUser.ResponseCode == DataResponseCode.OK)
            {
                // We found an existing user, which means there's a duplicate.
                return responseFactory.CreateResponse(entity, DataResponseCode.ResourceDuplicated);
            }

            Task<IDataResponse<Basket>> basketTask = basketAccessor.PostAsync();
            IDataResponse<Basket> basketResponse = basketTask.Result;
            if (basketResponse.ResponseCode != DataResponseCode.OK)
            {
                // The attempt to POST a new basket failed.
                logger.LogWarning($"Basket service could not post a new basket.");
                return responseFactory.CreateResponse(entity, basketResponse.ResponseCode);
            }

            // Everything worked, so post the new user with the new basket ID.
            entity.basketid = basketResponse.Entity.Id;
            context.users.Add(entity);
            context.SaveChanges();

            return responseFactory.CreateResponse(entity, DataResponseCode.OK);
        }
    }
}
