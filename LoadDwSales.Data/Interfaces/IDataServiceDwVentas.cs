using LoadDWSales.Data.Core;

namespace LoadDWSales.Data.Interfaces
{
    public interface IDataServiceDwVentas
    {
        Task<BaseResult> LoadDHW();
    }
}
