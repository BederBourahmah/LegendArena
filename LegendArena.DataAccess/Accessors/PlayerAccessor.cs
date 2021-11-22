using Dapper;
using LegendArena.Models.DatabaseModels;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LegendArena.Models;
using LegendArena.Models.Extensions;

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
      await _sqlConnection.ExecuteAsync(sql: "[dbo].[CreatePlayer]",
                                        param: new { guid },
                                        commandType: CommandType.StoredProcedure);
    }

    public async Task<Player> GetPlayerByGuidAsync(Guid guid)
    {
      var sqlPlayer = await _sqlConnection.QueryFirstOrDefaultAsync<SqlPlayer>(sql: "[dbo].[GetPlayerByGuid]", param: new { guid }, commandType: CommandType.StoredProcedure);
      return sqlPlayer?.ToPlayer();
    }
  }
}
