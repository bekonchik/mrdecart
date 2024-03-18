using Autopiter.Application.Extensions;
using Autopiter.Core.Dto;
using Autopiter.Core.Entities;
using Autopiter.Core.Exceptions;
using Autopiter.Infrastructure;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Application.Services
{
    public class InstallationService
    {
        private readonly DatabaseContext _databaseContext;

        public InstallationService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> PostInstallation(InstallationDto installationDto)
        {
            var installations = await _databaseContext.Installations.ToListAsync();
            var existingUseIndicator = installations.Where(x => x.CompanyBranchId == installationDto.CompanyBranchId).SingleOrDefault(x => x.UseIndicator == true);
            var newInstallation = installationDto.MapDtoToInstallation();

            var existingCompanyBranch = await _databaseContext.CompanyBranches.SingleOrDefaultAsync(x => x.Id == newInstallation.CompanyBranchId);
            var existingPrintingDevice = await _databaseContext.PrintDevices.SingleOrDefaultAsync(x => x.Id == newInstallation.PrintingDeviceId);

            var maxCountOrderNumber = installations.Max(x => x.OrderNumber);
            if (newInstallation.OrderNumber == null)
            {
                if (maxCountOrderNumber == null)
                    newInstallation.OrderNumber = 1;

                else
                    newInstallation.OrderNumber = maxCountOrderNumber + 1;
            }

            else
            {
                var existingInstalationWithOrderNumber = installations.Where(x => x.CompanyBranchId == installationDto.CompanyBranchId).SingleOrDefault(x => x.OrderNumber == newInstallation.OrderNumber);
                if (existingInstalationWithOrderNumber is not null)
                    throw new OrderNumberAlreadyExistException();

            }

            if (existingUseIndicator != null && newInstallation.UseIndicator == true)
            {
                throw new UseIndicatorWithTrueAlreadyExistException();
            }

            else if (existingUseIndicator == null && newInstallation.UseIndicator == false)
            {
                newInstallation.UseIndicator = true;
            }

            if (existingCompanyBranch == null)
                throw new CompanyBranchNotFoundException();

            if (existingPrintingDevice == null)
                throw new PrintingDeviceNotFoundException();

            var postResult = await _databaseContext.Installations.AddAsync(newInstallation);

            await _databaseContext.SaveChangesAsync();

            return postResult.Entity.Id;
        }

        public async Task<List<Installation>> GetInstallationsByFilter(int? companyBranchId)
        {

            return companyBranchId != null ?
                await _databaseContext.Installations.Where(x => x.CompanyBranchId == companyBranchId).ToListAsync() : await _databaseContext.Installations.ToListAsync();
        }

        public async Task<Installation> GetIntallationsById(int id)
        {
            var installation = await _databaseContext.Installations.SingleOrDefaultAsync(x => x.Id == id);

            if (installation == null)
                throw new InstallationNotFoundException();

            return installation;
        }

        public async Task DeleteInstallationById(int id)
        {
            var installation = await _databaseContext.Installations.FirstOrDefaultAsync(x => x.Id == id);
            if (installation is null)
                throw new InstallationNotFoundException();

            _databaseContext.Installations.Remove(installation);

            if (installation.UseIndicator == true)
            {
                var installationWithNewTrueUseIndicator = await _databaseContext.Installations.Where(x => x.Id != id).FirstAsync();
                installationWithNewTrueUseIndicator.UseIndicator = true;
                _databaseContext.Installations.Update(installationWithNewTrueUseIndicator);
            }

            await _databaseContext.SaveChangesAsync();
        }

    }
}
