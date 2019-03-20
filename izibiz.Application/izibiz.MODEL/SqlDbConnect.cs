using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace izibiz.MODEL
{
  public  class SqlDbConnect
    {
        private SQLiteConnection connection;
        public SQLiteCommand cmd;
        private SQLiteDataAdapter da;
        private DataTable dt;



        public SqlDbConnect()
        {
       
            connection = new SQLiteConnection(@"Data Source=C:\Users\gamze.sahin\Desktop\ws-client-dotnet\izibiz.Application\izibiz.MODEL\izibiz-Entegrasyon.s3db;Version=3;");
            connection.Open();
        }



        public void sqlQuery(string queryText)
        {
            cmd = new SQLiteCommand(queryText, connection);
        }


/*
        public void addParametersInvoice(string id, string uuid, DateTime issueDate, string profileid, string type, string supplier, string sender, DateTime cDate,
            string envelopeIdentifier, string status, int gibStatusCode,string gibSatusDescription, string from, string to)
        {
            cmd.Parameters.AddWithValue("@ID",id);
            cmd.Parameters.AddWithValue("@uuid",uuid);
            cmd.Parameters.AddWithValue("@issueDate", issueDate);
            cmd.Parameters.AddWithValue("@profileid", profileid);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@supplier", supplier);
            cmd.Parameters.AddWithValue("@sender", sender);
            cmd.Parameters.AddWithValue("@cDate", cDate);
            cmd.Parameters.AddWithValue("@envelopeIdentifier", envelopeIdentifier);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@gibStatusCode", gibStatusCode);
            cmd.Parameters.AddWithValue("@gibSatusDescription", gibSatusDescription);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
        }
        */



        public DataTable queryEx()
        {
            da = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public  void nonQueryEx()
        {
            cmd.ExecuteNonQuery();
        }


      








    }
}
