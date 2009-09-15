using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cartographer
{
    class Exporter
    {
        private List<Electorate> m_electorates;

        public Exporter(List<Electorate> a_electorates)
        {
            m_electorates = a_electorates;
        }

        public string convertToKml()
        {
            string _kml = "";
            if (!(m_electorates == null))
            {

            }
            return _kml;
        }

        public bool exportKMLFile()
        {
            string _returnKML = convertToKml();
            //write this shit to a file
            return true;
        }
    }
}
