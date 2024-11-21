using LoadDWSales.Data.Result;

namespace LoadDWSales.Data.Interfaces
{
    public interface IDataServiceDwVentas
    {
        Task<BaseResult> LoadDHW();
    }
}
