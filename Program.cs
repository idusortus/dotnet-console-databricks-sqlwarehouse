using System.Data.Odbc;
// Driver={Simba Spark ODBC Driver};Host=adb-436423333334855.15.azuredatabricks.net;Port=443;HTTPPath=sql/protocolv1/o/234456634855/1111-3456-jdcbhj2;ThriftTransport=2;SSL=1;AuthMech=3;UID=token;PWD=dapi......"
string bricksConnectionString = "Driver={Simba Spark ODBC Driver};Host=adb-3088888491264717.17.azuredatabricks.net;Port=443;HTTPPath=/sql/1.0/warehouses/9b10a556d0972e95;ThriftTransport=2;SSL=1;AuthMech=3;UID=token;PWD=dapieb863eb9e395bd753a7357ee7dc92859-2";

using (OdbcConnection connection = new OdbcConnection(bricksConnectionString))
{
    try {
        connection.Open();
        Console.WriteLine("Connected to Azure SQL Data Warehouse.");
        string sqlQuery = "SELECT * FROM dev.matchhub.uuid_users limit 10;";
        using (OdbcCommand command = new OdbcCommand(sqlQuery, connection))
        {
            using (OdbcDataReader reader = command.ExecuteReader())
                while (reader.Read())
                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
        }
    } catch (Exception ex)
        { Console.WriteLine($"Error: {ex.Message}"); }
}