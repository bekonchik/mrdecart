using Autopiter.Application.Extensions;
using Autopiter.Application.Services;
using Autopiter.Core.Entities;
using Autopiter.Core.Enum;

using Microsoft.AspNetCore.Mvc;

namespace Autopiter.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandBookController : ControllerBase
    {
        private readonly HandbookService _handbookService;

        public HandBookController(HandbookService handBookService)
        {
            _handbookService = handBookService;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _handbookService.GetAllEmployees();

            var response = employees.Select(x => x.MapEmployeeToDto()).ToList();

            return Ok(new { employees = response });
        }

        [HttpGet("GetAllCompanyBranches")]
        public async Task<IActionResult> GetAllCompanyBranches()
        {
            var companyBranches = await _handbookService.GetAllCompanyBranches();

            var response = companyBranches.Select(x => x.MapCompanyBranchToDto()).ToList();

            return Ok(new { companyBranches = response });
        }

        [HttpGet("GetAllPrintingDevices")]
        public async Task<IActionResult> GetAllPrintingDevices(ConnectionType? connectionType)
        {
            var result = connectionType == null ? await _handbookService.GetAllPrintingDevices() : await _handbookService.GetPrintingDevicesByFilter(connectionType);

            return Ok(new { printingDevices = result.Select(x => x.MapPrintingDeviceToDto()).ToList()});
        }
    }
}
