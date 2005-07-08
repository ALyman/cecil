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
 * Tue Jul 05 15:48:31 Paris, Madrid 2005
 *
 *****************************************************************************/

namespace Mono.Cecil.Metadata {

	using System;
	using System.Collections;
	using System.IO;

	using Mono.Cecil.Binary;

	internal sealed class MetadataRowReader : IMetadataRowVisitor {

		private MetadataTableReader m_mtrv;
		private BinaryReader m_binaryReader;
		private MetadataRoot m_metadataRoot;
		private IDictionary m_codedIndexCache;

		private int m_blobHeapIdxSz;
		private int m_stringsHeapIdxSz;
		private int m_guidHeapIdxSz;

		public MetadataRowReader (MetadataTableReader mtrv)
		{
			m_mtrv = mtrv;
			m_binaryReader = mtrv.GetReader ();
			m_metadataRoot = mtrv.GetMetadataRoot ();
			m_codedIndexCache = new Hashtable ();
		}

		private int GetIndexSize (Type table)
		{
			return m_mtrv.GetNumberOfRows (table) < (1 << 16) ? 2 : 4;
		}

		private int GetCodedIndexSize (CodedIndex ci)
		{
			int bits = 0, max = 0;
			if (m_codedIndexCache [ci] != null)
				return (int) m_codedIndexCache [ci];

			int res = 0;
			ArrayList tables = new ArrayList ();
			switch (ci) {
			case CodedIndex.TypeDefOrRef :
				bits = 2;
				tables.Add (typeof (TypeDefTable));
				tables.Add (typeof (TypeRefTable));
				tables.Add (typeof (TypeSpecTable));
				break;
			case CodedIndex.HasConstant :
				bits = 2;
				tables.Add (typeof (FieldTable));
				tables.Add (typeof (ParamTable));
				tables.Add (typeof (PropertyTable));
				break;
			case CodedIndex.HasCustomAttribute :
				bits = 5;
				tables.Add (typeof (MethodTable));
				tables.Add (typeof (FieldTable));
				tables.Add (typeof (TypeRefTable));
				tables.Add (typeof (TypeDefTable));
				tables.Add (typeof (ParamTable));
				tables.Add (typeof (InterfaceImplTable));
				tables.Add (typeof (MemberRefTable));
				tables.Add (typeof (ModuleTable));
				tables.Add (typeof (DeclSecurityTable));
				tables.Add (typeof (PropertyTable));
				tables.Add (typeof (EventTable));
				tables.Add (typeof (StandAloneSigTable));
				tables.Add (typeof (ModuleRefTable));
				tables.Add (typeof (TypeSpecTable));
				tables.Add (typeof (AssemblyTable));
				tables.Add (typeof (AssemblyRefTable));
				tables.Add (typeof (FileTable));
				tables.Add (typeof (ExportedTypeTable));
				tables.Add (typeof (ManifestResourceTable));
				break;
			case CodedIndex.HasFieldMarshal :
				bits = 1;
				tables.Add (typeof (FieldTable));
				tables.Add (typeof (ParamTable));
				break;
			case CodedIndex.HasDeclSecurity :
				bits = 2;
				tables.Add (typeof (TypeDefTable));
				tables.Add (typeof (MethodTable));
				tables.Add (typeof (AssemblyTable));
				break;
			case CodedIndex.MemberRefParent :
				bits = 3;
				tables.Add (typeof (TypeRefTable));
				tables.Add (typeof (ModuleRefTable));
				tables.Add (typeof (MethodTable));
				tables.Add (typeof (TypeSpecTable));
				break;
			case CodedIndex.HasSemantics :
				bits = 1;
				tables.Add (typeof (EventTable));
				tables.Add (typeof (PropertyTable));
				break;
			case CodedIndex.MethodDefOrRef :
				bits = 1;
				tables.Add (typeof (MethodTable));
				tables.Add (typeof (MemberRefTable));
				break;
			case CodedIndex.MemberForwarded :
				bits = 1;
				tables.Add (typeof (FieldTable));
				tables.Add (typeof (MethodTable));
				break;
			case CodedIndex.Implementation :
				bits = 2;
				tables.Add (typeof (FileTable));
				tables.Add (typeof (AssemblyRefTable));
				tables.Add (typeof (ExportedTypeTable));
				break;
			case CodedIndex.CustomAttributeType :
				bits = 3;
				tables.Add (typeof (MethodTable));
				tables.Add (typeof (MemberRefTable));
				break;
			case CodedIndex.ResolutionScope :
				bits = 2;
				tables.Add (typeof (ModuleTable));
				tables.Add (typeof (ModuleRefTable));
				tables.Add (typeof (AssemblyRefTable));
				tables.Add (typeof (TypeRefTable));
				break;
			case CodedIndex.TypeOrMethodDef :
				bits = 1;
				tables.Add (typeof (TypeDefTable));
				tables.Add (typeof (MethodTable));
				break;
		   }
			foreach (Type t in tables) {
				int rows = m_mtrv.GetNumberOfRows (t);
				if (rows > max) max = rows;
			}
			res = max < (1 << (16 - bits)) ? 2 : 4;
			m_codedIndexCache [ci] = res;
			return res;

		}

