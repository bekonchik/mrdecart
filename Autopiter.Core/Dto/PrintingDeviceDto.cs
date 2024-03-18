using Autopiter.Core.Enum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Dto
{
    public class PrintingDeviceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ConnectionType ConnectionType { get; set; }

        public string? MacAdress { get; set; }

    }
}
