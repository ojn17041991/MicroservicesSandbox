namespace CentralService.Models.Responses.Abstract
{
    public interface IDataResponse<T>
    {
        T Entity { get; }
    }
}
