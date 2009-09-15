using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            StreamReader tr = new StreamReader("data/kml.kml");
            StreamWriter tw = new StreamWriter("data/kml2.kml");

            while (!tr.EndOfStream)
            {
                _kml += tr.ReadLine();
            }

            if (!(m_electorates == null))
            {
                foreach (Electorate elec in m_electorates)
                {
                    
                    foreach (Shape bounds in elec.Boundaries)
                    {
                        
                        string shapePts = "";
                        
                        foreach (Vector2 point in bounds.points)
                        {
                            string pts = (point.X.ToString() + "," + point.Y.ToString() + ",0");
                            shapePts += pts;
                        }
                        tw.WriteLine(shapePts);
                        tw.Flush();
                    }
                }
                //tw.Write(_kml);
                Console.Out.WriteLine(_kml);
            }
            tw.Close();
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
