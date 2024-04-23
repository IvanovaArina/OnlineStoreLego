using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.Responces
{
    public class BaseResponces
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public URole Role { get; set; }
    }
}
