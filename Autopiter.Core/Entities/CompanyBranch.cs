using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Entities
{
    public class CompanyBranch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string LocationName { get; set; }

        public List<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
