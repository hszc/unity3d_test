﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace HeilsCare
{
    partial class InterActionHandler
    {

        public void GetPeopleCount(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_PEOPLE_COUNT)
            {
                return;
            }
            //SQL连接
            MySqlConnection m_sqlCon = new MySqlConnection();
            m_sqlCon.ConnectionString = "server=localhost;database=heilscare;uid=root;pwd=heils";
            try
            {
                m_sqlCon.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接出错！ \r\n "+e.ToString());
                throw;
            }
            //SQL指令
            MySqlCommand m_sqlCommand = new MySqlCommand();
            m_sqlCommand.Connection = m_sqlCon;
            m_sqlCommand.CommandType = CommandType.Text;
            m_sqlCommand.CommandText = "SELECT * FROM UserTable where id=1";
            //SQL结果
            MySqlDataReader m_sqlReader = m_sqlCommand.ExecuteReader();//执行SQL语句

            while (m_sqlReader.Read())
            {
                MessageBox.Show(m_sqlReader["Name"].ToString());
            }

            m_sqlReader.Close();//关闭执行
            m_sqlCon.Close();//关闭数据库
        }

        public void ShowRegisterForm(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_REGISTER)
            {
                return;
            }
            RegisterForm m_registerForm = new RegisterForm();
            m_registerForm.Show();
        }

        public void UpdateMainFrameUI(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_UPDATE_UI)
            {
                return;
            }
           // MainForm mainForm = (MainForm)Control.FromHandle(Process.GetCurrentProcess().MainWindowHandle);
            if (MainForm.m_pMainWnd != null)
            {
                MainForm.m_pMainWnd.metroTileItemQuestion.Enabled = MainForm.m_isLegalUser;
                MainForm.m_pMainWnd.metroTileItemGym.Enabled = MainForm.m_isLegalUser;
                MainForm.m_pMainWnd.metroTileItemmotion.Enabled = MainForm.m_isLegalUser;
                MainForm.m_pMainWnd.metroTileItemSystemAdmin.Enabled = MainForm.m_isLegalUser;
            }
        }

        public void InitializeDevice(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_REGISTER_ID_CARD_INITIALIZE)
            {
                return;
            }
            CVRSDK.InitializeDevice();
            if(CVRSDK.iRetCOM==1 && CVRSDK.iRetUSB==1)
            {
                MainForm.m_pMainWnd.m_isReadIdCard = true;
                Message newMessage = new Message(MessageType.MSG_REGISTER_ID_CARD_READ_PROCESS);
                MainForm.m_pMainWnd.m_sharedDataAndMethod.SendMessage(newMessage);
            }
            return;
        }

        public delegate CVRSDK.CardInfo ReadCardHandler();
        public void StartReadProcess(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_REGISTER_ID_CARD_READ_PROCESS)
            {
                return;
            }
            ReadCardHandler mc = new ReadCardHandler(CVRSDK.ReadCard);
            IAsyncResult result = mc.BeginInvoke(null, null);
            CVRSDK.CardInfo m_cardInfo = mc.EndInvoke(result);//用于接收返回值 
            MessageBox.Show(m_cardInfo.address);
        }
    }
}
