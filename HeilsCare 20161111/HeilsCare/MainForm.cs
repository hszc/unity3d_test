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
    public partial class MainForm : MetroForm
    {
        public static MainForm m_pMainWnd = new MainForm();
        public static bool m_isLegalUser=false;
        public bool m_isReadIdCard = false;

        public SharedDataAndMethod m_sharedDataAndMethod = new SharedDataAndMethod();
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Application.Idle += new EventHandler(Application_Idle);
        }

        private void m_MainFramemetroTileItem_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_INTERFACE_REGISTER);  //MSG_INTERFACE_REGISTER
            m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void Application_Idle(Object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_INTERFACE_UPDATE_UI);
            m_sharedDataAndMethod.SendMessage(m_message);
            m_pMainWnd = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_REGISTER_ID_CARD_INITIALIZE);
            m_sharedDataAndMethod.SendMessage(m_message);
        }
    }
}
