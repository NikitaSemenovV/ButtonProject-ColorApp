using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colorApp
{
    public partial class Form1 : Form
    {
      
        ToolTip to = new ToolTip();
        string color="3";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
           
        }
        private void Form_Load(object sender, EventArgs e)
        {
           
            trackBar1.Value = 128;
            trackBar2.Value = 128;
            trackBar3.Value = 128;
            trackBar1.ValueChanged+=val;
            trackBar2.ValueChanged += val;
            trackBar3.ValueChanged += val;
            col = Color.FromArgb(trackBar1.Value,
                trackBar2.Value,
                trackBar3.Value);
            pict.BackColor = col;
           // color = "#" + Convert.ToString(col.R, 16) + Convert.ToString(col.G, 16) + Convert.ToString(col.B, 16);
           // to.SetToolTip(pict, color);
        }

        Color col;
        private void val(object sender, EventArgs e)
        {
            TrackBar tr = (TrackBar)sender;
            col = Color.FromArgb(trackBar1.Value,
                trackBar2.Value,
                trackBar3.Value);
            pict.BackColor = col;
            pict.BackColor = col;
            color = "#" + Convert.ToString(col.R, 16) + Convert.ToString(col.G, 16) + Convert.ToString(col.B, 16);
            Clipboard.SetText(color);
            to.SetToolTip(pict, color);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