		private uint ReadByIndexSize (int size)
		{
			if (size == 2) {
				return (uint) m_binaryReader.ReadUInt16 ();
			} else if (size == 4) {
				return m_binaryReader.ReadUInt32 ();
			} else {
				throw new MetadataFormatException ("Non valid size for indexing");
			}
		}

		public void Visit (RowCollection coll)
		{
			m_blobHeapIdxSz = m_metadataRoot.Streams.BlobHeap != null ?
				m_metadataRoot.Streams.BlobHeap.IndexSize : 2;
			m_stringsHeapIdxSz = m_metadataRoot.Streams.StringsHeap != null ?
				m_metadataRoot.Streams.StringsHeap.IndexSize : 2;
			m_guidHeapIdxSz = m_metadataRoot.Streams.GuidHeap != null ?
				m_metadataRoot.Streams.GuidHeap.IndexSize : 2;
		}

		public void Visit (AssemblyRow row)
		{
			row.HashAlgId = (Mono.Cecil.AssemblyHashAlgorithm) m_binaryReader.ReadUInt32 ();
			row.MajorVersion = m_binaryReader.ReadUInt16 ();
			row.MinorVersion = m_binaryReader.ReadUInt16 ();
			row.BuildNumber = m_binaryReader.ReadUInt16 ();
			row.RevisionNumber = m_binaryReader.ReadUInt16 ();
			row.Flags = (Mono.Cecil.AssemblyFlags) m_binaryReader.ReadUInt32 ();
			row.PublicKey = ReadByIndexSize (m_blobHeapIdxSz);
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Culture = ReadByIndexSize (m_stringsHeapIdxSz);
		}

		public void Visit (AssemblyOSRow row)
		{
			row.OSPlatformID = m_binaryReader.ReadUInt32 ();
			row.OSMajorVersion = m_binaryReader.ReadUInt32 ();
			row.OSMinorVersion = m_binaryReader.ReadUInt32 ();
		}

		public void Visit (AssemblyProcessorRow row)
		{
			row.Processor = m_binaryReader.ReadUInt32 ();
		}

