using BusinessLogicLayer.IRepository;
using CRUD_Operations_Product_and_Category.POCO;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepo _reportRepo;

        public ReportService(IReportRepo reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public Task<List<Report>> GetReport(int? pageNo)
        {
            return _reportRepo.GetReport(pageNo);
        }
    }
}
