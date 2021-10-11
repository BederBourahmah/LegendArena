using LegendArena.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendArena.DataAccess
{
  public class LegendArenaSqlConnectionProvider : IDisposable
  {
    public LegendArenaSqlConnectionProvider(ConnectionStringsConfiguration connectionStrings)
    {
      _connection = new(connectionStrings.LegendArenaConnectionString);
    }

    private readonly SqlConnection _connection;

    public SqlConnection GetSqlConnection()
    {
      if (_connection.State != ConnectionState.Open)
        _connection.Open();

      return _connection;
    }

    public async ValueTask DisposeAsync()
    {
      if (_connection.State != ConnectionState.Closed)
        await _connection.CloseAsync();

      await _connection.DisposeAsync();
    }
    public void Dispose()
    {
      if (_connection.State != ConnectionState.Closed)
        _connection.Close();

      _connection.Dispose();
    }

  }
}
