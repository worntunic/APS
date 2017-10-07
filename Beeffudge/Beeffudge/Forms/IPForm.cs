using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beeffudge.Forms
{
    public partial class IPForm : Form
    {
        public string IP { get; set; }

        public IPForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IP = textBox1.Text.ToString();
            Close();
        }
    }
}
