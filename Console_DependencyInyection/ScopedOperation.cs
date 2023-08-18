using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_DependencyInyection
{
    public class ScopedOperation : Operation
    {
        public ScopedOperation() : base("Scoped") { }
    }
}
