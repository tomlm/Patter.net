﻿using System.Collections.Generic;

namespace Patter.Operations
{
    internal class SeekAndSkipChars<T> : PatternOp<T>
    {
        private HashSet<char> _chars;

        internal SeekAndSkipChars(params char[] chars)
        {
            _chars = new HashSet<char>(chars);
        }

        internal override T Execute(PatternContext<T> context)
        {
            while (context.Pos < context.Text.Length)
            {
                var ch = context.Text[context.Pos];
                if (_chars.Contains(ch))
                    break;
                context.Pos++;
            }

            while (context.Pos < context.Text.Length)
            {
                var ch = context.Text[context.Pos];
                if (!_chars.Contains(ch))
                    break;
                context.Pos++;
            }
            return default(T);
        }
    }
}