﻿using System;
using System.Collections.Generic;
using System.Text;
using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Models
{
  public  class Currency:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}