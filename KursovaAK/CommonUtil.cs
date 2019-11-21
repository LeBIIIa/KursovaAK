using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Assembler
{
    internal struct Label
    {
        public int Address;
        public string label;
    }

    internal struct State
    {
        public int pc;
        public List<int> mem;
        public List<int> reg;
        public int numMemory;
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
        

        public const int MAXADDRESSFIELD = 2147483647;
        public const int MINADDRESSFIELD = -2147483648;
        public const int MAXNUMLABELS = 65536;
        public const int MAXLABELLENGTH = 7;
        public const int COUNTREGISTERS = 16;
        public const int NUMMEMORY = 16384;
        public const int startMemCommand = 256;
        public static Dictionary<Command, string> Commands { get { if (_command == null) { Init(); } return _command; } }
        #endregion
        #region private variables
        private static Dictionary<Command, string> _command;
        public static byte[] Key = {
                            120,
                            106,
                            51,
                            60,
                            186,
                            121,
                            254,
                            70,
                            30,
                            229,
                            199,
                            212,
                            31,
                            91,
                            175,
                            97,
                            159,
                            40,
                            214,
                            37,
                            220,
                            79,
                            147,
                            46,
                            111,
                            87,
                            181,
                            138,
                            114,
                            247,
                            51,
                            71
        };

        public static byte[] IV = {26,
                                    180,
                                    194,
                                    27,
                                    117,
                                    8,
                                    15,
                                    171,
                                    213,
                                    117,
                                    189,
                                    95,
                                    120,
                                    182,
                                    69,
                                    126,
                                 };
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

        FILL = CommonUtil.startMemCommand
    }
}