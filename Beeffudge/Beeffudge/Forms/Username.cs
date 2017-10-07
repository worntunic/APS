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
    public partial class UsernameForm : Form
    {
        public string UsernameProp { get; set; }

        public UsernameForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsernameProp = textBox1.Text.ToString();
            Close();
        }
    }
}
