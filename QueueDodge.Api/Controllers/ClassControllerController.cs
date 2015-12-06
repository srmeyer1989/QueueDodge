using QueueDodge.Models;
using QueueDodge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QueueDodge.Api.Controllers
{
    [Route("api/classes")]
    public class ClassControllerController : ApiController
    {
        private ClassService classes;

        public ClassControllerController()
        {
            classes = new ClassService();
        }

        public IEnumerable<Class> GetClasses()
        {
            return classes.GetClasses();
        }
    }
}
