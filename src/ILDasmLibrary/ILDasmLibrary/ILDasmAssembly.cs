﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace ILDasmLibrary
{
    public class ILDasmAssembly
    {
        private AssemblyDefinition _assemblyDefinition;
        private string _publicKey;

        internal ILDasmAssembly(AssemblyDefinition assemblyDef)
        {
            _assemblyDefinition = assemblyDef;
        }

        public string Name
        {
            get
            {
                return Readers.MdReader.GetString(_assemblyDefinition.Name);
            }
        }

        public string Culture
        {
            get
            {
                return Readers.MdReader.GetString(_assemblyDefinition.Culture);
            }
        }

        public int HashAlgorithm
        {
            get
            {
                return Convert.ToInt32(_assemblyDefinition.HashAlgorithm);
            }
        }

        public Version Version
        {
            get
            {
                return _assemblyDefinition.Version;
            }
        }

        public string PublicKey
        {
            get
            {
                if (_publicKey != null) return _publicKey;
                _publicKey = GetPublicKey();
                return _publicKey;
            }
        }

        private string GetPublicKey()
        {
            var bytes = Readers.MdReader.GetBlobBytes(_assemblyDefinition.PublicKey);
            if (bytes.Length == 0) return String.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            foreach (byte _byte in bytes)
            {
                sb.Append(String.Format("{0:x2}",_byte));                  
                sb.Append(" ");
            }
            sb.Append(")");
            return sb.ToString();
        }

        public string GetFormattedHashAlgorithm()
        {
            return String.Format("0x{0:x8}", HashAlgorithm);
        }

        public string GetFormattedVersion()
        {
            int build = Version.Build;
            int revision = Version.Revision;
            if (build == -1) build = 0;
            if (revision == -1) revision = 0;
            return String.Format("{0}:{1}:{2}:{3}", Version.Major.ToString(), Version.Minor.ToString(), build.ToString(), revision.ToString());
        }
    }
}
