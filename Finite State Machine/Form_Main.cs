using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finite_State_Machine
{
    public partial class Form_Main : Form
    {
        public bool[] keydown;
        public List<State> states;

        public Form_Main()
        {
            InitializeComponent();
            keydown = new bool[1000];
            states = new List<State>();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            
        }

        private void Form_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (keydown[(int)Keys.A])
            {
                State s = new State();
                s.X = e.X;
                s.Y = e.Y;
                states.Add(s);
                DrawStates();
            }
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("벌써 가시려구요!?", "FSM을 떠나기", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Environment.Exit(0);
                }
            }

            keydown[e.KeyValue] = true;
        }

        private void Form_Main_KeyUp(object sender, KeyEventArgs e)
        {
            keydown[e.KeyValue] = false;
        }

        private void DrawStates()
        {
            SolidBrush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.Blue, 2);
            Graphics g = this.CreateGraphics();
            
            foreach (var s in states)
            {
                g.FillEllipse(brush, new Rectangle(s.X - 25, s.Y - 25, 50, 50));
                g.DrawEllipse(pen, new Rectangle(s.X - 25, s.Y - 25, 50, 50));
                g.DrawString(s.Index.ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), s.X - 10, s.Y - 10);
            }
            brush.Dispose();
            g.Dispose();
        }
    }
}
