using System;
using System.IO;
using System.IO.Pipes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AARecorder_Server
{
    public partial class AARecorder : Form
    {

        /*
         TODO: 
         * Add logging to all functions
         * Try reading emulated arma arrays

        */

        public AARecorder()
        {
            InitializeComponent();
            AndreyIM_Log.Logger.RichTextBoxLogger = myTextBoxLog;
        }

        public async void Setup()
        {

            /*
  delphiCom = ["\\.\pipe\delphiCom"] call jayarma2lib_fnc_openPipe;
armaCom = ["\\.\pipe\armaCom"] call jayarma2lib_fnc_openPipe;
delphiData = ["\\.\pipe\delphiData"] call jayarma2lib_fnc_openPipe;
armaData = ["\\.\pipe\armaData"] call jayarma2lib_fnc_openPipe;
 */

            
            //delphiCom.Connect();

//            byte[] messageBytes = Encoding.UTF8.GetBytes(response);
  //          delphiCom.Write(messageBytes, 0, messageBytes.Length);
    //        ConsoleOutput.Items.Add(response);


        }

        NamedPipeServerStream armaDataS; //4096﻿ 
        NamedPipeServerStream delphiDataS; //4096﻿ 
        NamedPipeServerStream delphiComS;
        NamedPipeServerStream armaComS;

        NamedPipeClientStream armaDataC; //4096﻿ 
        NamedPipeClientStream delphiDataC; //4096﻿ 
        NamedPipeClientStream delphiComC;
        NamedPipeClientStream armaComC;

        string MissionMapName = "myMissionName.chernarus";
        string FilenameSuffix;
        string GobalGameCommand;
        //server funciton to record data from arma must receive the data byte length as a parameter and prepare the byte array

        public void MainCycle() {
            // start command loop that constantly listens to armaComS pipe commands and assigns the command to the global variable "GobalGameCommand"
            // do 1 sec
            // read armaComS, if empty, skip
            // if something, assign it to GobalGameCommand
            // repeat

            // start swticher loop that listens to the global variable "GobalGameCommand" and switches cases
            // start thread
            // switch
            // case 0 = wait
            // case ARMA READY = aar_ready(){just send ready}
            // case REQUESTING RECORD = recording(){send rec ready, start blocking loop and wait for any data on armaDataS pipe and write to file in a thread, until GobalGameCommand is STOP or DATA is EOF = go back to ARMA READY,  or Client disconnects, GobalGameCommand=0 go back to NOTHING}
            // case REQUESTING PLAYBACK = playback() {send_dir_list(); wait for dir; send_file_list(); wait for file name; load file and send FILE READY; Wait for GobalGameCommand READING; start blocking loop that Writes lines to pipe until GobalGameCommand STOP, end of file or disconnect GobalGameCommand=0}
        }

        private void ServerWait(NamedPipeServerStream thePipe, string theMessage, Button theButton) {
            StringBuilder messageBuilder = new StringBuilder();
            var response = "";
            var bufferSize = Encoding.UTF8.GetBytes(theMessage).Length;
            string messageChunk = string.Empty;
            byte[] messageBuffer = new byte[bufferSize];
            theButton.BackColor = Color.Orange;

            new Thread(() =>
            {
                do
                {
                    thePipe.WaitForPipeDrain();
                    thePipe.Read(messageBuffer, 0, messageBuffer.Length);
                    messageChunk = Encoding.UTF8.GetString(messageBuffer);
                    messageBuilder.Append(messageChunk);
                    messageBuffer = new byte[messageBuffer.Length];
                    response = messageBuilder.ToString();
                }
                while ((!thePipe.IsMessageComplete) && (response == theMessage));
                theButton.BackColor = Color.Lime;
                Console.WriteLine(response);

                switch (response)
                {
                    case "REQUESTING RECORD":
                        button8.BackColor = Color.Red;
                        break;
                }
            }).Start();

        }

        /* Snippet for future use in threads
        BeginInvoke(new Action(() => label.Text = "Complete"));
        BeginInvoke(new Action(() =>
        {
            this.Text = finishLoadEvent.Browser.URL;
        })); */

        private void ServerSend(NamedPipeServerStream thePipe, string theMessage, Button theButton)
        {
            new Thread(() =>
            {
                theButton.BackColor = Color.Lime;
                byte[] messageBytes = Encoding.UTF8.GetBytes(theMessage);
                thePipe.Write(messageBytes, 0, messageBytes.Length);
                AndreyIM_Log.Logger.WriteLog(string.Format("Sending {0} to {1}", theMessage, thePipe), Color.Green);
                theButton.BackColor = Color.Lime;
            }).Start();
        }

        private void ServerSetup()
        { 
            armaDataS = new NamedPipeServerStream("armaData", PipeDirection.InOut, 1, PipeTransmissionMode.Message);
            delphiDataS = new NamedPipeServerStream("delphiData", PipeDirection.InOut, 1, PipeTransmissionMode.Message);
            delphiComS = new NamedPipeServerStream("delphiCom", PipeDirection.InOut, 1, PipeTransmissionMode.Message);
            armaComS = new NamedPipeServerStream("armaCom", PipeDirection.InOut, 1, PipeTransmissionMode.Message);
            button2.BackColor = Color.Orange;
                new Thread(() =>
                {
                Thread.CurrentThread.IsBackground = true;
                armaDataS.WaitForConnection();
                delphiDataS.WaitForConnection();
                delphiComS.WaitForConnection();
                armaComS.WaitForConnection();
                button2.BackColor = Color.Lime;
            }).Start();
        }

        private void ReadPipeWriteFile()
        {

            // Пишем в файл
            string pipe_data;
            pipe_data = "SIMULATED DATA FROM PIPE";
            string fileName;
            FilenameSuffix = Filename_suffix.Text;
            string directory = Application.StartupPath + "\\Replays\\" + MissionMapName + "\\";
            if (FilenameSuffix != "")
            {
                fileName = DateTime.Now.ToString("yyyy.MM.dd_HHmmss") + "_" + MissionMapName + "_" + FilenameSuffix + ".aar";
            }
            else
            {
                fileName = DateTime.Now.ToString("yyyy.MM.dd_HHmmss") + "_" + MissionMapName + ".aar";
            }

            try
            {
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                StreamWriter fs;
                FileInfo fi = new FileInfo(directory + fileName);
                fs = fi.AppendText();
                fs.WriteLine(pipe_data);
                fs.Close();
                AndreyIM_Log.Logger.WriteLog(string.Format("WRITING {1}: {0}", pipe_data, fileName), Color.Orange);
            }
            catch (System.Exception)
            {
                //WriteLog(ex.Message, Color.Red);
            }

        }

    private void ClientWait(NamedPipeClientStream thePipe, string theMessage, Button theButton)
        {
            StringBuilder messageBuilder = new StringBuilder();
            var response = "";
            string messageChunk = string.Empty;
            var bufferSize = Encoding.UTF8.GetBytes(theMessage).Length;
            byte[] messageBuffer = new byte[bufferSize];
            theButton.BackColor = Color.Orange;

            new Thread(() =>
            {
                do
                {
                    thePipe.WaitForPipeDrain();
                    thePipe.Read(messageBuffer, 0, messageBuffer.Length);
                    messageChunk = Encoding.UTF8.GetString(messageBuffer);
                    messageBuilder.Append(messageChunk);
                    messageBuffer = new byte[messageBuffer.Length];
                    response = messageBuilder.ToString();
                }
                while ((!thePipe.IsMessageComplete) && (response == theMessage));
                theButton.BackColor = Color.Lime;
            }).Start();
        }

        private void ClientSend(NamedPipeClientStream thePipe, string theMessage, Button theButton)
        {
            new Thread(() =>
            {
                theButton.BackColor = Color.Lime;
                byte[] messageBytes = Encoding.UTF8.GetBytes(theMessage);
                thePipe.Write(messageBytes, 0, messageBytes.Length);
                //ConsoleOutput.Items.Add(string.Format("Sending AAR READY to delphiComS {0}", delphiComC.IsConnected));
                theButton.BackColor = Color.Lime;
            }).Start();
        }

        private void ClientSetup ()
        {
            armaDataC = new NamedPipeClientStream("armaData");
            delphiDataC = new NamedPipeClientStream("delphiData");
            delphiComC = new NamedPipeClientStream("delphiCom");
            armaComC = new NamedPipeClientStream("armaCom");
            button19.BackColor = Color.Orange;
            new Thread(() =>
            {
                armaDataC.Connect();
                armaDataC.ReadMode = PipeTransmissionMode.Message;
                delphiDataC.Connect();
                delphiDataC.ReadMode = PipeTransmissionMode.Message;
                delphiComC.Connect();
                delphiComC.ReadMode = PipeTransmissionMode.Message;
                armaComC.Connect();
                armaComC.ReadMode = PipeTransmissionMode.Message;
                button19.BackColor = Color.Lime;
            }).Start();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ServerSetup();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ClientSetup();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServerWait(armaComS, "ARMA READY", button3); 
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ClientSend(armaComC, "ARMA READY", button12);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ServerSend(delphiComS, "AAR READY", button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClientWait(delphiComC, "AAR_READY", button5); //______________
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ClientSetup();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ServerWait(armaComS, "REQUESTING RECORD", button6);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClientSend(armaComC, "REQUESTING RECORD", button7);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ReadPipeWriteFile();

            
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClientWait(delphiComC, "READY FOR DATA", button10);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ServerSend(delphiComS, "READY FOR DATA", button9);
        }
    }
    
}
