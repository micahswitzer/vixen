﻿using System.Collections.Generic;
using System.Linq;

namespace Vixen.Sys {
	public class IntentChangeCollection {
		public IntentChangeCollection(IEnumerable<IIntent> addedIntents, IEnumerable<IIntent> removedIntents) {
			AddedIntents = addedIntents.ToArray();
			RemovedIntents = removedIntents.ToArray();
		}

		public IIntent[] AddedIntents { get; private set; }

		public IIntent[] RemovedIntents { get; private set; }
	}
}
