using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ScheduleControl.Business.Abstract.DatabaseOperation;
using ScheduleControl.Business.Consts;
using ScheduleControl.Entities.Dtos.Database;
using System.Data;
using System.Threading.Tasks;

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
            string commandText = string.Format(DatabaseConsts.BackupCommandText, _databaseOptionDto.DatabaseName, _databaseOptionDto.BackupPath, _databaseOptionDto.DatabaseName);
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = _databaseOptionDto.ServerName,
                InitialCatalog = _databaseOptionDto.DatabaseName,
                IntegratedSecurity = _databaseOptionDto.IntegratedSecurity
            };
            await using SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
            await using SqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            await command.ExecuteNonQueryAsync();
        }

        public async Task RestoreDatabase()
        {
            string commandText = string.Format(DatabaseConsts.RestoreCommandText,
                                                   _databaseOptionDto.DatabaseName,
                                                   _databaseOptionDto.DatabaseName,
                                                   _databaseOptionDto.RestorePath,
                                                   _databaseOptionDto.DatabaseName);
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = _databaseOptionDto.ServerName,
                InitialCatalog = _databaseOptionDto.DatabaseName,
                IntegratedSecurity = _databaseOptionDto.IntegratedSecurity
            };
            await using SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
            await using SqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            await command.ExecuteNonQueryAsync();
        }
    }
}