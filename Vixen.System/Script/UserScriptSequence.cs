﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Vixen.Script
{
    using Vixen.Sys;
    using Vixen.Module.CommandSpec;
    using System.Linq;
    using System;
    
    
    #line 1 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class UserScriptSequence : UserScriptSequenceBase
    {
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
        public virtual string TransformText()
        {
            this.GenerationEnvironment = null;
            this.Write(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Dynamic;
using Vixen.Sys;
using Vixen.Common;
using Vixen.Module.Sequence;
using Vixen.Script;
using CommandStandard;

namespace ");
            
            #line 20 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(" \r\n{\r\n\tpublic partial class ");
            
            #line 22 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : UserScriptHost {\r\n\t\tprivate UserScriptFixture[] _fixtures;\r\n\t\t// Command name " +
                    ": command spec type id\r\n\t\tprivate Dictionary<string, Guid> _commands = new Dicti" +
                    "onary<string, Guid>();\r\n\r\n\t\tpublic ");
            
            #line 27 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("() {\r\n\t\t\t// Need to copy the command dictionary made in code, but in such a way t" +
                    "hat\r\n\t\t\t// it can be built when this is executing..\r\n");
            
            #line 30 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"

	ICommandSpecModuleInstance commandSpec;
	foreach(string commandName in _commands.Keys) {
		commandSpec = _commands[commandName];

            
            #line default
            #line hidden
            this.Write("\t\t\t_commands[\"");
            
            #line 35 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandName));
            
            #line default
            #line hidden
            this.Write("\"] = new Guid(\"");
            
            #line 35 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_commands[commandName].TypeId));
            
            #line default
            #line hidden
            this.Write("\");\r\n");
            
            #line 36 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"		
		}

		override public ScriptSequenceBase Sequence { 
			get { return base.Sequence; }
			set {
				base.Sequence = value;
				_fixtures =
					value.Fixtures.Select(x => new UserScriptFixture(x)).ToArray();
			}
		}

		// Arg 0: IEnumerable<UserScriptChannel>
		// Arg 1: int startTime
		// Arg 2: int timeSpan
		// Arg 3: Start of command-specific parameters
		protected void _InvokeCommand(string commandName, params object[] args) {
			Guid commandSpecId;
			if(_commands.TryGetValue(commandName, out commandSpecId)) {
				if(args.Length < 3) throw new ArgumentException(""Invalid parameter count to invoke a command."");
				// Argument 1: IEnumerable<UserScriptChannel>
				IEnumerable<UserScriptChannel> channels = args[0] as IEnumerable<UserScriptChannel>;
				if(channels == null) throw new ArgumentException(""First parameter must be a channel collection."");
				// Argument 2: int (start time)
				int startTime = (int)args[1];
				// Argument 3: int (time span)
				int timeSpan = (int)args[2];
				
				Sequence.InsertData(channels.Select(x => x.Channel).ToArray() , startTime, timeSpan, new Command(commandSpecId, args.Skip(3).ToArray()));
			}
		}

");
            
            #line 68 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"

	foreach(string commandName in _commands.Keys) {
		commandSpec = _commands[commandName];
		string commandParameters =
			string.Join(", ",
			(from parameter in commandSpec.Parameters
			select parameter.ToString()).ToArray());
		string parameterNames =
			string.Join(", ",
			(from parameter in commandSpec.Parameters
			select parameter.Name).ToArray());

            
            #line default
            #line hidden
            this.Write("\t\t// Original name: ");
            
            #line 80 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandSpec.CommandName));
            
            #line default
            #line hidden
            this.Write("\r\n\t\tpublic void ");
            
            #line 81 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandName));
            
            #line default
            #line hidden
            this.Write("(IEnumerable<UserScriptChannel> channels, int startTime, int timeSpan, ");
            
            #line 81 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandParameters));
            
            #line default
            #line hidden
            this.Write(") {\r\n\t\t\t_InvokeCommand(\"");
            
            #line 82 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandName));
            
            #line default
            #line hidden
            this.Write("\", channels, startTime, timeSpan, ");
            
            #line 82 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(parameterNames));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t}\r\n\r\n\t\tpublic void ");
            
            #line 85 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandName));
            
            #line default
            #line hidden
            this.Write("(IEnumerable<UserScriptChannel> channels, int timeSpan, ");
            
            #line 85 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandParameters));
            
            #line default
            #line hidden
            this.Write(") {\r\n\t\t\t_InvokeCommand(\"");
            
            #line 86 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandName));
            
            #line default
            #line hidden
            this.Write("\", channels, 0, timeSpan, ");
            
            #line 86 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(parameterNames));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t}\r\n\r\n");
            
            #line 89 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
 } 
            
            #line default
            #line hidden
            
            #line 90 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
 Fixture[] fixtures = _sequence.Fixtures.ToArray();
	for(int i=0; i < fixtures.Length; i++) { 
            
            #line default
            #line hidden
            this.Write("\t\t// Original name: ");
            
            #line 92 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(fixtures[i].Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\tpublic dynamic ");
            
            #line 93 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ScriptHostGenerator.Mangle(fixtures[i].Name)));
            
            #line default
            #line hidden
            this.Write(" { \r\n\t\t\tget { return _fixtures[");
            
            #line 94 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i));
            
            #line default
            #line hidden
            this.Write("]; }\r\n\t\t}\r\n");
            
            #line 96 "C:\Users\Development\Documents\Visual Studio 2010\Projects\Vixen\2011\Vixen.System\Script\UserScriptSequence.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t}\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class UserScriptSequenceBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
    }
    #endregion
}