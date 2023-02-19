namespace MicroservicesSandbox.DataAccess.Abstract
{
    public interface IDataProvider<T> : IDataGetter<T>, IDataSetter<T>
    {

    }
}
