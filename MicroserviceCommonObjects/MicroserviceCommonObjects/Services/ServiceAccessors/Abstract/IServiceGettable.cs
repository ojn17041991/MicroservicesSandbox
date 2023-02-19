namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServiceGettable<T> : IServiceSingleGettable<T>, IServiceCollectionGettable<T>
    {

    }
}