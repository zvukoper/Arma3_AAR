using System;
using System.IO;
using System.IO.Pipes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AARecorder_Server
{

    
    public partial class AARecorder : Form
    {

       // private NamedPipeClientStream armaCom;
        // private bool pipeConnected = false;

        public AARecorder()
        {
            InitializeComponent();
            //Setup();
        }

        public async void Setup()
        {

            /*
  delphiCom = ["\\.\pipe\delphiCom"] call jayarma2lib_fnc_openPipe;
armaCom = ["\\.\pipe\armaCom"] call jayarma2lib_fnc_openPipe;
delphiData = ["\\.\pipe\delphiData"] call jayarma2lib_fnc_openPipe;
armaData = ["\\.\pipe\armaData"] call jayarma2lib_fnc_openPipe;
 */

            NamedPipeServerStream delphiCom = new NamedPipeServerStream("delphiCom", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message);
            NamedPipeServerStream armaCom = new NamedPipeServerStream("armaCom", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message);
            //delphiCom.Connect();
            var result = await Task.Run(() =>
            {
                delphiCom.WaitForConnection();

                return "Client connected";
            });
            ConsoleOutput.Items.Add(result);
            var response = "AAR READY";
            byte[] messageBytes = Encoding.UTF8.GetBytes(response);
            delphiCom.Write(messageBytes, 0, messageBytes.Length);
            ConsoleOutput.Items.Add(response);


        }

        


        }
    
}
