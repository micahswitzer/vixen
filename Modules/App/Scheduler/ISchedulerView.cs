﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VixenModules.App.Scheduler {
	interface ISchedulerView {
		ObservableList<IScheduleItem> Items { get; set; }
	}
}