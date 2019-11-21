using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assembler
{
    public class SSol : Sol
    {
        private StreamWriter sw = null;
        public void Run(string compilled, string report)
        {
            string line;
            State state;
            StreamReader file = null;

            /* initialize memories and registers */
            state.mem = Enumerable.Repeat(0, CommonUtil.NUMMEMORY).ToList();
            state.reg = Enumerable.Repeat(0, CommonUtil.COUNTREGISTERS).ToList();
            state.pc = 0;

            /* read machine-code file into instruction/data memory (starting at
            address 0) */
            try
            {
                file = new StreamReader(compilled);
                sw = new StreamWriter(report);
                for (state.numMemory = 0; !file.EndOfStream;state.numMemory++)
                {
                    line = file.ReadLine();
                    if (state.numMemory >= CommonUtil.NUMMEMORY)
                    {
                        throw new MessageException("Exceeded memory size!");
                    }
                    if (int.TryParse(line, out _))
                    {
                        throw new MessageException($"error in reading address {state.numMemory}");
                    }
                    sw.WriteLine("memory[{0}]={1}\n", state.numMemory, state.mem[state.numMemory]);
                }
                /* run never returns */
                Start(state);
            }
            finally
            {
                file?.Close();
            }
        }

        private void Start(State state)
        {
            var isHalt = false;
            int arg0, arg1, arg2, addressField;
            var instructions = 0;
            Command opcode;
            var maxMem = -1;    /* highest memory address touched during run */

            for (; !isHalt; instructions++)
            {
                /* infinite loop, exits when it executes halt */
                PrintState(state, sw);

                if (state.pc < 0 || state.pc >= CommonUtil.NUMMEMORY)
                {
                    throw new MessageException($"PC went out of the memory range {state.pc}");
                }

                maxMem = ( state.pc > maxMem ) ? state.pc : maxMem;

                /* this is to make the following code easier to read */
                opcode = (Command)(state.mem[state.pc] >> CommonUtil.OffsetOpcode);
                arg0 = ( state.mem[state.pc] >> CommonUtil.OffsetArg0 ) & CommonUtil.MaskForArg;
                arg1 = ( state.mem[state.pc] >> CommonUtil.OffsetArg1 ) & CommonUtil.MaskForArg;
                arg2 = ( state.mem[state.pc] >> CommonUtil.OffsetArg2) & CommonUtil.MaskForArg; /* only for add, nand */

                addressField = ConvertNum(state.mem[state.pc] & CommonUtil.MaskForAddr); /* for beq, lw, sw */
                state.pc++;
                switch (opcode)
                {
                    case Command.ADD:
                        state.reg[arg2] = state.reg[arg0] + state.reg[arg1];
                        break;
                    case Command.NAND:
                        state.reg[arg2] = ~( state.reg[arg0] & state.reg[arg1] );
                        break;
                    case Command.LW:
                        if (state.reg[arg0] + addressField < 0 || state.reg[arg0] + addressField >= CommonUtil.NUMMEMORY)
                        {
                            throw new MessageException($"Address out of bounds({state.reg[arg0] + addressField})");
                        }
                        state.reg[arg1] = state.mem[state.reg[arg0] + addressField];
                        if (state.reg[arg0] + addressField > maxMem)
                        {
                            maxMem = state.reg[arg0] + addressField;
                        }
                        break;
                    case Command.SW:
                        if (state.reg[arg0] + addressField < 0 || state.reg[arg0] + addressField >= CommonUtil.NUMMEMORY)
                        {
                            throw new MessageException($"Address out of bounds({state.reg[arg0] + addressField})");
                        }
                        state.mem[state.reg[arg0] + addressField] = state.reg[arg1];
                        if (state.reg[arg0] + addressField > maxMem)
                        {
                            maxMem = state.reg[arg0] + addressField;
                        }
                        break;
                    case Command.BEQ:
                        if (state.reg[arg0] == state.reg[arg1])
                        {
                            state.pc += addressField;
                        }
                        break;
                    case Command.JALR:
                        state.reg[arg1] = state.pc;
                        state.pc = arg0 != 0 ? state.reg[arg0] : 0;
                        break;
                    case Command.MUL:
                        state.reg[arg2] = state.reg[arg0] * state.reg[arg1];
                        break;
                    case Command.HALT:
                        sw.WriteLine("machine halted\n");
                        sw.WriteLine($"total of {instructions + 1} instructions executed\n");
                        sw.WriteLine("final state of machine:\n");
                        PrintState(state, sw);
                        isHalt = true;
                        break;
                    default:
                        sw.WriteLine($"error: illegal opcode 0x{opcode:X}");
                        break;
                }
                state.reg[0] = 0;
            }
        }

        private static void PrintState(State state, StreamWriter sw)
        {
            sw.WriteLine("\n@@@\nstate:");
            sw.WriteLine($"\tpc {state.pc}");
            sw.WriteLine("\tmemory:");
            for (var i = 0; i < state.numMemory; i++)
            {
                sw.WriteLine($"\t\tmem[ {i} ] {state.mem[i]}");
            }
            sw.WriteLine("\tregisters:");
            for (var i = 0; i < CommonUtil.COUNTREGISTERS; i++)
            {
                sw.WriteLine("\t\treg[ i ] state.reg[i]");
            }
            sw.WriteLine("end state");
        }

        private static int ConvertNum(int num)
        {
            /* convert a 16-bit number into a 32-bit Sun integer */
            var test = num & ( 1 << 15 );
            if ( test > 0 )
            {
                num -= 1 << 16;
            }
            return num;
        }

    }
}
