using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Text;

namespace Assembler
{
    public class ASol : ISol
    {
        public void Run(string compiled, string to)
        {
            string label, opcode, arg0, arg1, arg2;
            var labelArray = new List<Label>(CommonUtil.MAXNUMLABELS);


            StreamReader inFile = null;
            StreamWriter outFile = null;

            try
            {
                inFile = new StreamReader(compiled);
                outFile = new StreamWriter(to);
                /* map symbols to addresses */

                /* assume address start at 0 */
                int address;
                bool isNoReg;
                for (address = 0; ReadAndParse(inFile, out label, out opcode, out arg0, out arg1, out arg2); address++)
                {

                    /* check for illegal opcode */
                    if ( CommonUtil.Commands.All(c => opcode != c.Value))
                    {
                        throw new MessageException($"Unrecognized opcode {opcode} at address {address + 1}");
                    }

                    isNoReg = CheckCommands(opcode, new[] { Command.XOR, Command.AND, Command.IMUL }) && string.IsNullOrEmpty(arg0);

                    /* check register fields */
                    if (CheckCommands(opcode, new[] { Command.ADD, Command.NAND, Command.LW, Command.SW, 
                                                    Command.BEQ, Command.JALR, Command.MUL, Command.DIV, 
                                                    Command.IMUL, Command.XIDIV, Command.XOR, Command.AND,
                                                    Command.CMPGE, Command.JMAE, Command.JMNAE, Command.PUSH,
                                                    Command.POP, Command.BSF, Command.JNE, Command.BSR}))
                    {
                        if (!isNoReg)
                            TestRegArg(arg0);
                    }
                    if (CheckCommands(opcode, new[] { Command.ADD, Command.NAND, Command.LW, Command.SW,
                                                    Command.BEQ, Command.JALR, Command.MUL, Command.DIV,
                                                    Command.IMUL, Command.XIDIV, Command.XOR, Command.AND,
                                                    Command.CMPGE, Command.JMAE, Command.JMNAE, Command.JNE}))
                    {
                        if (!isNoReg)
                            TestRegArg(arg1);
                    }
                    if (CheckCommands(opcode, new[] { Command.ADD, Command.NAND, Command.MUL, Command.IMUL,
                                                    Command.AND, Command.XOR, Command.DIV, Command.XIDIV,
                                                    Command.CMPGE}))
                    {
                        if (!isNoReg)
                            TestRegArg(arg2);
                    }

                    /* check addressField */
                    if (CheckCommands(opcode, new[] { Command.LW, Command.SW, Command.BEQ, Command.JMAE, Command.JMNAE}))
                    {
                        TestAddrArg(arg2);
                    }
                    
                    /* check addressField */
                    if (CheckCommands(opcode, new[] { Command.FILL, Command.JNE}))
                    {
                        TestAddrArg(arg0);
                    }


                    /* check for enough arguments */
                    if (!isNoReg && 
                         (!CheckCommands(opcode, new[] { Command.HALT, Command.FILL, Command.JALR, Command.PUSH, Command.POP, Command.BSR, Command.BSF}) && string.IsNullOrEmpty(arg2)) ||
                         (CheckCommands(opcode, new[] { Command.BSF, Command.BSR }) && string.IsNullOrEmpty(arg1) ) ||
                         (CheckCommands(opcode, new[] { Command.FILL, Command.PUSH, Command.POP, Command.JNE }) && string.IsNullOrEmpty(arg0) ) )
                    {
                        throw new MessageException($"Error at address {address + 1}: not enough arguments");
                    }

                    if ( !string.IsNullOrEmpty(label) )
                    {
                        /* check for labels that are too long */
                        if (label.Length >= CommonUtil.MAXLABELLENGTH)
                        {
                            throw new MessageException($"Label {label} is too long!(max length: {CommonUtil.MAXLABELLENGTH})");
                        }

                        /* make sure label starts with letter */
                        if (!Regex.IsMatch(label, "^[a-zA-Z]"))
                        {
                            throw new MessageException($"Label {label} doesn't start with letter!");
                        }

                        /* make sure label consists of only letters and numbers */
                        if (!Regex.IsMatch(label, "[a-zA-Z0-9]"))
                        {
                            throw new MessageException($"Label {label} has character other that letters and numbers!");
                        }

                        /* look for duplicate label */
                        var duplicate = labelArray.FirstOrDefault(l => l.label == label);
                        if (duplicate != null)
                        {
                            throw new MessageException($"Error: duplicate label {label} at address {duplicate.Address + 1}");
                        }
                        labelArray.Add(new Label { label = label, Address = address });
                    }
                }

                /* now do second pass (print machine code, with symbols filled in as
                addresses) */
                inFile.DiscardBufferedData();
                inFile.BaseStream.Seek(0, SeekOrigin.Begin);
                for (address = 0; ReadAndParse(inFile, out label, out opcode, out arg0, out arg1, out arg2); address++)
                {
                    var opCommand = (Command)Enum.Parse(typeof(Command), opcode.ToUpper().Replace(".", ""));

                    isNoReg = CheckCommands(opcode, new[] { Command.XOR, Command.AND, Command.IMUL }) && string.IsNullOrEmpty(arg0);

                    int num = 0;
                    if (CheckCommands(opcode, new[] { Command.ADD, Command.NAND, Command.MUL,  Command.DIV, 
                                                    Command.XIDIV, Command.AND, Command.CMPGE, Command.XOR, Command.IMUL}))
                    {
                        num = !isNoReg ? CreateNumber(opCommand, arg0, arg1, arg2) : CreateNumber(opCommand);
                    }

                    else if (CheckCommands(opcode, new[] { Command.JALR, Command.BSF, Command.BSR }))
                    {
                        num = CreateNumber(opCommand, arg0, arg1);
                    }
                    else if (CheckCommands(opcode, new[] { Command.PUSH, Command.POP}))
                    {
                        num = CreateNumber(opCommand, arg0);
                    }
                    else if (opcode == (CommonUtil.Commands[Command.HALT]))
                    {
                        num = CreateNumber(opCommand);
                    }
                    else if (opcode == (CommonUtil.Commands[Command.FILL]))
                    {
                        if (int.TryParse(arg0, out num))
                        {
                            num = int.Parse(arg0);
                        }
                        else
                        {
                            num = TranslateSymbol(labelArray, arg0);
                        }
                    }
                    else if ( CheckCommands(opcode, new[] { Command.SW, Command.BEQ, Command.LW, Command.JNE, Command.JMAE, Command.JMNAE }) )
                    {
                        int addressField;
                        if (opCommand == Command.JNE)
                        {
                            /* if arg2 is symbolic, then translate into an address */
                            addressField = !IsNumber(arg0) ? TranslateSymbol(labelArray, arg2) : int.Parse(arg2);
                        }
                        else
                        {
                            /* if arg2 is symbolic, then translate into an address */
                            if (!IsNumber(arg2))
                            {
                                addressField = TranslateSymbol(labelArray, arg2);
                                if ( CheckCommands(opcode, new[] { Command.BEQ, Command.JMAE, Command.JMNAE }) )
                                {
                                    addressField = addressField - address - 1;
                                }
                            }
                            else
                            {
                                addressField = int.Parse(arg2);
                            }
                        }

                        if (addressField < CommonUtil.MINADDRESSFIELD || addressField > CommonUtil.MAXADDRESSFIELD)
                        {
                            throw new MessageException($"Error: offset {addressField + 1} out of range");
                        }

                        addressField &= CommonUtil.MaskForAddr;

                        num = opCommand == Command.JNE ? CreateNumber(opCommand, addressField) : CreateNumber(opCommand, arg0, arg1, addressField);

                    }
                    outFile.WriteLine(num);
                }
            }
            finally
            {
                inFile?.Close();
                outFile?.Close();
            }
        }

