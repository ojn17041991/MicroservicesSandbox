using MicroservicesSandbox.Enums;

namespace MicroservicesSandbox.DataValidation.Abstract
{
    public interface IDataValidator<T>
    {
        ValidationResponseType Validate(T entity);
    }
}
