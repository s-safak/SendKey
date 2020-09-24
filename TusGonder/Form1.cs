using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TusGonder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        const int WM_SETTEXT = 0X000C;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x101;
        const int VK_F5 = 0x74;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;
        const int VK_0 = 0x30;  //0 key
        const int VK_1 = 0x31;  //1 key
        const int VK_2 = 0x32; //2 key
        const int VK_3 = 0x33;  //3 key
        const int VK_4 = 0x34;  //4 key
        const int VK_5 = 0x35;  //5 key
        const int VK_6 = 0x36;  //6 key
        const int VK_7 = 0x37;  //7 key
        const int VK_8 = 0x38;  //8 key
        const int VK_9 = 0x39;  //9 key
        
        #endregion

        IntPtr p_id = IntPtr.Zero;
        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    listBox1.Items.Add(p.MainWindowTitle);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    listBox1.Items.Add(p.MainWindowTitle);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            p_id = WinGetHandle(listBox1.SelectedItem.ToString());
            prg_id.Text = WinGetHandle(listBox1.SelectedItem.ToString()).ToString();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval=Convert.ToInt32(textBox2.Text) * 1000;
            timer1.Enabled = true;
            //SendMessage(WinGetHandle(listBox1.SelectedItem.ToString()), WM_SETTEXT, 0, "Eblek ati");
            //PostMessage(WinGetHandle(listBox1.SelectedItem.ToString()), WM_KEYDOWN, (int)Keys.A, 1);
        }
        public static IntPtr WinGetHandle(string wName)
        {
            IntPtr hwnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(wName))
                {
                    hwnd = pList.MainWindowHandle;
                }
            }
            return hwnd;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //IntPtr handle = new IntPtr(Convert.ToInt32(prg_id.Text, 16));
            //SetForegroundWindow(handle);
            //for (int i = 0; i < Convert.ToUInt32(textBox1.Text); i++)
            //{
            //    SendKeys.Send(textBox1.Text);
            //}
            //IntPtr handle = new IntPtr(Convert.ToInt32(prg_id.Text, 16));
            SetForegroundWindow(p_id);
            SendKeys.Send(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
