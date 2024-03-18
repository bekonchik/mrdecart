using Autopiter.Core.Entities;
using Autopiter.Core.Enum;
using Autopiter.Infrastructure;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Application.Services
{
    public class HandbookService
    {
        private readonly DatabaseContext _databaseContext;

        public HandbookService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<CompanyBranch>> GetAllCompanyBranches()
        {
            return await _databaseContext.CompanyBranches.ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _databaseContext.Employees.ToListAsync();

        }

        public async Task<List<PrintingDevice>> GetPrintingDevicesByFilter(ConnectionType? connectionType)
        {

            return await _databaseContext.PrintDevices.Where(x => x.ConnectionType == connectionType).ToListAsync();

        }

        public async Task<List<PrintingDevice>> GetAllPrintingDevices()
        {
            return await _databaseContext.PrintDevices.ToListAsync();
        }
    }
}
