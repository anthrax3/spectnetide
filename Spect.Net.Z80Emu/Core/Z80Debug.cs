﻿namespace Spect.Net.Z80Emu.Core
{
    /// <summary>
    /// Debugger related partion of the Z80 class
    /// </summary>
    public partial class Z80
    {
        /// <summary>
        /// Checks if the next instruction to be executed is a call instruction or not
        /// </summary>
        /// <returns>
        /// 0, if the next instruction is not a call; otherwise the length of the call instruction
        /// </returns>
        public int GetCallInstructionLength()
        {
            var opCode = ReadMemory(Registers.PC);

            // --- CALL instruction
            if (opCode == 0xCD) return 3;

            // --- Call instruction with condition
            if ((opCode & 0xC7) == 0xC4) return 3;

            // --- Check for RST instructions
            if ((opCode & 0xC7) == 0xC7) return 1;

            // --- Check for extended instruction prefix
            if (opCode != 0xED) return 0;

            // --- Check for I/O and block transfer instructions
            opCode = ReadMemory((ushort) (Registers.PC + 1));
            return ((opCode & 0xB4) == 0xB0) ? 2 : 0;
        }
    }
}