﻿using System.Reflection.Emit;
using System.Text;

namespace ILDasmLibrary.Instructions
{
    abstract class ILDasmNumericValueInstruction<T> : ILDasmInstructionWithValue<T>
    {
        private string _bytes;
        internal ILDasmNumericValueInstruction(OpCode opCode, T value, int token, int size)
            :base(opCode, value, token, size)
        {
        }

        public override void Dump(StringBuilder sb, bool showBytes = false)
        {
            if (showBytes)
            {
                sb.AppendFormat("/* {0,-4} | ", opCode.Value.ToString("X2"));
                sb.AppendFormat("{0,-16} */ ",Bytes);
            }
            base.Dump(sb);
        }

        public string Bytes
        {
            get
            {
                if(_bytes == null)
                {
                    _bytes = GetBytes();
                }
                return _bytes;
            }
        }

        protected abstract string GetBytes();
    }
}
