﻿using System.Collections.Generic;

namespace Patter.Operations
{
    internal class SeekChars<T> : PatternOp<T>
    {
        private HashSet<char> _chars;

        internal SeekChars(params char[] chars)
        {
            _chars = new HashSet<char>(chars);
        }

        internal override void Execute(PatternContext<T> context)
        {
            while (context.Pos < context.Text.Length)
            {
                var ch = context.Text[context.Pos];
                if (_chars.Contains(ch))
                    break;
                context.Pos++;
            }
        }
    }
}
