using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CC2_V2
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client c = new client();
            c.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reservation r = new reservation();
            r.Show();
        }
    }
}
