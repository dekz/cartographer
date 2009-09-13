﻿using System;
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

        private List<Electorate> MergeData()
        {
            List<Electorate> _Electorates = new List<Electorate>();
            for (int i = 0; i < m_ElectorateDataMID.Count; i++)
            {
                Electorate _ElectorateData = new Electorate();
                _Electorates.Add(_ElectorateData);
            }
            for (int i = 0; i < m_ElectorateDataMID.Count; i++)
            {
                //MIF DATA
                _Electorates[i].Boundaries = m_ElectorateDataMIF[i].Boundaries;

                //MID DATA
                _Electorates[i].Actual = m_ElectorateDataMID[i].Actual;
                _Electorates[i].Area = m_ElectorateDataMID[i].Area;
                _Electorates[i].Division = m_ElectorateDataMID[i].Division;
                _Electorates[i].ID = m_ElectorateDataMID[i].ID;
                _Electorates[i].Name = m_ElectorateDataMID[i].Name;
                _Electorates[i].Over18 = m_ElectorateDataMID[i].Over18;
                _Electorates[i].Projected = m_ElectorateDataMID[i].Projected;
                _Electorates[i].TotalPopulation = m_ElectorateDataMID[i].TotalPopulation;

                //XLS DATA
                _Electorates[i].ALP2PVotes = m_ElectorateDataXLS[i].ALP2PVotes;
                _Electorates[i].ALPVotes = m_ElectorateDataXLS[i].ALPVotes;
                _Electorates[i].DEMVotes = m_ElectorateDataXLS[i].DEMVotes;
                _Electorates[i].GRNVotes = m_ElectorateDataXLS[i].GRNVotes;
                _Electorates[i].LNP2PVotes = m_ElectorateDataXLS[i].LNP2PVotes;
                _Electorates[i].LPVotes = m_ElectorateDataXLS[i].LPVotes;
                _Electorates[i].NPVotes = m_ElectorateDataXLS[i].NPVotes;
                _Electorates[i].OTHVotes = m_ElectorateDataXLS[i].OTHVotes;
            }
            return _Electorates;
        }

        public bool ParseMID(string filename)
        {
            try
            {
                m_ElectorateReaderMID = new StreamReader(filename);
            }
            catch
            {
                Environment.Exit(0); //HAAHAHAHAHAHAHA
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
            electorate.Name = electorateData[1];
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
            int currentShape = -1;
            int currentRegion = -1;
            int currentPoint = -1;
            while (!m_ElectorateReaderMIF.EndOfStream)
            {

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
                    string lineSoFar = "";
                    for (int i = 2; i < line.Length; i++)
                    {
                        lineSoFar += line[i];
                    }
                    currentShape++;
                    currentPoint = -1;
                    for (int i = 0; i < int.Parse(lineSoFar); i++)
		            {
                        Vector2 tempVector2 = new Vector2();
                        m_ElectorateDataMIF[currentRegion].Boundaries[currentShape].points.Add(tempVector2);
		            }                    
                }
                else if (line[0] == ' ' && line[1] == ' ' && line[2] == ' ')
                {
                    //pen brush center
                    if (line[4] == 'C')
                    {
                        m_ElectorateDataMIF[currentRegion].Boundaries[currentShape].center = PointParse(line.Substring(11));

                        currentPoint = -1;
                        currentShape = -1;
                    }

                }
                else
                {
                    //its a point
                    currentPoint++;
                    m_ElectorateDataMIF[currentRegion].Boundaries[currentShape].points[currentPoint] = PointParse(line);
                }
                
            }
            return true; //cos it so works
        }

        private Vector2 PointParse(string line)
        {
            string[] points = line.Split(' ');
            Vector2 point = new Vector2();
            point.X = float.Parse(points[0]);
            point.Y = float.Parse(points[1]);
            return point;
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

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            //OleDbCommand commandtest = new OleDbCommand("SELECT * FROM [2004 Election$]", connection);
            OleDbDataAdapter _allData = new OleDbDataAdapter("SELECT * FROM [2004 Election$]", connection);
            DataSet ds = new DataSet();
            _allData.Fill(ds);
            Console.Out.WriteLine("fuck");
            var table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                //Console.Out.WriteLine(row.ItemArray);

                List<String> _param = new List<String>();
                foreach (var thing in row.ItemArray)
                {
                    if (thing.ToString().Length != 0)
                    {
                        Console.Out.WriteLine(thing);
                        _param.Add(thing.ToString());
                    }
                }

                foreach (String _check in _param)
                {
                    if (_check != null)
                    {
                        Electorate _electorate = new Electorate(_param);
                    }
                }
                


            }


          
            return false;
        }

        protected bool ParseLineXLS()
        {
            return false;
        }

    }
}
