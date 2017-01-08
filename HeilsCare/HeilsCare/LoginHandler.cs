using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZedGraph;

namespace HeilsCare
{
    class LoginHandler
    {
        public void HandleMessage(Message m_message)
        {
            switch (m_message.GetMessageType())
            {
                case MessageType.MSG_LOGIN_SHOW_USER_INFO:
                    ShowUerInfo(m_message);
                    break;
                case MessageType.MSG_LOGIN_OUT:
                    LogOut(m_message);
                    break;
                case MessageType.MSG_SHOW_HISTROTY_DATA:
                    ShowUserHistoryData(m_message);
                    break;
                default:
                    break;
            }
        }

        private void LogOut(Message m_message)
        {
            XYS.Remp.Screening.Public.ClientInfo.Logout();
            MainForm.m_isLegalUser = false;
            MainForm.m_pMainWnd.userInfo.Text = "    " ;
            MainForm.m_pMainWnd.LoginPanel.Visible = true;
            MainForm.m_pMainWnd.LogOutPanel.Visible = false;
            MainForm.m_pMainWnd.BloodPressure.Visible = false;
            //MainForm.m_pMainWnd.WelcomLogo.Visible = true;
            MainForm.m_pMainWnd.FlashPlayer.Visible = true;
        }

        private void ShowUerInfo(Message m_message)
        {
            string username = m_message.GetString();
            MainForm.m_pMainWnd.userInfo.Text="欢迎您:"+username;
            MainForm.m_pMainWnd.LoginPanel.Visible = false;
            MainForm.m_pMainWnd.LogOutPanel.Visible = true;
            MainForm.m_pMainWnd.FlashPlayer.Visible = false;
        }

        private void ShowUserHistoryData(Message m_message)
        {
            string m_userName = m_message.GetString();
            //根据username从数据库中得到历史数据
            //MainForm.m_pMainWnd.WelcomLogo.Visible = false;
            MainForm.m_pMainWnd.BloodPressure.Visible = true;
            MainForm.m_pMainWnd.BloodPressure.GraphPane.XAxis.ScaleFontSpec.Size = 20;//设置x轴的文字大小.
            MainForm.m_pMainWnd.BloodPressure.GraphPane.YAxis.ScaleFontSpec.Size = 20;//设置y轴的文字大小.
            MainForm.m_pMainWnd.BloodPressure.GraphPane.XAxis.TitleFontSpec.Size = 20;
            MainForm.m_pMainWnd.BloodPressure.GraphPane.YAxis.TitleFontSpec.Size = 20;
            MainForm.m_pMainWnd.BloodPressure.GraphPane.XAxis.Title="日期";
            MainForm.m_pMainWnd.BloodPressure.GraphPane.YAxis.Title = "血压";
            MainForm.m_pMainWnd.BloodPressure.IsShowPointValues = true;
            MainForm.m_pMainWnd.BloodPressure.GraphPane.FontSpec.Size = 20;
            MainForm.m_pMainWnd.BloodPressure.GraphPane.Title = "血压变化曲线";

            //MainForm.m_pMainWnd.BloodPressure.GraphPane.YAxis.major = true;//设置虚线.
            //MainForm.m_pMainWnd.BloodPressure.GraphPane.Chart.Border.IsVisible = false;//图表区域的边框设置.
            MainForm.m_pMainWnd.BloodPressure.GraphPane.Legend.IsVisible = false;//图表的注释标签显示设置项目.

            double[] x = new double[100];
            double[] y = new double[100];
            int i;
            for (i = 0; i < 100; i++)
            {
                x[i] = (double)i / 100.0 * Math.PI * 2.0;
                y[i] = Math.Sin(x[i]);
            }
            MainForm.m_pMainWnd.BloodPressure.GraphPane.AddCurve("Sine Wave", x, y, Color.Red, SymbolType.Square);
            MainForm.m_pMainWnd.BloodPressure.AxisChange();
            MainForm.m_pMainWnd.BloodPressure.Invalidate();
        }


    }
}
