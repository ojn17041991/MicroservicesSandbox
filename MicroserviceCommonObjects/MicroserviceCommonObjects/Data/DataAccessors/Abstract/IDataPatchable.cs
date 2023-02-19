using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataPatchable<T>
    {
        IDataResponse<T> Patch(T entity);
    }
}
