using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataSingleGettable<T>
    {
        IDataResponse<T> Get(int id);
    }
}
