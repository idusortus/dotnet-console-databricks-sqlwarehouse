# Use .Net to Consume data from Azure DataBricks SQL Warehouse 

## Hello World
```csharp
using System.Data.Odbc;
//Driver=<path-to-driver>;Host=<server-hostname>;Port=443;HTTPPath=<http-path>;ThriftTransport=2;SSL=1;AuthMech=3;UID=token;PWD=<personal-access-token>
string bricksConnectionString="Driver={Simba Spark ODBC Driver};Host=adb-436423333334855.15.azuredatabricks.net;Port=443;HTTPPath=sql/protocolv1/o/234456634855/1111-3456-jdcbhj2;ThriftTransport=2;SSL=1;AuthMech=3;UID=token;PWD=dapi......";

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
```

## ODBC Driver
- Download [From Here](https://www.databricks.com/spark/odbc-drivers-download) && Install
- Run ODBC Data Sources (64-bit) and add a new User DSN > Select Simba Spark ODBC Driver
  - See [this post](https://stackoverflow.com/questions/75586420/connecting-to-azure-databricks-from-asp-net-using-odbc-driver) or [this one](https://stackoverflow.com/questions/77477103/ow-to-properly-connect-to-azure-databricks-warehouse-from-c-sharp-net-using-jdb) for additional details
  - For an Azure - Databricks - SQL Warehouse setup, the 'HTTP path', server name, port, and other info can be found from within the Databricks workspace > SQL Warehouses > Select Warehouse > Connection Details

## VSC Extensions
> These aren't necessary to run the code, but they are helpful for development
- Databricks
- SQLTools
  - Databricks ODBC Driver
