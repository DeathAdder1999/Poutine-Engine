﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scipt_Editor.Extensions
{
    static class Extensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
