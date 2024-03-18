using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Dto
{
    public class InstallationDto
    {

        public string Name { get; set; }

        public int CompanyBranchId { get; set; }

        public int PrintingDeviceId { get; set; }

        public int? OrderNumber { get; set; }

        public bool UseIndicator { get; set; }
    }
}
