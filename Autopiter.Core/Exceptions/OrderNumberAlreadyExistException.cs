using Autopiter.Core.Exceptions.Abstarct;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Exceptions
{
    public class OrderNumberAlreadyExistException : BaseApplicationException
    {
        public OrderNumberAlreadyExistException() : base(HttpStatusCode.BadRequest, "Исталяция с таким OrderNumber уже существует")
        {
            
        }
    }
}
