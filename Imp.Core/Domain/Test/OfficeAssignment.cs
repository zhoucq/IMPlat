using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imp.Core.Domain.Test
{
    public class OfficeAssignment
    {
        public string InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        public string Name { get; set; }
    }

    public class Instructor
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }

}
