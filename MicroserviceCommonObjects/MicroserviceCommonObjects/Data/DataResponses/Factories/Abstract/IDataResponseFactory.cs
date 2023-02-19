﻿using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract
{
    public interface IDataResponseFactory<T>
    {
        IDataResponse<T> CreateResponse(T entity, DataResponseCode responseCode);

        IDataResponse<IEnumerable<T>> CreateResponse(IEnumerable<T> collection, DataResponseCode responseCode);
    }
}