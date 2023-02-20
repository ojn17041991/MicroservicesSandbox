using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
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
            User user = new User();
            bool userFound = false;

            try
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
SELECT * FROM Users
WHERE ID = @UserID";

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@UserID";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userFound = true;

                            user = new User()
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty
                            };

                            break;
                        }
                    }
                }

                connection.Close();
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to get user from database for ID {id} - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(user, DataResponseCode.Error);
            }

            if (userFound)
            {
                return responseFactory.CreateResponse(user, DataResponseCode.OK);
            }
            else
            {
                return responseFactory.CreateResponse(user, DataResponseCode.ResourceNotFound);
            }
        }
    }
}
