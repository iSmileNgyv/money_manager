using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MoneyManager.Application.Services.Log;

namespace MoneyManager.Persistence.Interceptors;

public class EfCoreLogInterceptor(
    ILogService logService
    ): DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        LogSqlQuery(command);
        return base.ReaderExecuting(command, eventData, result);
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        LogSqlQuery(command);
        return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    }

    private void LogSqlQuery(DbCommand command)
    {
        string sql = command.CommandText;
        List<string> parameters = command.Parameters
            .Cast<DbParameter>()
            .Select(p => $"{p.ParameterName}: {p.Value}")
            .ToList();

        logService.LogInformation("EF Core SQL Query", new
        {
            Query = sql,
            Parameters = parameters
        });
    }
}