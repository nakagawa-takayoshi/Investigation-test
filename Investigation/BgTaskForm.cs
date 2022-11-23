using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investigation
{
    public partial class BgTaskForm : Form
    {

        private Timer displayTimer = new Timer();

        public BgTaskForm()
        {
            InitializeComponent();
        }

        Action<object> threadFunc = null;

        public BgTaskForm(Action<object> inThreadFunc)
        {
            InitializeComponent();
            threadFunc = inThreadFunc;
        }

        private void BgTaskForm_Load(object sender, EventArgs e)
        {
            displayTimer.Tick += TimerElapsed;
            displayTimer.Interval = 2000;
            displayTimer.Enabled = true;
            var operationThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(threadFunc));
            operationThread.Start(this);
        }

        public DialogResult showDialog()
        {
            if (threadFunc != null)
            {
                this.Opacity = 0;
            }

            return ShowDialog();
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            displayTimer.Enabled = false;
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => { Opacity = 100; }));
            }
            else
            {
                this.Opacity = 1;
            }
        }
    }
}
