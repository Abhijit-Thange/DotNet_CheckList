using CRUD_CoreWebAPI.Models;

namespace CRUD_CoreWebAPI.Repository.IRepo
{
    public interface IReportRepo
    {
        Task<List<Report>> GetReport(int? pageNo);
    }
}