		public void Visit (AssemblyRefRow row)
		{
			row.MajorVersion = m_binaryReader.ReadUInt16 ();
			row.MinorVersion = m_binaryReader.ReadUInt16 ();
			row.BuildNumber = m_binaryReader.ReadUInt16 ();
			row.RevisionNumber = m_binaryReader.ReadUInt16 ();
			row.Flags = (Mono.Cecil.AssemblyFlags) m_binaryReader.ReadUInt32 ();
			row.PublicKeyOrToken = ReadByIndexSize (m_blobHeapIdxSz);
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Culture = ReadByIndexSize (m_stringsHeapIdxSz);
			row.HashValue = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (AssemblyRefOSRow row)
		{
			row.OSPlatformID = m_binaryReader.ReadUInt32 ();
			row.OSMajorVersion = m_binaryReader.ReadUInt32 ();
			row.OSMinorVersion = m_binaryReader.ReadUInt32 ();
			row.AssemblyRef = ReadByIndexSize (GetIndexSize (typeof (AssemblyRefTable)));
		}

		public void Visit (AssemblyRefProcessorRow row)
		{
			row.Processor = m_binaryReader.ReadUInt32 ();
			row.AssemblyRef = ReadByIndexSize (GetIndexSize (typeof (AssemblyRefTable)));
		}

		public void Visit (ClassLayoutRow row)
		{
			row.PackingSize = m_binaryReader.ReadUInt16 ();
			row.ClassSize = m_binaryReader.ReadUInt32 ();
			row.Parent = ReadByIndexSize (GetIndexSize (typeof (TypeDefTable)));
		}

		public void Visit (ConstantRow row)
		{
			row.Type = (Mono.Cecil.Metadata.ElementType) m_binaryReader.ReadUInt16 ();
			row.Parent = Utilities.GetMetadataToken (CodedIndex.HasConstant,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.HasConstant)));
			row.Value = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (CustomAttributeRow row)
		{
			row.Parent = Utilities.GetMetadataToken (CodedIndex.HasCustomAttribute,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.HasCustomAttribute)));
			row.Type = Utilities.GetMetadataToken (CodedIndex.CustomAttributeType,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.CustomAttributeType)));
			row.Value = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (DeclSecurityRow row)
		{
			row.Action = (Mono.Cecil.SecurityAction) m_binaryReader.ReadInt16 ();
			row.Parent = Utilities.GetMetadataToken (CodedIndex.HasDeclSecurity,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.HasDeclSecurity)));
			row.PermissionSet = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (EventMapRow row)
		{
			row.Parent = ReadByIndexSize (GetIndexSize (typeof (TypeDefTable)));
			row.EventList = ReadByIndexSize (GetIndexSize (typeof (EventTable)));
		}

		public void Visit (EventRow row)
		{
			row.EventFlags = (Mono.Cecil.EventAttributes) m_binaryReader.ReadUInt16 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.EventType = Utilities.GetMetadataToken (CodedIndex.TypeDefOrRef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.TypeDefOrRef)));
		}

		public void Visit (ExportedTypeRow row)
		{
			row.Flags = (Mono.Cecil.TypeAttributes) m_binaryReader.ReadUInt32 ();
			row.TypeDefId = m_binaryReader.ReadUInt32 ();
			row.TypeName = ReadByIndexSize (m_stringsHeapIdxSz);
			row.TypeNamespace = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Implementation = Utilities.GetMetadataToken (CodedIndex.Implementation,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.Implementation)));
		}

		public void Visit (FieldRow row)
		{
			row.Flags = (Mono.Cecil.FieldAttributes) m_binaryReader.ReadUInt16 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Signature = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (FieldLayoutRow row)
		{
			row.Offset = m_binaryReader.ReadUInt32 ();
			row.Field = ReadByIndexSize (GetIndexSize (typeof (FieldTable)));
		}

		public void Visit (FieldMarshalRow row)
		{
			row.Parent = Utilities.GetMetadataToken (CodedIndex.HasFieldMarshal,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.HasFieldMarshal)));
			row.NativeType = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (FieldRVARow row)
		{
			row.RVA = new RVA (m_binaryReader.ReadUInt32 ());
			row.Field = ReadByIndexSize (GetIndexSize (typeof (FieldTable)));
		}

		public void Visit (FileRow row)
		{
			row.Flags = (Mono.Cecil.FileAttributes) m_binaryReader.ReadUInt32 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.HashValue = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (GenericParamRow row)
		{
			row.Number = m_binaryReader.ReadUInt16 ();
			row.Flags = (Mono.Cecil.GenericParamAttributes) m_binaryReader.ReadUInt16 ();
			row.Owner = Utilities.GetMetadataToken (CodedIndex.TypeOrMethodDef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.TypeOrMethodDef)));
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
		}

		public void Visit (GenericParamConstraintRow row)
		{
			row.Owner = ReadByIndexSize (GetIndexSize (typeof (GenericParamTable)));
			row.Constraint = Utilities.GetMetadataToken (CodedIndex.TypeDefOrRef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.TypeDefOrRef)));
		}

		public void Visit (ImplMapRow row)
		{
			row.MappingFlags = (Mono.Cecil.PInvokeAttributes) m_binaryReader.ReadUInt16 ();
			row.MemberForwarded = Utilities.GetMetadataToken (CodedIndex.MemberForwarded,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.MemberForwarded)));
			row.ImportName = ReadByIndexSize (m_stringsHeapIdxSz);
			row.ImportScope = ReadByIndexSize (GetIndexSize (typeof (ModuleRefTable)));
		}

		public void Visit (InterfaceImplRow row)
		{
			row.Class = ReadByIndexSize (GetIndexSize (typeof (TypeDefTable)));
			row.Interface = Utilities.GetMetadataToken (CodedIndex.TypeDefOrRef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.TypeDefOrRef)));
		}

		public void Visit (ManifestResourceRow row)
		{
			row.Offset = m_binaryReader.ReadUInt32 ();
			row.Flags = (Mono.Cecil.ManifestResourceAttributes) m_binaryReader.ReadUInt32 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Implementation = Utilities.GetMetadataToken (CodedIndex.Implementation,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.Implementation)));
		}

		public void Visit (MemberRefRow row)
		{
			row.Class = Utilities.GetMetadataToken (CodedIndex.MemberRefParent,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.MemberRefParent)));
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Signature = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (MethodRow row)
		{
			row.RVA = new RVA (m_binaryReader.ReadUInt32 ());
			row.ImplFlags = (Mono.Cecil.MethodImplAttributes) m_binaryReader.ReadUInt16 ();
			row.Flags = (Mono.Cecil.MethodAttributes) m_binaryReader.ReadUInt16 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Signature = ReadByIndexSize (m_blobHeapIdxSz);
			row.ParamList = ReadByIndexSize (GetIndexSize (typeof (ParamTable)));
		}

		public void Visit (MethodImplRow row)
		{
			row.Class = ReadByIndexSize (GetIndexSize (typeof (TypeDefTable)));
			row.MethodBody = Utilities.GetMetadataToken (CodedIndex.MethodDefOrRef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.MethodDefOrRef)));
			row.MethodDeclaration = Utilities.GetMetadataToken (CodedIndex.MethodDefOrRef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.MethodDefOrRef)));
		}

		public void Visit (MethodSemanticsRow row)
		{
			row.Semantics = (Mono.Cecil.MethodSemanticsAttributes) m_binaryReader.ReadUInt16 ();
			row.Method = ReadByIndexSize (GetIndexSize (typeof (MethodTable)));
			row.Association = Utilities.GetMetadataToken (CodedIndex.HasSemantics,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.HasSemantics)));
		}

		public void Visit (MethodSpecRow row)
		{
			row.Method = Utilities.GetMetadataToken (CodedIndex.MethodDefOrRef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.MethodDefOrRef)));
			row.Instantiation = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (ModuleRow row)
		{
			row.Generation = m_binaryReader.ReadUInt16 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Mvid = ReadByIndexSize (m_guidHeapIdxSz);
			row.EncId = ReadByIndexSize (m_guidHeapIdxSz);
			row.EncBaseId = ReadByIndexSize (m_guidHeapIdxSz);
		}

		public void Visit (ModuleRefRow row)
		{
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
		}

		public void Visit (NestedClassRow row)
		{
			row.NestedClass = ReadByIndexSize (GetIndexSize (typeof (TypeDefTable)));
			row.EnclosingClass = ReadByIndexSize (GetIndexSize (typeof (TypeDefTable)));
		}

		public void Visit (ParamRow row)
		{
			row.Flags = (Mono.Cecil.ParamAttributes) m_binaryReader.ReadUInt16 ();
			row.Sequence = m_binaryReader.ReadUInt16 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
		}

		public void Visit (PropertyRow row)
		{
			row.Flags = (Mono.Cecil.PropertyAttributes) m_binaryReader.ReadUInt16 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Type = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (PropertyMapRow row)
		{
			row.Parent = ReadByIndexSize (GetIndexSize (typeof (TypeDefTable)));
			row.PropertyList = ReadByIndexSize (GetIndexSize (typeof (PropertyTable)));
		}

		public void Visit (StandAloneSigRow row)
		{
			row.Signature = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Visit (TypeDefRow row)
		{
			row.Flags = (Mono.Cecil.TypeAttributes) m_binaryReader.ReadUInt32 ();
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Namespace = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Extends = Utilities.GetMetadataToken (CodedIndex.TypeDefOrRef,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.TypeDefOrRef)));
			row.FieldList = ReadByIndexSize (GetIndexSize (typeof (FieldTable)));
			row.MethodList = ReadByIndexSize (GetIndexSize (typeof (MethodTable)));
		}

		public void Visit (TypeRefRow row)
		{
			row.ResolutionScope = Utilities.GetMetadataToken (CodedIndex.ResolutionScope,
				ReadByIndexSize (GetCodedIndexSize (CodedIndex.ResolutionScope)));
			row.Name = ReadByIndexSize (m_stringsHeapIdxSz);
			row.Namespace = ReadByIndexSize (m_stringsHeapIdxSz);
		}

		public void Visit (TypeSpecRow row)
		{
			row.Signature = ReadByIndexSize (m_blobHeapIdxSz);
		}

		public void Terminate (RowCollection coll)
		{
		}
	}
}
