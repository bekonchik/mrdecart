using Autopiter.Core.Exceptions.Abstarct;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Exceptions
{
    public class InstallationNotFoundException : BaseApplicationException
    {
        public InstallationNotFoundException() : base(HttpStatusCode.BadRequest, "Инсталяция с таким id не найдена")
        {
            
        }
    }
}
