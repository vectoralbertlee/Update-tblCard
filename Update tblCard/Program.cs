using System;
using System.Data.SqlClient;

namespace Update_tblCard
{
    class Program
    {
        static void Main(string[] args)
        {
            String cardNum = "00000050324582";
            String cardHexValue = "";
            String connectionString = "";
            String queryTblCardAntipassback = "";
            String queryUpdateTblCardAntipassbackToN = "";
            String queryUpdateTblCardAntipassbackToY = "";
            String inputKey = "";
            //            connectionString =
            //"Data Source=ServerName;" +
            //"Initial Catalog=DataBaseName;" +
            //"User id=UserName;" +
            //"Password=Secret;";

            connectionString =
            "Data Source=.;" +
            "Initial Catalog=PARKSYS2;" +
            "Integrated Security=SSPI;";

            queryTblCardAntipassback = "select antipassback from tblCard where CardNum like @cardNum or CardHexValue like @cardHexValue";
            queryUpdateTblCardAntipassbackToN = "update tblCard set antipassback = 'N' where CardNum like @cardNum or CardHexValue like @cardHexValue";
            queryUpdateTblCardAntipassbackToY = "update tblCard set antipassback = 'Y' where CardNum like @cardNum or CardHexValue like @cardHexValue";
            Console.WriteLine(String.Format("Woring on Card : {0}, Hex :{1}", cardNum, cardHexValue));
            Console.WriteLine("1 for Retrieve antipassback\n2 for Update antipassback to N\n3 for update antipassback to Y");
            while (true)
            {
                inputKey = Console.ReadLine();


                if (inputKey.Contains("1"))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        SqlCommand command = new SqlCommand(queryTblCardAntipassback, conn);
                        command.Parameters.AddWithValue("@cardNum", cardNum);
                        command.Parameters.AddWithValue("@cardHexValue", cardHexValue);
                        conn.Open();

                        string getValue = command.ExecuteScalar().ToString();

                        Console.WriteLine(String.Format("Antipassback = {0}", getValue));
                        
                    }
                } else if (inputKey.Contains("2"))
                {

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        SqlCommand command = new SqlCommand(queryUpdateTblCardAntipassbackToN, conn);
                        command.Parameters.AddWithValue("@cardNum", cardNum);
                        command.Parameters.AddWithValue("@cardHexValue", cardHexValue);
                        conn.Open();
                        int iRet = command.ExecuteNonQuery();

                        if( iRet != -1)
                        {
                            Console.WriteLine("Done.");
                        } else
                        {
                            Console.WriteLine("Something is wrong." + iRet.ToString());
                        }
                        
                    }

                }
                else if (inputKey.Contains("3"))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(queryUpdateTblCardAntipassbackToY, conn);
                        command.Parameters.AddWithValue("@cardNum", cardNum);
                        command.Parameters.AddWithValue("@cardHexValue", cardHexValue);
                        conn.Open();
                        int iRet = command.ExecuteNonQuery();

                        if (iRet != -1 )
                        {
                            Console.WriteLine("Done.");
                        }
                        else
                        {
                            Console.WriteLine("Something is wrong." + iRet.ToString());
                        }
                    }
                }
                else
                {
                    break;
                }

                Console.WriteLine("1 for Retrieve antipassback\n2 for Update antipassback to N\n3 for update antipassback to Y");
            }
        }

    }
}

