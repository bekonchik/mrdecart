using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Entities
{
    public class Installation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CompanyBranchId { get; set; }

        public int PrintingDeviceId {  get; set; }

        public int? OrderNumber { get; set; }

        public bool UseIndicator { get; set; }

        public CompanyBranch? CompanyBranch { get; set; }

        public PrintingDevice? PrintingDevice { get; set; }

    }
}
