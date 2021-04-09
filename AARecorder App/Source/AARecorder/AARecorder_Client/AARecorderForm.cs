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

        //server funciton to record data from arma must receive the data byte length as a parameter and prepare the byte array

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
                    case "REQUESTING_RECORD":
                        button8.BackColor = Color.Red;
                        break;
                }
            }).Start();

        }

        private void ServerSend(NamedPipeServerStream thePipe, string theMessage, Button theButton)
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
            ClientSend(armaComC, "ARMA_READY", button12);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ServerSend(delphiComS, "AAR_READY", button4);
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
            ClientSend(armaComC, "REQUESTING_RECORD", button7);
        }
    }
    
}
