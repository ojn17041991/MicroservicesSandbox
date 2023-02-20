using MicroserviceCommonObjects.Data.DataAccessors.Abstract;
using UserService.Models;

namespace UserService.DataAccess.Accessors.Abstract
{
    public interface IUserAccessor : IDataSingleGettable<User>
    {

    }
}
