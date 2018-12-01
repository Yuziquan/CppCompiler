using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CppCompiler.Tiny_Syntax_Analysis
{
    public static class GetSyntaxTree
    {
        [DllImport("TinySyntaxAnalysis.Dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern void getSyntaxTree(char[] sourceFileFullName, Char[] savedFileFullName);
    }
}
