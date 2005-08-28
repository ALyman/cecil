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

	internal class SecurityDeclarationCollection : ISecurityDeclarationCollection {

		private IList m_items;
		private IHasSecurity m_container;

		public event SecurityDeclarationEventHandler OnSecurityDeclarationAdded;
		public event SecurityDeclarationEventHandler OnSecurityDeclarationRemoved;

		public ISecurityDeclaration this [int index] {
			get { return m_items [index] as ISecurityDeclaration; }
			set { m_items [index] = value; }
		}

		public IHasSecurity Container {
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

		public SecurityDeclarationCollection (IHasSecurity container)
		{
			m_container = container;
			m_items = new ArrayList ();
		}

		public void Add (ISecurityDeclaration value)
		{
			if (OnSecurityDeclarationAdded != null && !this.Contains (value))
				OnSecurityDeclarationAdded (this, new SecurityDeclarationEventArgs (value));
			m_items.Add (value);
		}

		public void Clear ()
		{
			if (OnSecurityDeclarationRemoved != null)
				foreach (ISecurityDeclaration item in this)
					OnSecurityDeclarationRemoved (this, new SecurityDeclarationEventArgs (item));
			m_items.Clear ();
		}

		public bool Contains (ISecurityDeclaration value)
		{
			return m_items.Contains (value);
		}

		public int IndexOf (ISecurityDeclaration value)
		{
			return m_items.IndexOf (value);
		}

		public void Insert (int index, ISecurityDeclaration value)
		{
			if (OnSecurityDeclarationAdded != null && !this.Contains (value))
				OnSecurityDeclarationAdded (this, new SecurityDeclarationEventArgs (value));
			m_items.Insert (index, value);
		}

		public void Remove (ISecurityDeclaration value)
		{
			if (OnSecurityDeclarationRemoved != null && this.Contains (value))
				OnSecurityDeclarationRemoved (this, new SecurityDeclarationEventArgs (value));
			m_items.Remove (value);
		}

		public void RemoveAt (int index)
		{
			if (OnSecurityDeclarationRemoved != null)
				OnSecurityDeclarationRemoved (this, new SecurityDeclarationEventArgs (this [index]));
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
			visitor.VisitSecurityDeclarationCollection (this);
		}
	}
}
