using MicroservicesSandbox.DataValidation.Abstract;
using MicroservicesSandbox.Enums;
using MicroservicesSandbox.Models.Inventorys.Abstract;

namespace MicroservicesSandbox.DataValidation
{
    public class InventoryItemValidator : IDataValidator<IInventoryItem>
    {
        public ValidationResponseType Validate(IInventoryItem entity)
        {
            if (entity.Id <= 0)
            {
                return ValidationResponseType.DataInvalid;
            }

            if (entity.Name == null)
            {
                return ValidationResponseType.DataMissing;
            }

            if (entity.Name == string.Empty)
            {
                return ValidationResponseType.DataInvalid;
            }

            return ValidationResponseType.OK;
        }
    }
}
