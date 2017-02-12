﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Spect.Net.Z80Emu.Test.Helpers;
using Spect.Net.Z80TestHelpers;

// ReSharper disable ArgumentsStyleStringLiteral

namespace Spect.Net.Z80Emu.Test.Core.StandardOps
{
    [TestClass]
    public class StandardOpTests0xB0
    {
        /// <summary>
        /// OR B: 0xB0
        /// </summary>
        [TestMethod]
        public void OR_B_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52, // LD A,52H
                0x06, 0x23, // LD B,23H
                0xB0        // OR B
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x73);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR B: 0xB0
        /// </summary>
        [TestMethod]
        public void OR_B_WorksWithSignFlag()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x82, // LD A,82H
                0x06, 0x22, // LD B,22H
                0xB0        // OR B
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0xA2);
            regs.SFlag.ShouldBeTrue();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR B: 0xB0
        /// </summary>
        [TestMethod]
        public void OR_B_WorksWithZeroFlag()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x00, // LD A,00H
                0x06, 0x00, // LD B,00H
                0xB0        // OR B
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x00);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeTrue();
            regs.PFlag.ShouldBeTrue();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR B: 0xB0
        /// </summary>
        [TestMethod]
        public void OR_B_WorksWithPFlag()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x32, // LD A,32H
                0x06, 0x11, // LD B,11H
                0xB0        // OR B
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x33);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeTrue();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR C: 0xB1
        /// </summary>
        [TestMethod]
        public void OR_C_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52, // LD A,52H
                0x0E, 0x23, // LD C,23H
                0xB1        // OR C
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x73);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, C");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR D: 0xB2
        /// </summary>
        [TestMethod]
        public void OR_D_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52, // LD A,52H
                0x16, 0x23, // LD D,23H
                0xB2        // OR D
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x73);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, D");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR E: 0xB3
        /// </summary>
        [TestMethod]
        public void OR_E_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52, // LD A,52H
                0x1E, 0x23, // LD E,23H
                0xB3        // OR E
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x73);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, E");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR H: 0xB4
        /// </summary>
        [TestMethod]
        public void OR_H_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52, // LD A,52H
                0x26, 0x23, // LD H,23H
                0xB4        // OR H
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x73);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, H");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR L: 0xB5
        /// </summary>
        [TestMethod]
        public void OR_L_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52, // LD A,52H
                0x2E, 0x23, // LD L,23H
                0xB5        // OR L
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x73);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, L");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(18ul);
        }

        /// <summary>
        /// OR (HL): 0xB6
        /// </summary>
        [TestMethod]
        public void OR_HLi_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52,       // LD A,52H
                0x21, 0x00, 0x10, // LD HL,1000H
                0xB6              // OR (HL)
            });
            m.Memory[0x1000] = 0x23;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x73);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF, HL");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0006);
            m.Cpu.Ticks.ShouldBe(24ul);
        }

        /// <summary>
        /// OR A: 0xB7
        /// </summary>
        [TestMethod]
        public void OR_A_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x3E, 0x52, // LD A,52H
                0xB7        // OR A
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x52);
            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();

            regs.HFlag.ShouldBeFalse();
            regs.NFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();
            m.ShouldKeepRegisters(except: "AF");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP B: 0xB8
        /// </summary>
        [TestMethod]
        public void CP_B_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x06, 0x24, // LD B,24H
                0xB8        // CP B
            });
            m.Cpu.Registers.A = 0x36;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP B: 0xB8
        /// </summary>
        [TestMethod]
        public void CP_B_HandlesCarryFlag()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x06, 0x60, // LD B,60H
                0xB8        // CP B
            });
            m.Cpu.Registers.A = 0x40;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeTrue();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeTrue();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP B: 0xB8
        /// </summary>
        [TestMethod]
        public void CP_B_HandlesZeroFlag()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x06, 0x40, // LD B,60H
                0xB8        // CP B
            });
            m.Cpu.Registers.A = 0x40;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeTrue();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP B: 0xB8
        /// </summary>
        [TestMethod]
        public void CP_B_HandlesHFlag()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x06, 0x43, // LD B,43H
                0xB8        // CP B
            });
            m.Cpu.Registers.A = 0x41;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeTrue();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeTrue();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeTrue();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP B: 0xB8
        /// </summary>
        [TestMethod]
        public void CP_B_HandlesHPlag()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x06, 0xB3, // LD B,B3H
                0xB8        // CP B
            });
            m.Cpu.Registers.A = 0x61;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeTrue();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeTrue();
            regs.PFlag.ShouldBeTrue();
            regs.CFlag.ShouldBeTrue();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, B");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP C: 0xB9
        /// </summary>
        [TestMethod]
        public void CP_C_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x0E, 0x24, // LD C,24H
                0xB9        // CP C
            });
            m.Cpu.Registers.A = 0x36;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, C");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP D: 0xBA
        /// </summary>
        [TestMethod]
        public void CP_D_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x16, 0x24, // LD D,24H
                0xBA        // CP D
            });
            m.Cpu.Registers.A = 0x36;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, D");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP E: 0xBB
        /// </summary>
        [TestMethod]
        public void CP_E_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x1E, 0x24, // LD E,24H
                0xBB        // CP E
            });
            m.Cpu.Registers.A = 0x36;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, E");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP H: 0xBC
        /// </summary>
        [TestMethod]
        public void CP_H_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x26, 0x24, // LD H,24H
                0xBC        // CP H
            });
            m.Cpu.Registers.A = 0x36;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, H");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP L: 0xBD
        /// </summary>
        [TestMethod]
        public void CP_L_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x2E, 0x24, // LD L,24H
                0xBD        // CP L
            });
            m.Cpu.Registers.A = 0x36;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, L");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0003);
            m.Cpu.Ticks.ShouldBe(11ul);
        }

        /// <summary>
        /// CP (HL): 0xBE
        /// </summary>
        [TestMethod]
        public void CP_HLi_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x21, 0x00, 0x10, // LD HL,1000H
                0xBE              // CP (HL)
            });
            m.Cpu.Registers.A = 0x36;
            m.Memory[0x1000] = 0x24;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeFalse();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, HL");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0004);
            m.Cpu.Ticks.ShouldBe(17ul);
        }

        /// <summary>
        /// CP A: 0xBF
        /// </summary>
        [TestMethod]
        public void CP_A_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0xBF        // CP A
            });
            m.Cpu.Registers.A = 0x36;

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.SFlag.ShouldBeFalse();
            regs.ZFlag.ShouldBeTrue();
            regs.HFlag.ShouldBeFalse();
            regs.PFlag.ShouldBeFalse();
            regs.CFlag.ShouldBeFalse();

            regs.NFlag.ShouldBeTrue();
            m.ShouldKeepRegisters(except: "F, L");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x0001);
            m.Cpu.Ticks.ShouldBe(4ul);
        }

    }
}