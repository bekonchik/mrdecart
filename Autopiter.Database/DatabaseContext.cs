using Autopiter.Core.Entities;
using Autopiter.Core.Enum;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Infrastructure
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        public DbSet<CompanyBranch> CompanyBranches { get; set; }

        public DbSet<Installation> Installations { get; set; }

        public DbSet<PrintingDevice> PrintDevices { get; set; }

        private List<CompanyBranch> _companyBranches = new List<CompanyBranch>()
        {
            new CompanyBranch
            {
                Id = 1,
                LocationName = "Тридевятое царство",
            },
            new CompanyBranch
            {
                Id = 2,
                LocationName = "Дремучий лес"
            },
            new CompanyBranch
            {
                Id = 3,
                LocationName = "Луна"
            }
        };

        private List<Employee> _employees = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                Name = "Царь",
                CompanyBranchId = 1
            },
            new Employee
            {
                Id = 2,
                Name = "Добрыня",
                CompanyBranchId = 1
            },
            new Employee
            {
                Id = 3,
                Name = "Яга",
                CompanyBranchId = 2
            },
            new Employee
            {
                Id = 4,
                Name = "Копатыч",
                CompanyBranchId = 3
            },
            new Employee
            {
                Id = 5,
                Name = "Кощей",
                CompanyBranchId = 3
            },
            new Employee
            {
                Id = 6,
                Name = "Лосяш",
                CompanyBranchId = 3
            },
        };

        private List<PrintingDevice> _printDevices = new List<PrintingDevice>()
        {
            new PrintingDevice
            {
                Id = 1,
                Name = "Папирус",
                ConnectionType = ConnectionType.Local
            },
            new PrintingDevice
            {
                Id = 2,
                Name = "Бумага",
                ConnectionType = ConnectionType.Local
            },
            new PrintingDevice
            {
                Id = 3,
                Name = "Камень",
                ConnectionType = ConnectionType.Network
            },
        };

        private List<Installation> _instalations = new List<Installation>()
        {
            new Installation
            {
                Id = 1,
                Name = "Дворец",
                CompanyBranchId = 1,
                OrderNumber = 1,
                UseIndicator = true,
                PrintingDeviceId = 1
            },
            new Installation
            {
                Id = 2,
                Name = "Конюшни",
                CompanyBranchId = 1,
                OrderNumber = 2,
                UseIndicator = false,
                PrintingDeviceId = 2
            },
            new Installation
            {
                Id = 3,
                Name = "Оружейная",
                CompanyBranchId = 1,
                OrderNumber = 3,
                UseIndicator = false,
                PrintingDeviceId = 2
            },
            new Installation
            {
                Id = 4,
                Name = "Кратер",
                CompanyBranchId = 3,
                OrderNumber = 1,
                UseIndicator = true,
                PrintingDeviceId = 3
            },
            new Installation
            {
                Id = 5,
                Name = "Избушка",
                CompanyBranchId = 2,
                OrderNumber = 3,
                UseIndicator = false,
                PrintingDeviceId = 2
            },
            new Installation
            {
                Id = 6,
                Name = "Топи",
                CompanyBranchId = 2,
                OrderNumber = 2,
                UseIndicator = true,
                PrintingDeviceId = 1
            },
        };

        public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompanyBranch>()
                .HasData(_companyBranches);

            modelBuilder.Entity<Employee>()
                .HasData(_employees);

            modelBuilder.Entity<PrintingDevice>()
                .HasData(_printDevices);

            modelBuilder.Entity<Installation>()
                .HasData(_instalations);

            base.OnModelCreating(modelBuilder);
        }
    }
}
