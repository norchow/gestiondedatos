using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions
{
    class InsertException : Exception
    {
        public string TableBeingInserted { get; set; }
    }
}
