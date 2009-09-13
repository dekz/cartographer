using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;


namespace cartographer
{
    public class ElectorateImporter : Importer
    {
        private List<Electorate> m_ElectorateDataMID;
        private List<Electorate> m_ElectorateDataMIF;
        private List<Electorate> m_ElectorateDataXLS;        

        private StreamReader m_ElectorateReaderMID;
        private StreamReader m_ElectorateReaderMIF;

        public ElectorateImporter()
        {
            m_ElectorateDataMID = new List<Electorate>();
            m_ElectorateDataMIF = new List<Electorate>();
            m_ElectorateDataXLS = new List<Electorate>();
        }

        private Electorate MergeData()
        {
            object obj = new object();
            return (Electorate) obj;
        }

        public bool ParseMID(string filename)
        {
            try
            {
                m_ElectorateReaderMID = new StreamReader(filename);
            }
            catch
            {
                return false;
            }
            while (!m_ElectorateReaderMID.EndOfStream)
            {
                ParseLineMID(m_ElectorateReaderMID.ReadLine());    
            }
            return true;
        }

        protected bool ParseLineMID(string line)
        {
            string lineSoFar = "";
            string[] electorateData = new string[9];
            int electorateDataPosition = 0;
            //id,"electoratename",numccds,actual,projected,totalpop,over18,area,"name"
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    electorateData[electorateDataPosition] = lineSoFar;
                    lineSoFar = "";
                    electorateDataPosition++;
                }
                else if (line[i] == '\"') { /*ignore*/ }
                else
                {
                    lineSoFar += line[i];
                }
            }
            electorateData[electorateDataPosition] = lineSoFar;
            Electorate electorate = new Electorate();
            electorate.ID = int.Parse(electorateData[0]);
            electorate.Name = int.Parse(electorateData[1]);
            //numccds???????????
            electorate.Actual = int.Parse(electorateData[3]);
            electorate.Projected = int.Parse(electorateData[4]);
            electorate.TotalPopulation = int.Parse(electorateData[5]);
            electorate.Over18 = int.Parse(electorateData[6]);
            electorate.Area = float.Parse(electorateData[7]);
            m_ElectorateDataMID.Add(electorate);
            return true;
        }

        public bool ParseMIF(string filename)
        {
            
            try
            {
                m_ElectorateReaderMIF = new StreamReader(filename);
            }
            catch
            {
                //shits fucked
            }
            for (int i = 1; i <= 17; i++)
            {
                //drop the first 17 lines -> irrelevant
                m_ElectorateReaderMIF.ReadLine();
            }
            while (!m_ElectorateReaderMIF.EndOfStream)
            {
                int currentShape = -1;
                int currentRegion = -1;
                string line = m_ElectorateReaderMIF.ReadLine();
                if (line[0] == 'R')
                {
                    //number of polys
                    Electorate electorate = new Electorate();
                    m_ElectorateDataMIF.Add(electorate);
                    currentRegion++;
                    string lineSoFar = "";
                    for (int i = 7; i < line.Length; i++)
                    {
                        lineSoFar += line[i];
                    }
                    for (int i = 1; i <= int.Parse(lineSoFar); i++)
                    {
                        Shape shape = new Shape();
                        electorate.Boundaries.Add(shape);
                    }
                }
                else if (line[0] == ' ' && line[1] == ' ' && line[2] != ' ')
                {
                    //num points
                    string lineSoFar;
                    for (int i = 2; i < line.Length; i++)
                    {
                        lineSoFar += line[i];
                    }
                    currentShape++;
                    for (int i = 0; i < int.Parse(lineSoFar); i++)
		            {
                        Vector2 tempVector2 = new Vector2();
                        m_ElectorateDataMIF[currentRegion].Boundaries[currentShape].points.Add(tempVector2);
		            }                    
                }
                else if (line[0] == ' ' && line[1] == ' ' && line[2] == ' ')
                {
                    //pen brush center
                }
                else
                {
                    //its a point
                }
                
            }
            return true; //cos it so works
        }

        protected bool ParseLineMIF(string line)
        {
            
            return true;
        }

        public bool ParseXLS()
        {

           string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                                      Data Source=\data\Qld_FederalResults by Electorate-2004.xls;Extended Properties=
                                      ""Excel 8.0;HDR=YES;""";

          
            return false;
        }

        protected bool ParseLineXLS()
        {
            return false;
        }

    }
}
