using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Domain.Enums
{
    public enum Category
    {
        [Description("Painters")]
        Painters,

        [Description("Interior Painters")]
        InteriorPainters
    }
}
