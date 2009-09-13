using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cartographer
{
    public interface Importer
    {
        bool ParseMID();
        bool ParseMIF();
        bool ParseXLS();
    }
}
