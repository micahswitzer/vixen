﻿using System.Collections.Generic;
using Vixen.Commands;
using Vixen.Data.Policy;
using Vixen.Module.OutputFilter;

namespace Vixen.Sys.Output {
	public class CommandOutput : Output, IHasOutputFilters {
		private OutputFilterCollection _filters;
		private ICommand _command;

		public CommandOutput() {
			_filters = new OutputFilterCollection();
		}

		public ICommand Command {
			get { return _command; }
			set {
				if(!Equals(_command, value)) {
					_command = value;
				}
			}
		}

		public void AddOutputFilter(IOutputFilterModuleInstance module) {
			_filters.Add(module);
		}

		public void InsertOutputFilter(int index, IOutputFilterModuleInstance module) {
			_filters.Insert(index, module);
		}

		public void RemoveOutputFilter(IOutputFilterModuleInstance module) {
			_filters.Remove(module);
		}

		public void RemoveOutputFilterAt(int index) {
			_filters.RemoveAt(index);
		}

		public void ClearOutputFilters() {
			_filters.Clear();
		}

		// For the interface.
		public IEnumerable<IOutputFilterModuleInstance> GetAllOutputFilters() {
			return _filters;
		}

		// For the serializer
		public OutputFilterCollection OutputFilters {
			get { return _filters; }
		}

		public override void UpdateState() {
			State = new OutputIntentStateList(GetOutputStateData());
		}

		public void LogicalFiltering() {
			if(!VixenSystem.AllowFilterEvaluation) return;

			// Go through each intent value.
			for(int intentValueIndex = 0; intentValueIndex < State.Count; intentValueIndex++) {
				// And apply the output's filters to it.
				foreach(var outputFilter in OutputFilters) {
					State[intentValueIndex] = outputFilter.Affect(State[intentValueIndex]);
					if(State[intentValueIndex] == null) break;
				}
			}
		}

		public void PhysicalFiltering() {
			// No physical filters yet.
		}

		//*** Not yet any way to set this for an output.
		//    It is intended to allow an output to override the controller's data policy.
		public OutputDataPolicy DataPolicy { get; set; }
	}
}
