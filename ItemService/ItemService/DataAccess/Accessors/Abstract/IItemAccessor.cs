using ItemService.Models;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;

namespace ItemService.DataAccess.Accessors.Abstract
{
    public interface IItemAccessor : IDataSingleGettable<Item>
    {

    }
}
