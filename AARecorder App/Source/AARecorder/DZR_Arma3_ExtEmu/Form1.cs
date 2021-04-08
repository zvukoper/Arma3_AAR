using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZR_Arma3_ExtEmu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SEND_Click(object sender, EventArgs e)
        {
            var ArmaCommand = ScriptInput.Text;
            var CallbackData = DZR_AAR_extenstion.DllEntry.Invoke(ArmaCommand, 2000);
            Response.Items.Add(CallbackData);

        }
    }
}
