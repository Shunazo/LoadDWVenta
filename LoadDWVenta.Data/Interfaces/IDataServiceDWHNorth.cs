using LoadDWVenta.Data.Result;

namespace LoadDWVenta.Data.Interfaces
{
    public interface IDataServiceDWHNorth
    {
        Task<OperactionResult> LoadDHW();
    }
}
