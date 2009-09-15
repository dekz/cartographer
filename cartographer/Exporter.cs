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
            StreamReader tr = new StreamReader("data/KmlTemplate.txt");
            StreamWriter tw = new StreamWriter("data/kml - Copy.kml");

            // Write the KML template styles.
            while (!tr.EndOfStream)
            {
                tw.WriteLine(tr.ReadLine());
            }
            tr.Close();
            writeCoordinates(tw);
            return _kml;
        }

        public bool exportKMLFile()
        {
            string _returnKML = convertToKml();
            return true;
        }

        private void writeCoordinates(StreamWriter tw)
        {
            if (!(m_electorates == null))
            {
                foreach (Electorate elec in m_electorates)
                {
                    tw.WriteLine("<Placemark>");
                    tw.WriteLine("<name>" + elec.Name + "</name>");
                    
                    // Style Selection
                    string TPWinner = "";
                    if (elec.LNP2PVotes > elec.ALP2PVotes) 
                    {
                        TPWinner = "#Labor";
                    } else
                    {
                        TPWinner = "#Liberal";
                    }

                    tw.WriteLine("<styleUrl>" + TPWinner + "</styleUrl>");

                    foreach (Shape bounds in elec.Boundaries)
                    {
                        tw.WriteLine("<Polygon>");
                        tw.WriteLine("<extrude>0</extrude>");
                        tw.WriteLine("<tessellate>1</tessellate>");
                        tw.WriteLine("<altitudeMode>clampToGround</altitudeMode>");
                        tw.WriteLine("<outerBoundaryIs>"); 
                        tw.WriteLine("<LinearRing>");
                        tw.WriteLine("<coordinates>");

                        foreach (Vector2 point in bounds.points)
                        {
                            string pts = (point.X.ToString() + "," + point.Y.ToString() + ",20");
                            tw.WriteLine(pts);
                        }
                        tw.WriteLine("</coordinates>");
                        tw.WriteLine("</LinearRing>");
                        tw.WriteLine("</outerBoundaryIs>"); 
                        tw.WriteLine("</Polygon>");
                    }
                    tw.WriteLine("</Placemark>");
                }
                
                tw.WriteLine("</Document>");
                tw.WriteLine("</kml>");
                Console.Out.WriteLine("Done");
                tw.Close();
            }
        }
    }
}
