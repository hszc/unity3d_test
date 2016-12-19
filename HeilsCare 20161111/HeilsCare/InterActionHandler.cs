using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCare
{
    partial class InterActionHandler
    {
        public void HandleMessage(Message m_message)
        {
            switch(m_message.GetMessageType())
            {
                case MessageType.MSG_INTERFACE_PEOPLE_COUNT:
                    GetPeopleCount(m_message);
                    break;
                case MessageType.MSG_INTERFACE_REGISTER:
                    ShowRegisterForm(m_message);
                    break;
                case MessageType.MSG_INTERFACE_UPDATE_UI:
                    UpdateMainFrameUI(m_message);
                    break;
                case MessageType.MSG_REGISTER_ID_CARD_INITIALIZE:
                    InitializeDevice(m_message);
                    break;
                case MessageType.MSG_REGISTER_ID_CARD_READ_PROCESS:
                    StartReadProcess(m_message);
                    break;
                default:
                    break;
            }
        }
    }
}
