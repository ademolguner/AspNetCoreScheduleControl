using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleControl.Business.Abstract.DatabaseOperation
{
  public   interface IDatabaseOptionService
  {
      Task BackupDatabase();
      Task RestoreDatabase();
    }
}
