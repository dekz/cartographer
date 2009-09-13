using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cartographer
{
    public interface Importer
    {
        public void ParseMID();
        public void ParseMIF();
        public void ParseXLS();
    }
}
