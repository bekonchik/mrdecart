using Autopiter.Application.Extensions;
using Autopiter.Application.Services;
using Autopiter.Core.Dto;
using Autopiter.Core.Entities;
using Autopiter.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autopiter.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallationController : ControllerBase
    {
        private readonly InstallationService _installationService;
        private readonly DatabaseContext _databaseContext;

        public InstallationController(InstallationService installationService, DatabaseContext databaseContext)
        {
            _installationService = installationService;
            _databaseContext = databaseContext;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> PostInstalation(InstallationDto installationDto)
        {

            var response = await _installationService.PostInstallation(installationDto);

            return Created("", value: new { id = response });
        }

        [HttpGet("GetByCompanyBranchId")]
        public async Task<IActionResult> GetInstallationsByFilter(int? companyBranchId)
        {
            
            return Ok(new { installations = await _installationService.GetInstallationsByFilter(companyBranchId) });
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetInstallationsById(int id)
        {
            return Ok(new { installations = await _installationService.GetIntallationsById(id) });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteInstallation(int id)
        {
            await _installationService.DeleteInstallationById(id);
            
            return Ok();
        }
    }
}
