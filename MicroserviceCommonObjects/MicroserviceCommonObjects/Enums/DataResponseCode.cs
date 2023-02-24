namespace MicroserviceCommonObjects.Enums
{
    public enum DataResponseCode
    {
        OK = 0,
        BadRequest_DataMissing = 1000,
        BadRequest_DataInvalid = 1001,
        BadRequest_NoData = 1002,
        ResourceNotFound = 1100,
        ResourceDuplicated = 1101,
        Error = 2000
    }
}
