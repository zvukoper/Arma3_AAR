using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DZR_AAR_extenstion
{
    public class DllEntry // This can be named anything you like
    {
        // This 2 line are IMPORTANT and if changed will stop everything working
        // To send a string back to ARMA append to the output StringBuilder, ARMA outputSize limit applies!
        [DllExport("_RVExtension@12", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        public static void RVExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            outputSize--;

            // Reverses the input string
            char[] arr = function.ToCharArray();
            Array.Reverse(arr);
            string result = new string(arr);
            output.Append(result);
        }
    }
}
