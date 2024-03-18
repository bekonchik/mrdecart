using Autopiter.Core.Dto;
using Autopiter.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static EmployeeDto MapEmployeeToDto(this Employee employee)
        {

            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                CompanyBranchId = employee.CompanyBranchId,
            };
        }

        public static PrintingDeviceDto MapPrintingDeviceToDto(this PrintingDevice printingDevice)
        {
            return new PrintingDeviceDto
            {
                Id = printingDevice.Id,
                Name = printingDevice.Name,
                ConnectionType = printingDevice.ConnectionType,
                MacAdress = printingDevice.MacAdress
            };
        }

        public static CompanyBranchDto MapCompanyBranchToDto(this CompanyBranch companyBranch)
        {
            return new CompanyBranchDto
            {
                Id = companyBranch.Id,
                Name = companyBranch.Name,
                LocationName = companyBranch.LocationName
            };
        }

        public static Installation MapDtoToInstallation(this InstallationDto installationDto)
        {
            return new Installation
            {
                Name = installationDto.Name,
                CompanyBranchId = installationDto.CompanyBranchId,
                PrintingDeviceId = installationDto.PrintingDeviceId,
                OrderNumber = installationDto.OrderNumber,
                UseIndicator = installationDto.UseIndicator
            };
        }
    }
}
