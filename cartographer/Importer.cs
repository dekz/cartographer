using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cartographer
{
    public interface Importer
    {
        void ParseMID();
        void ParseMIF();
        void ParseXLS();
    }
}
