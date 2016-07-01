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
                s.AddRule('0', 0, '0');
                s.AddRule('1', 0, '1');
                states.Add(s);
                MessageBox.Show($"State {s.Index} added.");
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
    }
}
