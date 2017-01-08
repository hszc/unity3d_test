using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using System.Runtime.InteropServices;

namespace HeilsCare
{
    public partial class MainForm : Form//Form  MetroForm
    {
        public static MainForm m_pMainWnd = new MainForm();
        public static MainForm m_pMainWndTemp = new MainForm();
        public static bool m_isLegalUser=false;
        public bool m_isReadIdCard = false;
        public string BaseDirectory = System.Environment.CurrentDirectory;

        public SharedDataAndMethod m_sharedDataAndMethod = new SharedDataAndMethod();

        #region 去掉Flash右键菜单，API函数的声明
        private const int GWL_WNDPROC = -4;
        public delegate IntPtr FlaWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private IntPtr OldWndProc = IntPtr.Zero;
        private FlaWndProc Wpr = null;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, FlaWndProc wndProc);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private IntPtr FlashWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == 516)   //516就是对应鼠标的右键，当然你也可以用0X0204右键鼠标的16进制编码
                return (IntPtr)0;   //什么都不做
            return CallWindowProc(OldWndProc, hWnd, msg, wParam, lParam);
        }
        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.Wpr = new FlaWndProc(this.FlashWndProc);
            this.OldWndProc = SetWindowLong(FlashPlayer.Handle, GWL_WNDPROC, Wpr);  //关联flash控件
            FlashPlayer.Movie = BaseDirectory+"\\f21.swf";
            FlashPlayer.Play();
            this.StartPosition = FormStartPosition.CenterScreen;
            Application.Idle += new EventHandler(Application_Idle);
            m_pMainWnd = this;
        }


        private void Application_Idle(Object sender, EventArgs e)
        {
            //处理更新UI
            //Message m_message = new Message(MessageType.MSG_INTERFACE_UPDATE_UI);
            //m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //身份证操作，暂时不用
            //Message m_message = new Message(MessageType.MSG_REGISTER_ID_CARD_INITIALIZE);
            //m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void m_MainFramemetroTileItemKangFuCao_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_GYMNASTIC_SHOW_FORM);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void metroTileItemLogin_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_INTERFACE_LOGIN);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void m_MainFramemetroTileItemRegister_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_INTERFACE_REGISTER);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_INTERFACE_CLOSE_FORM);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void metroTileItemLoQuestionaire_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_INTERFACE_QUESTIONARE_ONE);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_LOGIN_OUT);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void metroTileItemSystemAdmin_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_SYSTEM_ADMIN_MENU);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            MainContainerPanel.Left = (this.Width - MainContainerPanel.Width) / 2;
            MainContainerPanel.Top = (this.Height - MainContainerPanel.Height) / 2;
        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_LOGIN_OUT);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void m_MainFramemetroTileItemKangFuCao_Click_1(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_GYMNASTIC_SHOW_FORM);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

    }

}