        /*
         * Read and parse a line of the assembly-language file.  Fields are returned
         * in label, opcode, arg0, arg1, arg2 (these strings must have memory already
         * allocated to them).
         *
         * Return values:
         *     0 if reached end of file
         *     1 if all went well
         *
         * exit(1) if line is too long.
         */
        private static bool ReadAndParse( StreamReader inFile, out string label, out string opcode, out string arg0, out string arg1, out string arg2 )
        {
            label = opcode = arg0 = arg1 = arg2 = string.Empty;
            /* delete prior values */

            /* read the line from the assembly-language file */
            if (inFile.EndOfStream)
            {
                /* reached end of file */
                return false;
            }
            var line = inFile.ReadLine();
            

            var index = 0;
            if (line == null) return false;
            var split = line.Split(new[] {'\t', '\n', '\r', ' '}, StringSplitOptions.RemoveEmptyEntries);
            if (!Regex.IsMatch(line, "^[\t\n ]"))
            {
                label = split[index++];
            }
            opcode = split.ElementAtOrDefault(index++) ?? string.Empty;
            arg0 = split.ElementAtOrDefault(index++) ?? string.Empty;
            arg1 = split.ElementAtOrDefault(index++) ?? string.Empty;
            arg2 = split.ElementAtOrDefault(index) ?? string.Empty;
            return true;
        }

