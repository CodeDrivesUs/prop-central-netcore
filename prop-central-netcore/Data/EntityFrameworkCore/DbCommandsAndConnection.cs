using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;
using prop_central_netcore.Shared.Configuration;

namespace prop_central_netcore.Data.EntityFrameworkCore
{
    public static class DbCommandsAndConnection
    {
        public static async Task<DbCommand> CreateCommandAsync( string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = new SqlConnection(AppSettings.DbConnectionString).CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            await command.Connection.OpenAsync();
            //    command.Transaction = new ApplicationDbContext().Database.CurrentTransaction?.GetDbTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

      
    }
}

