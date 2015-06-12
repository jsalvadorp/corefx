﻿using System.Reflection.Emit;
using System.Text;

namespace ILDasmLibrary.Instructions
{
    class ILDasmBranchInstruction : ILDasmInstructionWithValue<int>
    {
        internal ILDasmBranchInstruction(OpCode opCode, int value, int ilOffset, int size)
            :base(opCode, value, ilOffset, size)
        {
        }

        public override void Dump(StringBuilder sb, bool showBytes = false)
        {
            if (showBytes)
            {
                sb.AppendFormat("*/ {0,-4} | ", opCode.Value.ToString("X2"));
                sb.Append(string.Format("{0,-16} */ ", Value.ToString("X4")));
            }
            sb.AppendFormat("{0,-10}", opCode);
            sb.Append(string.Format("IL_{0:x4}", (Token+Value+Size)));
        }
    }
}
