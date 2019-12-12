using System;
using System.Collections;
using System.IO;

namespace Assembler
{
    public class SSol : ISol
    {
        private StreamWriter sw = null;
        public void Run(string compiled, string report)
        {
            var state = new State();
            StreamReader file = null;

            /* read machine-code file into instruction/data memory (starting at
            address 0) */
            try
            {
                file = new StreamReader(compiled);
                sw = new StreamWriter(report);
                for (state.numMemory = 0; !file.EndOfStream;state.numMemory++)
                {
                    var line = file.ReadLine();
                    if (state.numMemory >= CommonUtil.NUMMEMORY)
                    {
                        throw new MessageException("Exceeded memory size!");
                    }
                    if (int.TryParse(line, out int t))
                    {
                        state.mem[state.numMemory] = t;
                    }
                    else
                    {
                        throw new MessageException($"error in reading address {state.numMemory + 1}");
                    }
                    sw.WriteLine("memory[ {0} ]={1}", state.numMemory, state.mem[state.numMemory]);
                }
                /* run never returns */
                Start(state);
            }
            finally
            {
                file?.Close();
                sw?.Close();
            }
        }

        private void Start(State state)
        {
            var isHalt = false;
            var instructions = 0;
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
                var opcode = (Command)(state.mem[state.pc] >> CommonUtil.OffsetOpcode);
                var arg0 = ( state.mem[state.pc] >> CommonUtil.OffsetArg0 ) & CommonUtil.MaskForArg;
                var arg1 = ( state.mem[state.pc] >> CommonUtil.OffsetArg1 ) & CommonUtil.MaskForArg;
                var arg2 = ( state.mem[state.pc] >> CommonUtil.OffsetArg2) & CommonUtil.MaskForArg; /* only for add, nand */

                var addressField = ConvertNum(state.mem[state.pc] & CommonUtil.MaskForAddr); /* for beq, lw, sw */
                state.pc++;

                if (opcode == Command.ADD)
                {
                    state.reg[arg2] = state.reg[arg0] + state.reg[arg1];
                }
                else if (opcode == Command.NAND)
                {
                    state.reg[arg2] = ~(state.reg[arg0] & state.reg[arg1]);
                }
                else if (opcode == Command.JALR)
                {
                    state.reg[arg1] = state.pc;
                    state.pc = arg0 != 0 ? state.reg[arg0] : 0;
                }
                else if (opcode == Command.MUL)
                {
                    state.reg[arg2] = Math.Abs(state.reg[arg0]) * Math.Abs(state.reg[arg1]);
                }
                else
                {
                    int st0;
                    int st1;
                    if (opcode == Command.AND)
                    {
                        if (arg0 != 0 || arg1 != 0 || arg2 != 0)
                            state.reg[arg2] = state.reg[arg0] & state.reg[arg1];
                        else
                        {
                            if (state.stack.Count > 0)
                            {
                                st0 = state.stack.Pop();
                            }
                            else
                                throw new MessageException("Stack is empty!");

                            if (state.stack.Count > 0)
                            {
                                st1 = state.stack.Pop();
                            }
                            else
                                throw new MessageException("Stack is empty!");

                            state.stack.Push(st0 & st1);
                        }
                    }
                    else if (opcode == Command.DIV)
                    {
                        if (state.reg[arg1] == 0)
                        {
                            throw new MessageException($"Divide by zero({state.numMemory + 1})");
                        }

                        state.reg[arg2] = Math.Abs(state.reg[arg0]) / Math.Abs(state.reg[arg1]);
                    }
                    else if (opcode == Command.IMUL)
                    {
                        if (arg0 != 0 || arg1 != 0 || arg2 != 0)
                            state.reg[arg2] = state.reg[arg0] * state.reg[arg1];
                        else
                        {
                            if (state.stack.Count > 0)
                            {
                                st0 = state.stack.Pop();
                            }
                            else
                                throw new MessageException("Stack is empty!");

                            if (state.stack.Count > 0)
                            {
                                st1 = state.stack.Pop();
                            }
                            else
                                throw new MessageException("Stack is empty!");

                            state.stack.Push(st0 * st1);
                        }
                    }
                    else if (opcode == Command.XIDIV)
                    {
                        if (state.reg[arg1] == 0)
                        {
                            throw new MessageException($"Divide by zero({state.numMemory + 1})");
                        }

                        state.reg[arg2] = Math.Abs(state.reg[arg0]) / Math.Abs(state.reg[arg1]);
                        int tmp = state.reg[arg0];
                        state.reg[arg0] = state.reg[arg1];
                        state.reg[arg1] = tmp;
                    }
                    else if (opcode == Command.CMPGE)
                    {
                        state.reg[arg2] = state.reg[arg0].CompareTo(state.reg[arg1]);
                    }
                    else if (opcode == Command.LW)
                    {
                        if (state.reg[arg0] + addressField < 0 || state.reg[arg0] + addressField >= CommonUtil.NUMMEMORY)
                        {
                            throw new MessageException($"Address out of bounds({state.reg[arg0] + addressField})");
                        }

                        state.reg[arg1] = state.mem[state.reg[arg0] + addressField];
                        if (state.reg[arg0] + addressField > maxMem)
                        {
                            maxMem = state.reg[arg0] + addressField;
                        }
                    }
                    else if (opcode == Command.SW)
                    {
                        if (state.reg[arg0] + addressField < 0 || state.reg[arg0] + addressField >= CommonUtil.NUMMEMORY)
                        {
                            throw new MessageException($"Address out of bounds({state.reg[arg0] + addressField})");
                        }

                        state.mem[state.reg[arg0] + addressField] = state.reg[arg1];
                        if (state.reg[arg0] + addressField > maxMem)
                        {
                            maxMem = state.reg[arg0] + addressField;
                        }
                    }
                    else if (opcode == Command.BEQ)
                    {
                        if (state.reg[arg0] == state.reg[arg1])
                        {
                            state.pc += addressField;
                        }
                    }
                    else if (opcode == Command.JMAE)
                    {
                        if (Math.Abs(state.reg[arg0]) >= Math.Abs(state.reg[arg1]))
                        {
                            state.pc += addressField;
                        }
                    }
                    else if (opcode == Command.JMNAE)
                    {
                        if (Math.Abs(state.reg[arg0]) < Math.Abs(state.reg[arg1]))
                        {
                            state.pc += addressField;
                        }
                    }
                    else if (opcode == Command.JNE)
                    {
                        if (state.ZF != 0)
                            state.pc = addressField;
                    }
                    else if (opcode == Command.HALT)
                    {
                        sw.WriteLine("machine halted");
                        sw.WriteLine($"total of {instructions + 1} instructions executed");
                        sw.WriteLine("final state of machine:");
                        PrintState(state, sw);
                        isHalt = true;
                    }
                    else if (opcode == Command.PUSH)
                    {
                        if (state.stack.Count == CommonUtil.MAXSTACKSIZE)
                        {
                            throw new MessageException("Stack is full!");
                        }

                        state.stack.Push(state.reg[arg0]);
                    }
                    else if (opcode == Command.POP)
                    {
                        if (state.stack.Count == 0)
                        {
                            throw new MessageException("Stack is empty!");
                        }

                        state.reg[arg0] = state.stack.Pop();
                    }
                    else if (opcode == Command.XOR)
                    {
                        if (arg0 != 0 || arg1 != 0 || arg2 != 0)
                            state.reg[arg2] = state.reg[arg0] ^ state.reg[arg1];
                        else
                        {
                            if (state.stack.Count > 0)
                            {
                                st0 = state.stack.Pop();
                            }
                            else
                                throw new MessageException("Stack is empty!");

                            if (state.stack.Count > 0)
                            {
                                st1 = state.stack.Pop();
                            }
                            else
                                throw new MessageException("Stack is empty!");

                            state.stack.Push(st0 ^ st1);
                        }
                    }
                    else if (opcode == Command.BSF)
                    {
                        BitArray arr = new BitArray(new int[] { state.reg[arg0] });
                        int t = 0;
                        for (var i = 0;i<arr.Count;++i)
                        {
                            if (arr[i])
                            {
                                state.reg[arg1] = i;
                                t = 1;
                                break;
                            }
                        }
                        state.ZF = t;
                    }
                    else if (opcode == Command.BSR)
                    {
                        BitArray arr = new BitArray(new int[] { state.reg[arg0] });
                        int t = 0;
                        for (var i = arr.Count - 1; i >= 0; --i)
                        {
                            if (arr[i])
                            {
                                state.reg[arg1] = i;
                                t = 1;
                                break;
                            }
                        }
                        state.ZF = t;
                    }
                    else
                    {
                        sw.WriteLine($"error: illegal opcode 0x{opcode:X}");
                    }
                }

                state.reg[0] = 0;
            }
        }

        private static void PrintState(State state, TextWriter sw)
        {
            sw.WriteLine("\n@@@\nstate:");
            sw.WriteLine($"\tpc {state.pc}");
            sw.WriteLine("\tmemory:");
            for (var i = 0; i < state.numMemory; i++)
            {
                sw.WriteLine($"\t\tmem[ {i} ] = {state.mem[i]}");
            }
            sw.WriteLine("\tregisters:");
            for (var i = 0; i < CommonUtil.COUNTREGISTERS; i++)
            {
                sw.WriteLine($"\t\treg[ {i} ] = {state.reg[i]}");
            }
            sw.WriteLine($"\tStack Top: {state.stack.Count}");
            sw.WriteLine("\tStack:");
            var lst = state.stack.ToArray();
            for (var i = 0;i<state.stack.Count;++i)
            {
                sw.WriteLine($"\t\tstack[ {i} ] = {lst[i]}");
            }
            sw.WriteLine("\tFlag:");
            sw.WriteLine($"\t\tZF {state.ZF}");
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
