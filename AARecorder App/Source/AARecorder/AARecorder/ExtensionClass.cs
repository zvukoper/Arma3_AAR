using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Maca134.Arma.DllExport;

namespace DZR_AAR_extenstion
{
    public class DllEntry // This can be named anything you like
    {
        [ArmaDllExport]
        public static string Invoke(string input, int maxSize){
        return input;
        }
    }
}
