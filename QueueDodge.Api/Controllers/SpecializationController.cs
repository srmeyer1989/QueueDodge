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
    public class SpecializationController : ApiController
    {
        private SpecializationService specializations;

        public SpecializationController()
        {
            specializations = new SpecializationService();
        }
        public IEnumerable<Specialization> GetSpecializations()
        {
            return specializations.GetSpecializations();
        }
    }
}
