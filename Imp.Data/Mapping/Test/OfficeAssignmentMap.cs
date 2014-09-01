using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imp.Core.Domain.Test;

namespace Imp.Data.Mapping.Test
{
    public class OfficeAssignmentMap:EntityTypeConfiguration<OfficeAssignment>
    {
        public OfficeAssignmentMap()
        {
            this.ToTable("OfficeAssignment");
            this.HasKey(m => m.InstructorId);
            //this.HasRequired(m => m.Instructor)
            //    //.WithOptional(t => t.OfficeAssignment);
            //    .WithRequiredPrincipal(t => t.OfficeAssignment);
        }
    }

    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap()
        {
            this.HasKey(m => m.Id);
            
            this.HasRequired(m => m.OfficeAssignment)
                .WithRequiredPrincipal(m => m.Instructor);
        }
    }
}
