using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ScheduleControl.Business.Abstract.DatabaseOperation;
using ScheduleControl.Business.Consts;
using ScheduleControl.Entities.Dtos.Database;

namespace ScheduleControl.Business.Concrete.Managers.DatabaseOperation
{
    public class DatabaseOptionManager : IDatabaseOptionService
    {
        private readonly DatabaseOptionDto _databaseOptionDto;
        public DatabaseOptionManager(IOptions<DatabaseOptionDto> options)
        {
            _databaseOptionDto = options.Value;
        }
        public async Task BackupDatabase()
        {
            //string commandText = $@"BACKUP DATABASE [{databaseName}] TO DISK = N'{backupPath}' WITH NOFORMAT, INIT, NAME = N'{databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            string commandText = string.Format(DatabaseConsts.BackupCommandText, _databaseOptionDto.DatabaseName, _databaseOptionDto.BackupPath, _databaseOptionDto.DatabaseName);
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = _databaseOptionDto.ServerName,
                InitialCatalog = _databaseOptionDto.DatabaseName,
                IntegratedSecurity = _databaseOptionDto.IntegratedSecurity
            };
            await using SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
            connection.InfoMessage += Connection_InfoMessage;
            await using SqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            await command.ExecuteNonQueryAsync();
        }

        public async Task RestoreDatabase()
        {
    //        string commandText = $@"USE [master];
    //ALTER DATABASE [{_databaseOptionDto.DatabaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    //RESTORE DATABASE [{_databaseOptionDto.DatabaseName}] FROM DISK = N'{_databaseOptionDto.RestorePath}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5;
    //ALTER DATABASE [{_databaseOptionDto.DatabaseName}] SET MULTI_USER;";

            string commandText = string.Format(DatabaseConsts.RestoreCommandText, _databaseOptionDto.DatabaseName, _databaseOptionDto.RestorePath, _databaseOptionDto.DatabaseName, _databaseOptionDto.DatabaseName);  
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = _databaseOptionDto.ServerName,
                InitialCatalog = _databaseOptionDto.DatabaseName,
                IntegratedSecurity = _databaseOptionDto.IntegratedSecurity
            };
            await using SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
            connection.InfoMessage += Connection_InfoMessage;
            await using SqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            await command.ExecuteNonQueryAsync();
        }
        private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
