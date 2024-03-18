using Autopiter.Core.Exceptions.Abstarct;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autopiter.Core.Exceptions
{
    public class UseIndicatorWithTrueAlreadyExistException : BaseApplicationException
    {
        public UseIndicatorWithTrueAlreadyExistException() : base(HttpStatusCode.BadRequest, "Инсталяция с параметром 'По умолчанию' уже существует")
        {
            
        }
    }
}
