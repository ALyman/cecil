/*
* Copyright (c) 2004 DotNetGuru and the individuals listed
* on the ChangeLog entries.
*
* Authors :
*   Jb Evain   (jb.evain@dotnetguru.org)
*
* This is a free software distributed under a MIT/X11 license
* See LICENSE.MIT file for more details
 *
 * Generated by /CodeGen/cecil-gen.rb do not edit
 * Tue Feb 01 21:43:56 Paris, Madrid 2005
*
*****************************************************************************/

namespace Mono.Cecil.Metadata {

    using System;

    internal sealed class Utilities {

        private Utilities ()
        {
        }

        public static int ReadCompressedInteger (byte [] data, int pos, out int start)
        {
            int integer = 0;
            start = pos;
            if ((data [pos] & 0x80) == 0) {
                integer = data [pos];
                start++;
            } else if ((data [pos] & 0x40) == 0) {
                integer = (data [start] & ~0x80) << 8;
                integer |= data [pos + 1];
                start += 2;
            } else {
                integer = (data [start] & ~0xc0) << 24;
                integer |= data [pos + 1] << 16;
                integer |= data [pos + 2] << 8;
                integer |= data [pos + 3];
                start += 4;
            }
            return integer;
        }
        
        public static MetadataToken GetMetadataToken (CodedIndex cidx, uint data)
        {
            uint rid = 0;
            switch (cidx) {
            case CodedIndex.TypeDefOrRef :
                rid = data >> 2;
                switch (data & 3) {
                case 0 :
                    return new MetadataToken (TokenType.TypeDef, rid);
                case 1 :
                    return new MetadataToken (TokenType.TypeRef, rid);
                case 2 :
                    return new MetadataToken (TokenType.TypeSpec, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for TypeDefOrRef");
                }
            case CodedIndex.HasConstant :
                rid = data >> 2;
                switch (data & 3) {
                case 0 :
                    return new MetadataToken (TokenType.Field, rid);
                case 1 :
                    return new MetadataToken (TokenType.Param, rid);
                case 2 :
                    return new MetadataToken (TokenType.Property, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for HasConstant");
                }
            case CodedIndex.HasCustomAttribute :
                rid = data >> 5;
                switch (data & 31) {
                case 0 :
                    return new MetadataToken (TokenType.Method, rid);
                case 1 :
                    return new MetadataToken (TokenType.Field, rid);
                case 2 :
                    return new MetadataToken (TokenType.TypeRef, rid);
                case 3 :
                    return new MetadataToken (TokenType.TypeDef, rid);
                case 4 :
                    return new MetadataToken (TokenType.Param, rid);
                case 5 :
                    return new MetadataToken (TokenType.InterfaceImpl, rid);
                case 6 :
                    return new MetadataToken (TokenType.MemberRef, rid);
                case 7 :
                    return new MetadataToken (TokenType.Module, rid);
                case 8 :
                    return new MetadataToken (TokenType.Permission, rid);
                case 9 :
                    return new MetadataToken (TokenType.Property, rid);
                case 10 :
                    return new MetadataToken (TokenType.Event, rid);
                case 11 :
                    return new MetadataToken (TokenType.Signature, rid);
                case 12 :
                    return new MetadataToken (TokenType.ModuleRef, rid);
                case 13 :
                    return new MetadataToken (TokenType.TypeSpec, rid);
                case 14 :
                    return new MetadataToken (TokenType.Assembly, rid);
                case 15 :
                    return new MetadataToken (TokenType.AssemblyRef, rid);
                case 16 :
                    return new MetadataToken (TokenType.File, rid);
                case 17 :
                    return new MetadataToken (TokenType.ExportedType, rid);
                case 18 :
                    return new MetadataToken (TokenType.ManifestResource, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for HasCustomAttribute");
                }
            case CodedIndex.HasFieldMarshal :
                rid = data >> 1;
                switch (data & 1) {
                case 0 :
                    return new MetadataToken (TokenType.Field, rid);
                case 1 :
                    return new MetadataToken (TokenType.Param, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for HasFieldMarshal");
                }
            case CodedIndex.HasDeclSecurity :
                rid = data >> 2;
                switch (data & 3) {
                case 0 :
                    return new MetadataToken (TokenType.TypeDef, rid);
                case 1 :
                    return new MetadataToken (TokenType.Method, rid);
                case 2 :
                    return new MetadataToken (TokenType.Assembly, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for HasDeclSecurity");
                }
            case CodedIndex.MemberRefParent :
                rid = data >> 3;
                switch (data & 7) {
                case 1 :
                    return new MetadataToken (TokenType.TypeRef, rid);
                case 2 :
                    return new MetadataToken (TokenType.ModuleRef, rid);
                case 3 :
                    return new MetadataToken (TokenType.Method, rid);
                case 4 :
                    return new MetadataToken (TokenType.TypeSpec, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for MemberRefParent");
                }
            case CodedIndex.HasSemantics :
                rid = data >> 1;
                switch (data & 1) {
                case 0 :
                    return new MetadataToken (TokenType.Event, rid);
                case 1 :
                    return new MetadataToken (TokenType.Property, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for HasSemantics");
                }
            case CodedIndex.MethodDefOrRef :
                rid = data >> 1;
                switch (data & 1) {
                case 0 :
                    return new MetadataToken (TokenType.Method, rid);
                case 1 :
                    return new MetadataToken (TokenType.MemberRef, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for MethodDefOrRef");
                }
            case CodedIndex.MemberForwarded :
                rid = data >> 1;
                switch (data & 1) {
                case 0 :
                    return new MetadataToken (TokenType.Field, rid);
                case 1 :
                    return new MetadataToken (TokenType.Method, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for MemberForwarded");
                }
            case CodedIndex.Implementation :
                rid = data >> 2;
                switch (data & 3) {
                case 0 :
                    return new MetadataToken (TokenType.File, rid);
                case 1 :
                    return new MetadataToken (TokenType.AssemblyRef, rid);
                case 2 :
                    return new MetadataToken (TokenType.ExportedType, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for Implementation");
                }
            case CodedIndex.CustomAttributeType :
                rid = data >> 3;
                switch (data & 7) {
                case 2 :
                    return new MetadataToken (TokenType.Method, rid);
                case 3 :
                    return new MetadataToken (TokenType.MemberRef, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for CustomAttributeType");
                }
            case CodedIndex.ResolutionScope :
                rid = data >> 2;
                switch (data & 3) {
                case 0 :
                    return new MetadataToken (TokenType.Module, rid);
                case 1 :
                    return new MetadataToken (TokenType.ModuleRef, rid);
                case 2 :
                    return new MetadataToken (TokenType.AssemblyRef, rid);
                case 3 :
                    return new MetadataToken (TokenType.TypeRef, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for ResolutionScope");
                }
            case CodedIndex.TypeOrMethodDef :
                rid = data >> 1;
                switch (data & 1) {
                case 0 :
                    return new MetadataToken (TokenType.TypeDef, rid);
                case 1 :
                    return new MetadataToken (TokenType.Method, rid);
                default :
                    throw new MetadataFormatException("Non valid tag for TypeOrMethodDef");
                }
            default :
                throw new MetadataFormatException ("Non valid CodedIndex");
            }
        }
    }
}