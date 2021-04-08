using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;

namespace DZR_Arma3_ExtEmu
{
    public partial class ArmaEmuForm : Form
    {
        public ArmaEmuForm()
        {
            InitializeComponent();
            ConnectToPipes();
        }

        private void ConnectToPipes()
        {
            //throw new NotImplementedException();
            
        }

        private void SEND_Click(object sender, EventArgs e)
        {
            var ArmaCommand = ScriptInput.Text;
            var CallbackData = DZR_AAR_extenstion.DllEntry.Invoke(ArmaCommand, 2000);
            Response.Items.Add(CallbackData);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DZR_AAR_extenstion.DllEntry.Invoke("[\"openComPipes\", \"NULL\"]", 2000);
        }
    }
}
