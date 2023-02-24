namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IService
    {
        string ServiceName { get; }

        string BaseAddress { get; }

        string EndPoint { get; }
    }
}
