namespace MicroservicesSandbox.DataAccess.Abstract
{
    public interface IDataSetter<T>
    {
        IDataResponse<T> Add(T value);

        IDataResponse<T> Set(T value);

        IDataResponse<T> Delete(T value);
    }
}
