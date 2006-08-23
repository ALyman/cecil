//
// Gendarme.Rules.Performance.UseStringEmpty
//
// Authors:
//	Sebastien Pouliot <sebastien@ximian.com>
//
// Copyright (C) 2006 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Globalization;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Gendarme.Framework;

namespace Gendarme.Rules.Performance {

	public class UseStringEmptyRule : IMethodRule {
	
		public IList CheckMethod (IAssemblyDefinition assembly, IModuleDefinition module, ITypeDefinition type, IMethodDefinition method, Runner runner)
		{
			// #1 - rule apply only if the method has a body (e.g. p/invokes, icalls don't)
			if (method.Body == null)
				return runner.RuleSuccess;

			// *** ok, the rule applies! ***
			
			int empty = 0;

			// #2 - look for string references
			foreach (IInstruction ins in method.Body.Instructions) {
				switch (ins.OpCode.OperandType) {
				case OperandType.InlineString:
					string s = (ins.Operand as string);
					if (s.Length == 0)
						empty++;
					break;
				}
			}
			
			if (empty == 0)
				return null;

			ArrayList results = new ArrayList (1);
			results.Add (String.Format ("{0} instance of an empty string has been found.", empty));
			return results;
		}
	}
}