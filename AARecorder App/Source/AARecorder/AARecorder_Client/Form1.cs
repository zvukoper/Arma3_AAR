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

namespace AARecorder_Client
{

    
    public partial class AARecorder : Form
    {

        private NamedPipeClientStream armaCom;
        private bool pipeConnected = false;

        public AARecorder()
        {
            InitializeComponent();
            Setup();
        }

        public void Setup()
        {
            if (!pipeConnected)
            {
                armaCom = new NamedPipeClientStream("armaCom");
                pipeConnected = true;
            }
        }

        private void Enable_CheckedChanged(object sender, EventArgs e)
        {


            if (pipeConnected)
            {
                armaCom.Dispose();
                ConsoleOutput.Items.Add("AAR Shut down");
                MainPanel.Enabled = false;
                pipeConnected = false;
            }
            else
            {
                ConsoleOutput.Items.Add("AAR Starting");
                MainPanel.Enabled = Enabled;
                armaCom.Connect();
                pipeConnected = true;

            }








            /*
              delphiCom = ["\\.\pipe\delphiCom"] call jayarma2lib_fnc_openPipe;
armaCom = ["\\.\pipe\armaCom"] call jayarma2lib_fnc_openPipe;
delphiData = ["\\.\pipe\delphiData"] call jayarma2lib_fnc_openPipe;
armaData = ["\\.\pipe\armaData"] call jayarma2lib_fnc_openPipe;
             */

        }
    }
}
