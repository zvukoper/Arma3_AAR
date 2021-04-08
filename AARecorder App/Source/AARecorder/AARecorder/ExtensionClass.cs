using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using Maca134.Arma.DllExport;
using Maca134.Arma.Serializer;

namespace DZR_AAR_extenstion
{
    public class DllEntry // This can be named anything you like
    {


        [ArmaDllExport]
        public static string Invoke(string input, int maxSize){
            string response;
            response= "NOTHING TO RESPOND";
            //get input from arma

            //break it into data and command
           var input_array = Converter.DeserializeObject<string[]>(input);


            var command = input_array[0];
            var data = input_array[1];



            // "JayArma2Extension" callExtension
            //switch the input
            switch (command) {
                case "test":
                    var response2 = string.Format("command {0}: {1}", command, data);
                    response = response2;
                   break;

                //openPipe
                case "openPipe":

                    NamedPipeClientStream armaCom = new NamedPipeClientStream(data);
                    armaCom.Connect();
                    break;
                    //writePipe
                    //readPipe
                    //closePipe
            }
            return response;
        }
    }
}
