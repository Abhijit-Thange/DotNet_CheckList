using CRUD_Operations_Product_and_Category.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRUD_Operations_Product_and_Category.ServiceLayer.ReportService
{
    public interface IReport
    {
        Task<List<Report>> ProductReport(int? pageNo);

    }
}
