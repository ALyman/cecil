/*
 * Copyright (c) 2004, 2005 DotNetGuru and the individuals listed
 * on the ChangeLog entries.
 *
 * Authors :
 *   Jb Evain   (jbevain@gmail.com)
 *
 * This is a free software distributed under a MIT/X11 license
 * See LICENSE.MIT file for more details
 *
 * Generated by /CodeGen/cecil-gen.rb do not edit
 * Sun Aug 28 03:04:17 CEST 2005
 *
 *****************************************************************************/

namespace Mono.Cecil.Implem {

	using System;
	using System.Collections;

	using Mono.Cecil;
	using Mono.Cecil.Cil;

	internal class OverrideCollection : IOverrideCollection {

		private IList m_items;
		private MethodDefinition m_container;

		public event OverrideEventHandler OnOverrideAdded;
		public event OverrideEventHandler OnOverrideRemoved;

		public IMethodReference this [int index] {
			get { return m_items [index] as IMethodReference; }
			set { m_items [index] = value; }
		}

		public IMethodDefinition Container {
			get { return m_container; }
		}

		public int Count {
			get { return m_items.Count; }
		}

		public bool IsSynchronized {
			get { return false; }
		}

		public object SyncRoot {
			get { return this; }
		}

		public OverrideCollection (MethodDefinition container)
		{
			m_container = container;
			m_items = new ArrayList ();
		}

		public void Add (IMethodReference value)
		{
			if (OnOverrideAdded != null && !this.Contains (value))
				OnOverrideAdded (this, new OverrideEventArgs (value));
			m_items.Add (value);
		}

		public void Clear ()
		{
			if (OnOverrideRemoved != null)
				foreach (IMethodReference item in this)
					OnOverrideRemoved (this, new OverrideEventArgs (item));
			m_items.Clear ();
		}

		public bool Contains (IMethodReference value)
		{
			return m_items.Contains (value);
		}

		public int IndexOf (IMethodReference value)
		{
			return m_items.IndexOf (value);
		}

		public void Insert (int index, IMethodReference value)
		{
			if (OnOverrideAdded != null && !this.Contains (value))
				OnOverrideAdded (this, new OverrideEventArgs (value));
			m_items.Insert (index, value);
		}

		public void Remove (IMethodReference value)
		{
			if (OnOverrideRemoved != null && this.Contains (value))
				OnOverrideRemoved (this, new OverrideEventArgs (value));
			m_items.Remove (value);
		}

		public void RemoveAt (int index)
		{
			if (OnOverrideRemoved != null)
				OnOverrideRemoved (this, new OverrideEventArgs (this [index]));
			m_items.Remove (index);
		}

		public void CopyTo (Array ary, int index)
		{
			m_items.CopyTo (ary, index);
		}

		public IEnumerator GetEnumerator ()
		{
			return m_items.GetEnumerator ();
		}

		public void Accept (IReflectionVisitor visitor)
		{
			visitor.VisitOverrideCollection (this);
		}
	}
}
