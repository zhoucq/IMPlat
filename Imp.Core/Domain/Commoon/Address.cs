using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMP.Core.Domain.Commoon
{
    public class Address : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string CountryId { get; set; }

        public string StateProvinceId { get; set; }

        
    }
}
