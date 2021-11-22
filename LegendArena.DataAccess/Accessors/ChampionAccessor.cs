using Dapper;
using LegendArena.Models.DatabaseModels;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LegendArena.Models;
using LegendArena.Models.Extensions;
using System.Linq;
using System;

namespace LegendArena.DataAccess
{
  public class ChampionAccessor
  {
    private readonly SqlConnection _sqlConnection;
    public ChampionAccessor(LegendArenaSqlConnectionProvider legendArenaSqlConnectionProvider)
    {
      _sqlConnection = legendArenaSqlConnectionProvider.GetSqlConnection();
    }

    public async Task<Champion[]> GetChampionsByPlayerIdAsync(Guid guid)
    {
      var sqlChampions = await _sqlConnection.QueryAsync<SqlChampion>(sql: "[dbo].[GetChampionsByPlayerGuid]", param: new { guid }, commandType: CommandType.StoredProcedure);
      return sqlChampions.Select(champ => champ.ToChampion()).ToArray();
    }
  }
}
