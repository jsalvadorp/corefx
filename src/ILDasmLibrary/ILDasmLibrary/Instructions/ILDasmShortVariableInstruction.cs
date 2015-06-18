﻿using System.Reflection.Emit;
using System.Text;

namespace ILDasmLibrary.Instructions
{
    class ILDasmShortVariableInstruction : ILDasmInstructionWithValue<string>
    {
        internal ILDasmShortVariableInstruction(OpCode opCode, string name, int token, int size) 
            : base(opCode, name, token, size)
        {
        }

        public override void Dump(StringBuilder sb, bool showBytes = false)
        {
            if (showBytes)
            {
                DumpBytes(sb, Token.ToString("X2"));
            }
            sb.AppendFormat("{0,-10}", opCode);
            sb.Append(Value);
        }
    }
}
