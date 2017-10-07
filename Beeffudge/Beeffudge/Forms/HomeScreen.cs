using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeroMQ;

namespace Beeffudge.Forms
{
    public partial class HomeScreen : Form
    {
        private string Name { get; set; }
        private string IP { get; set; }

        public HomeScreen()
        {
            InitializeComponent();

            Name = GetUsername();
            IP = GetIP();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string GetUsername()
        {
            UsernameForm userForm = new UsernameForm();
            userForm.MdiParent = this;
            userForm.ShowDialog();

            return userForm.UsernameProp;
        }

        private string GetIP() {
            IPForm ipForm = new IPForm();
            ipForm.ShowDialog();

            return ipForm.IP;
        }

        private void btnHostGame_Click(object sender, EventArgs e)
        {
            // Show 'PLAY' button = true:
            Lobby lobby = new Lobby(Name, IP, true);
            lobby.MdiParent = this;
            lobby.Show();
        }
        
        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            Lobby lobby = new Lobby(Name, IP);
            lobby.MdiParent = this;
            lobby.Show();
        }
    }
}
