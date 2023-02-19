namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataGettable<T> : IDataSingleGettable<T>, IDataCollectionGettable<T>
    {

    }
}
