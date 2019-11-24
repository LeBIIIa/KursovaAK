using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Assembler
{
    internal struct Label
    {
        public int Address;
        public string label;
    }

    internal class State
    {
        public List<int> mem;
        public List<int> reg;
        public Stack<int> stack;
        public int pc;
        public int ZF;
        public int numMemory;
        public State()
        {
            /* initialize memories and registers */
            mem = Enumerable.Repeat(0, CommonUtil.NUMMEMORY).ToList();
            reg = Enumerable.Repeat(0, CommonUtil.COUNTREGISTERS).ToList();
            stack = new Stack<int>(CommonUtil.MAXSTACKSIZE);
            
        }
    }

    public static class CommonUtil
    {
        #region public variables
        public const int OffsetOpcode = 22;
        public const int OffsetArg0 = 19;
        public const int OffsetArg1 = 16;
        public const int OffsetArg2 = 0;
        public const int MaskForArg = 0x7;
        public const int MaskForAddr = 0xFFFF;
        

        public const int MAXADDRESSFIELD = 32767;
        public const int MINADDRESSFIELD = -32768;
        public const int MAXNUMLABELS = 65536;
        public const int MAXLABELLENGTH = 7;
        public const int COUNTREGISTERS = 16;
        public const int NUMMEMORY = 16384;
        public const int startMemCommand = 256;
        public const int MAXSTACKSIZE = 32;
        public static Dictionary<Command, string> Commands { get { if (_command == null) { Init(); } return _command; } }
        #endregion
        #region private variables
        private static Dictionary<Command, string> _command;
        #endregion
        private static void Init()
        {
            _command = new Dictionary<Command, string>();
            foreach (var c in (Command[])Enum.GetValues(typeof(Command)))
            {
                if ((int)c < startMemCommand)
                {
                    _command.Add(c, c.ToString().ToLower());
                }
                else
                {
                    _command.Add(c, $".{c.ToString().ToLower()}");
                }
            }
        }
    }

    public enum Command
    {
        ADD,
        NAND,
        LW,
        SW,
        BEQ,
        JALR,
        HALT,
        MUL,
        PUSH,
        POP,
        IMUL,
        DIV,
        XIDIV,
        AND,
        XOR,
        CMPGE,
        JMAE,
        JMNAE,
        BSR,
        BSF,
        JNE,

        FILL = CommonUtil.startMemCommand
    }
}