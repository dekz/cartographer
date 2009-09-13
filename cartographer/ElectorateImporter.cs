using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
        }

        protected bool ParseLineMID(string line)
        {
            string lineSoFar = "";
            string[] electorateData = new string[9];
            int electorateDataPosition = 0;
            //id,"electoratename",numccds,actual,projected,totalpop,over18,area,"name"
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] = ",")
                {
                    electorateData[electorateDataPosition] = lineSoFar;
                    lineSoFar = "";
                    electorateDataPosition++;
                }
                else if (line[i] = "\"") { /*ignore*/ }
                else
                {
                    lineSoFar += line[i];
                }
            }
            electorateData[electorateDataPosition] = lineSoFar;
            Electorate electorate;
            electorate.ID = int.Parse(electorateData[0]);
            electorate.Name = electorateData[1];
            //numccds???????????
            electorate.Actual = electorateData[3];
            electorate.Projected = electorateData[4];
            electorate.TotalPopulation = electorateData[5];
            electorate.Over18 = electorateData[6];
            electorate.Area = electorateData[7];
            m_ElectorateDataMID.Add(electorate);
            return true;
        }

        public bool ParseMIF()
        {

        }

        protected bool ParseLineMIF()
        {

        }

        //STAGE TWO
        public bool ParseXLS()
        {
           string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                                      Data Source=\data\Qld_FederalResults by Electorate-2004.xls;Extended Properties=
                                      ""Excel 8.0;HDR=YES;""";

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");

            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

            using (DbCommand command = connection.CreateCommand())
            {
                // Cities$ comes from the name of the worksheet
                command.CommandText = "SELECT ID,City,State FROM [Cities$]";

                connection.Open();

                using (DbDataReader dr = command.ExecuteReader())
                  {
                     while (dr.Read())
                      {
                         Debug.WriteLine(dr["ID"].ToString());
                      }
                  }
    }
}


            

        }

        protected bool ParseLineXLS()
        {

        }

    }
}
