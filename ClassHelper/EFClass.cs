using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS3ISP9_14.DB;

namespace GS3ISP9_14.ClassHelper
{
    class EFClass
    {
        public static Entities Context { get; } = new Entities();
    }
}
