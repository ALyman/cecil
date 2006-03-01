//
// Unit tests for IDisposableWithDestructorWithoutSuppressFinalizeRule
//
// Authors:
//	Sebastien Pouliot <sebastien@ximian.com>
//
// Copyright (C) 2005-2006 Novell, Inc (http://www.novell.com)
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
using System.Reflection;

using Gendarme.Framework;
using Gendarme.Rules.Performance;
using Mono.Cecil;
using NUnit.Framework;

namespace Test.Rules.Performance {

	[TestFixture]
	public class IDisposableWithDestructorWithoutSuppressFinalizeTest {

		class NoDestructorClass {
		}

		class DestructorClass {

			IntPtr ptr;

			public DestructorClass ()
			{
				ptr = (IntPtr) 1;
			}

			~DestructorClass ()
			{
				ptr = IntPtr.Zero;
			}
		}

		class IDisposableNoDestructorWithoutSuppressFinalizeClass: IDisposable {

			public void Dispose ()
			{
			}
		}

		class IDisposableNoDestructorWithSuppressFinalizeClass: IDisposable {

			public void Dispose ()
			{
				GC.SuppressFinalize (this);
			}
		}

		class IDisposableDestructorWithoutSuppressFinalizeClass: IDisposable {

			~IDisposableDestructorWithoutSuppressFinalizeClass ()
			{
			}

			public void Dispose ()
			{
			}
		}

		class IDisposableDestructorWithSuppressFinalizeClass: IDisposable {

			~IDisposableDestructorWithSuppressFinalizeClass ()
			{
			}

			public void Dispose ()
			{
				GC.SuppressFinalize (this);
			}
		}

		class ExplicitIDisposableDestructorWithoutSuppressFinalizeClass: IDisposable {

			~ExplicitIDisposableDestructorWithoutSuppressFinalizeClass ()
			{
			}

			void IDisposable.Dispose ()
			{
			}
		}

		class ExplicitIDisposableDestructorWithSuppressFinalizeClass: IDisposable {

			~ExplicitIDisposableDestructorWithSuppressFinalizeClass ()
			{
			}

			void IDisposable.Dispose ()
			{
				GC.SuppressFinalize (this);
			}
		}

		private ITypeRule rule;
		private IAssemblyDefinition assembly;
		private IModuleDefinition module;

		[TestFixtureSetUp]
		public void FixtureSetUp ()
		{
			string unit = Assembly.GetExecutingAssembly ().Location;
			assembly = AssemblyFactory.GetAssembly (unit);
			module = assembly.MainModule;
			rule = new IDisposableWithDestructorWithoutSuppressFinalizeRule ();
		}

		private ITypeDefinition GetTest (string name)
		{
			string fullname = "Test.Rules.Performance.IDisposableWithDestructorWithoutSuppressFinalizeTest/" + name;
			return assembly.MainModule.Types[fullname];
		}

		[Test]
		public void NoDestructor ()
		{
			ITypeDefinition type = GetTest ("NoDestructorClass");
			Assert.IsNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}

		[Test]
		public void Destructor ()
		{
			ITypeDefinition type = GetTest ("DestructorClass");
			Assert.IsNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}

		[Test]
		public void IDisposableNoDestructorWithoutSuppressFinalize ()
		{
			ITypeDefinition type = GetTest ("IDisposableNoDestructorWithoutSuppressFinalizeClass");
			Assert.IsNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}

		[Test]
		public void IDisposableNoDestructorWithSuppressFinalize ()
		{
			ITypeDefinition type = GetTest ("IDisposableNoDestructorWithSuppressFinalizeClass");
			Assert.IsNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}

		[Test]
		public void IDisposableDestructorWithoutSuppressFinalize ()
		{
			ITypeDefinition type = GetTest ("IDisposableDestructorWithoutSuppressFinalizeClass");
			Assert.IsNotNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}

		[Test]
		public void IDisposableDestructorWithSuppressFinalize ()
		{
			ITypeDefinition type = GetTest ("IDisposableDestructorWithSuppressFinalizeClass");
			Assert.IsNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}

		[Test]
		public void ExplicitIDisposableDestructorWithoutSuppressFinalize ()
		{
			ITypeDefinition type = GetTest ("ExplicitIDisposableDestructorWithoutSuppressFinalizeClass");
			Assert.IsNotNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}

		[Test]
		public void ExplicitIDisposableDestructorWithSuppressFinalize ()
		{
			ITypeDefinition type = GetTest ("ExplicitIDisposableDestructorWithSuppressFinalizeClass");
			Assert.IsNull (rule.CheckType (assembly, module, type, new MinimalRunner()));
		}
	}
}
