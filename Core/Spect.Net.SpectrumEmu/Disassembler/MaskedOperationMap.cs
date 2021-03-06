﻿namespace Spect.Net.SpectrumEmu.Disassembler
{
    /// <summary>
    /// This class represents a set of instructions that can be specified with
    /// a mask.
    /// </summary>
    public class MaskedOperationMap : OperationMapBase
    {
        /// <summary>
        /// Instruction mask
        /// </summary>
        public byte Mask { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public MaskedOperationMap(byte opCode, byte mask, string instructionPattern) 
            : base(opCode, instructionPattern)
        {
            Mask = mask;
        }

        /// <summary>
        /// Checks if the specified <paramref name="opCode"/> matches
        /// with this instruction
        /// </summary>
        /// <param name="opCode">Operation code to check</param>
        /// <returns>True, if the specified operation code matches; otherwise, false</returns>
        public override bool Matches(byte opCode)
        {
            return (opCode & Mask) == (OpCode & Mask);
        }
    }
}