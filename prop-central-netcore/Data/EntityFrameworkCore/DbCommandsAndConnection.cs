using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace prop_central_netcore.Data.EntityFrameworkCore
{
    public static class DbCommandsAndConnection
    {
        private static string DefaultConnection = "Server=sql.bsite.net\\MSSQL2016;Initial Catalog=democodedrivesus_main;User ID=democodedrivesus_main;Password=Zweli@1;Encrypt=True;TrustServerCertificate=True;";

        public static async Task<DbCommand> CreateCommandAsync( string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = new SqlConnection(DefaultConnection).CreateCommand();
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

