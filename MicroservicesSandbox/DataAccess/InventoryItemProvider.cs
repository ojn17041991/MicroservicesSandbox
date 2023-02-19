using MicroservicesSandbox.DataAccess.Abstract;
using MicroservicesSandbox.Enums;
using MicroservicesSandbox.Models.Inventorys.Abstract;
using System.Data.Common;

namespace MicroservicesSandbox.DataAccess
{
    public class InventoryItemProvider : BaseParameterisedDataProvider<IInventoryItem>
    {
        private DbConnection connection;

        public InventoryItemProvider(DbConnection connection)
        {
            this.connection = connection;
        }

        public override IDataResponse<IInventoryItem> Add(IInventoryItem entity)
        {
            try
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO InventoryItem (Id, Name) VALUES (@Id, @Name)";

                    command.Parameters.Add(GenerateParameter(command, "@Id", entity.Id));
                    command.Parameters.Add(GenerateParameter(command, "@Name", entity.Id));

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch
            {
                return new DataResponse<IInventoryItem>(entity, DataResponseType.Error);
            }

            return new DataResponse<IInventoryItem>(entity, DataResponseType.OK);
        }

        public override IDataResponse<IInventoryItem> Delete(IInventoryItem value)
        {
            throw new NotImplementedException();
        }

        public override IDataResponse<IInventoryItem> Get()
        {
            throw new NotImplementedException();
        }

        public override IDataResponse<IEnumerable<IInventoryItem>> Get(IInventoryItem entity)
        {
            throw new NotImplementedException();
        }

        public override IDataResponse<IInventoryItem> Set(IInventoryItem value)
        {
            throw new NotImplementedException();
        }

        ~InventoryItemProvider()
        {
            if (connection == null)
            {
                return;
            }

            connection.Dispose();
        }
    }
}
