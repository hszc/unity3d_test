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

namespace HeilsCare
{
    public partial class MainForm : MetroForm//Form
    {
        public static MainForm m_pMainWnd = new MainForm();
        public static MainForm m_pMainWndTemp = new MainForm();
        public static bool m_isLegalUser=false;
        public bool m_isReadIdCard = false;

        public SharedDataAndMethod m_sharedDataAndMethod = new SharedDataAndMethod();
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Application.Idle += new EventHandler(Application_Idle);
            m_pMainWnd = this;
        }


        private void Application_Idle(Object sender, EventArgs e)
        {
            //Message m_message = new Message(MessageType.MSG_INTERFACE_UPDATE_UI);
            //m_sharedDataAndMethod.SendMessage(m_message);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //身份操作，暂时不用
            //Message m_message = new Message(MessageType.MSG_REGISTER_ID_CARD_INITIALIZE);
            //m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void m_MainFramemetroTileItemKangFuCao_Click(object sender, EventArgs e)
        {
           
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

    }
}
