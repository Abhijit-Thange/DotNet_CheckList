using CRUD_CoreWebAPI.Models;
using CRUD_CoreWebAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{page}")]
        public async Task<List<Report>> GetProductReports([FromRoute]int? page)
        {
            return await _reportService.GetReport(page);
        }
    }
}
