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
            tr.Close();
            string _altitudestr = "<altitudeMode>relativeToGround</altitudeMode>";

            if (!(m_electorates == null))
            {
                foreach (Electorate elec in m_electorates)
                {
                    string boundary = "<Polygon id=\"";
                    boundary += elec.Name;
                    boundary += "\">";
                    tw.WriteLine(boundary);
                    tw.WriteLine(_altitudestr);

                    foreach (Shape bounds in elec.Boundaries)
                    {                        
                        foreach (Vector2 point in bounds.points)
                        {
                            string pts = (point.X.ToString() + "," + point.Y.ToString() + ",0");
                            tw.WriteLine(pts);
                        }
                    }

                    boundary = "</Polygon>";
                }
                //tw.Write(_kml);
                Console.Out.WriteLine("Done");
                tw.Close();
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
