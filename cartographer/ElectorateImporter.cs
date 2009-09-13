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
            //do shit nau

            return false;
        }

        protected bool ParseLineMIF()
        {
            return false;
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
            Console.Out.WriteLine(ds.Tables[0].Rows[0].ToString());
            
            


          
            return false;
        }

        protected bool ParseLineXLS()
        {
            return false;
        }

    }
}
