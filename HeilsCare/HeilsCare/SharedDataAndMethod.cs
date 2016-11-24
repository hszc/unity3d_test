using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCare
{
    class SharedDataAndMethod
    {
        private InterActionHandler m_InterInterActionHandler = new InterActionHandler();
        public void SendMessage(Message m_message)
        {
            //界面消息处理
            if( m_message.GetMessageType()>= MessageType.MSG_INTERFACE_MIN && m_message.GetMessageType() <= MessageType.MSG_INTERFACE_MAX)
            {
                m_InterInterActionHandler.HandleMessage(m_message);
                return;
            }

            //注册消息
            if (m_message.GetMessageType() >= MessageType.MSG_REGISTER_MIN && m_message.GetMessageType() <= MessageType.MSG_REGISTER_MAX)
            {
                return;
            }

            //登陆消息
            if (m_message.GetMessageType() >= MessageType.MSG_LOGIN_MIN && m_message.GetMessageType() <= MessageType.MSG_LOGIN_MAX)
            {
                return;
            }

            //问卷消息
            if (m_message.GetMessageType() >= MessageType.MSG_QUESTIONAR_MIN && m_message.GetMessageType() <= MessageType.MSG_QUESTIONAR_MAX)
            {
                return;
            }


            //体感操消息
            if (m_message.GetMessageType() >= MessageType.MSG_GYMNASTIC_MIN && m_message.GetMessageType() <= MessageType.MSG_GYMNASTIC_MAX)
            {
                return;
            }


            //运动控制消息
            if (m_message.GetMessageType() >= MessageType.MSG_MOTION_MIN && m_message.GetMessageType() <= MessageType.MSG_MOTION_MAX)
            {
                return;
            }

            //系统管理消息
            if (m_message.GetMessageType() >= MessageType.MSG_SYSTEM_ADMIN_MIN && m_message.GetMessageType() <= MessageType.MSG_SYSTEM_ADMIN_MIN)
            {
                return;
            }
        }
    }
}