        private static int TranslateSymbol( IEnumerable<Label> labelArray, string symbol )
        {
            /* search through address label table */
            var label = labelArray.FirstOrDefault(l => l.label == (symbol));

            if (label == null)
            {
                throw new MessageException($"Error: missing label {symbol}");
            }

            return label.Address;
        }

        private bool IsNumber( string str)
        {
            /* return 1 if string is a number */
            return int.TryParse(str, out _);
        }
        /*
         * Test register argument; make sure it's in range and has no bad characters.
         */
        private void TestRegArg( string arg )
        {
            if (!IsNumber(arg)) return;
            if (!Regex.IsMatch(arg, "[0-9]"))
            {
                throw new MessageException("Bad character in register argument!");
            }

            var num = int.Parse(arg);

            if (num < 0 || num > CommonUtil.COUNTREGISTERS)
            {
                throw new MessageException($"Error: register out of range ({num})");
            }
        }
        /*
         * Test addressField argument.
         */
        private void TestAddrArg( string arg )
        {
            /* test numeric addressField */
            if (IsNumber(arg) && !Regex.IsMatch(arg, "[0-9]"))
            {
                throw new MessageException("Bad character in addressField!");
            }
        }

        private static bool CheckCommands(string opcode, Command[] opcodes)
        {
            return opcodes.Any(op => CommonUtil.Commands[op] == opcode);
        }

        private static int CreateNumber(Command com, string arg0, string arg1, string arg2)
        {
            return ((int)com << CommonUtil.OffsetOpcode) | (int.Parse(arg0) << CommonUtil.OffsetArg0) | (int.Parse(arg1) << CommonUtil.OffsetArg1)
                            | int.Parse(arg2) << CommonUtil.OffsetArg2;
        }
        private static int CreateNumber(Command com, string arg0, string arg1, int arg2)
        {
            return ((int)com << CommonUtil.OffsetOpcode) | (int.Parse(arg0) << CommonUtil.OffsetArg0) | (int.Parse(arg1) << CommonUtil.OffsetArg1)
                            | arg2 << CommonUtil.OffsetArg2;
        }
        private static int CreateNumber(Command com, string arg0, string arg1)
        {
            return ((int)com << CommonUtil.OffsetOpcode) | (int.Parse(arg0) << CommonUtil.OffsetArg0) | (int.Parse(arg1) << CommonUtil.OffsetArg1);
        }
        private static int CreateNumber(Command com, string arg0)
        {
            return ((int)com << CommonUtil.OffsetOpcode) | (int.Parse(arg0) << CommonUtil.OffsetArg0);
        }
        private static int CreateNumber(Command com, int arg0)
        {
            return ((int)com << CommonUtil.OffsetOpcode) | (arg0 << CommonUtil.OffsetArg0);
        }
        private static int CreateNumber(Command com)
        {
            return ((int)com << CommonUtil.OffsetOpcode);
        }
    }
}
