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
 * Tue Jul 05 15:48:30 Paris, Madrid 2005
 *
 *****************************************************************************/

namespace Mono.Cecil.Binary {

	public sealed class Section : IHeader, IBinaryVisitable {

		public uint VirtualSize;
		public RVA VirtualAddress;
		public uint SizeOfRawData;
		public RVA PointerToRawData;
		public RVA PointerToRelocations;
		public RVA PointerToLineNumbers;
		public ushort NumberOfRelocations;
		public ushort NumberOfLineNumbers;
		public SectionCharacteristics Characteristics;

		public string Name;

		internal Section ()
		{
		}

		public void SetDefaultValues ()
		{
			PointerToLineNumbers = RVA.Zero;
			NumberOfLineNumbers = 0;
		}

		public void Accept (IBinaryVisitor visitor)
		{
			visitor.Visit (this);
		}
	}
}
