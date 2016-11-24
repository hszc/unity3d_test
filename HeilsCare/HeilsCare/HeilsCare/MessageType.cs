using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCare
{
    class MessageType
    {
        /*******************************************************************
         * 软件界面消息
         ********************************************************************/
        public const int MSG_INTERFACE_MIN = 0x1000;
        public const int MSG_INTERFACE_MAX = 0x1fff;
        //测试 just
        public const int MSG_INTERFACE_PEOPLE_COUNT = 0x1002;
        //显示注册表单
        public const int MSG_INTERFACE_REGISTER = 0x1003;
        //更新界面UI是否可用
        public const int MSG_INTERFACE_UPDATE_UI = 0x1004;


        /*******************************************************************
         * 注册用户消息
         ********************************************************************/
        public const int MSG_REGISTER_MIN = 0x2000;
        public const int MSG_REGISTER_MAX = 0x2fff;


        /*******************************************************************
         * 登录消息
        ********************************************************************/
        public const int MSG_LOGIN_MIN = 0x3000;
        public const int MSG_LOGIN_MAX = 0x3fff;

        /*******************************************************************
         * 问卷消息
         ********************************************************************/
        public const int MSG_QUESTIONAR_MIN = 0x4000;
        public const int MSG_QUESTIONAR_MAX = 0x4fff;


        /*******************************************************************
         * 体感操消息
        ********************************************************************/
        public const int MSG_GYMNASTIC_MIN = 0x5000;
        public const int MSG_GYMNASTIC_MAX = 0x5fff;


        /*******************************************************************
         * 运动控制消息
         ********************************************************************/
        public const int MSG_MOTION_MIN = 0x6000;
        public const int MSG_MOTION_MAX = 0x6fff;


        /*******************************************************************
         * 系统管理消息
        ********************************************************************/
        public const int MSG_SYSTEM_ADMIN_MIN = 0x7000;
        public const int MSG_SYSTEM_ADMIN_MAX = 0x7fff;
    }
}
