using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LegendArena.DataAccess
{
  public class PlayerAccessor
  {
    private readonly SqlConnection _sqlConnection;
    public PlayerAccessor(LegendArenaSqlConnectionProvider legendArenaSqlConnectionProvider)
    {
      _sqlConnection = legendArenaSqlConnectionProvider.GetSqlConnection();
    }

    public async Task CreatePlayerAsync(Guid guid)
    {
      await _sqlConnection.ExecuteAsync(sql: "[dbo].[sp_CreatePlayer]",
                                        param: new { guid },
                                        commandType: CommandType.StoredProcedure);
    }
  }
}
