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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BgTaskForm form = new BgTaskForm(threadFunc);
            form.showDialog();
        }

        public void threadFunc(object inObject)
        {
            Form inForm = (Form)inObject;
            System.Threading.Thread t = new System.Threading.Thread(
                                        new System.Threading.ThreadStart((MethodInvoker)(() =>
                                        {
                                            System.Threading.Thread.Sleep(1000);
                                            Console.WriteLine("Complete2" + Environment.NewLine);
                                        })));
            t.Start();
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Complete1" + Environment.NewLine);
            t.Join();
            inForm.Invoke((MethodInvoker)(() => { inForm.Close(); }));
        }

    }
}
