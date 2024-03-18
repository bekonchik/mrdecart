using Autopiter.Core.Exceptions.Abstarct;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Exceptions
{
    public class PrintingDeviceNotFoundException : BaseApplicationException
    {
        public PrintingDeviceNotFoundException() : base(HttpStatusCode.BadRequest, "Указаное устройство печати не существует")
        {
            
        }
    }
}
