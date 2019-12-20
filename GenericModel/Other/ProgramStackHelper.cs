using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GenericModel.Other
{
    public class ProgramStackHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetPreviousMethod(int i = 0)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(i + 2);

            return sf.GetMethod().Name;
        }
    }
}
