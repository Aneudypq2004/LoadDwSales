using LoadDWSales.Data.Core;

namespace LoadDWSales.Data.Interfaces
{
    public interface IDataServiceDwSales
    {
        Task<BaseResult> LoadDHW();
    }
}
