using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost__Data.Entities
{
    public class AppRole : IdentityRole<Guid> // guid là định danh duy nhất
    {
        public string Description { get; set; }
    }
}
