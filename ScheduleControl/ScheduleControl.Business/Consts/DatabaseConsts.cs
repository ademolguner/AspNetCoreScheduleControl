namespace ScheduleControl.Business.Consts
{
    public static class DatabaseConsts
    {
        public static string BackupCommandText = @"BACKUP DATABASE [{0}] TO DISK = N'{1}' WITH NOFORMAT, INIT, NAME = N'{2}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

        public static string RestoreCommandText = @"USE [master];
    ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    RESTORE DATABASE [{1}] FROM DISK = N'{2}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5;
    ALTER DATABASE [{3}] SET MULTI_USER;";
    }
}