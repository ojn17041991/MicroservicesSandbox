namespace CentralService.Models.Responses.Abstract
{
    public interface IDataResponseFactory
    {
        IDataResponse<T> CreateResponse<T>(T entity);
    }
}
