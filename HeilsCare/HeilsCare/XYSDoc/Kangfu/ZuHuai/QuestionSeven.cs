﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.ZuHuai
{
    public partial class QuestionSeven : BaseForm
    {
        public QuestionSeven()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            string strResult = "";

            if (chkA.Checked) strResult += "A,";
            if (chkB.Checked) strResult += "B,";
            if (chkC.Checked) strResult += "C,";
            if (chkD.Checked) strResult += "D,";
            if (chkE.Checked) strResult += "E,";

            M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();

            question.QuestionCode = Public.QuestionnaireCode.KangFuZuHuai + ".7";
            question.QuestionType = 2;//多选
            question.QuestionResult = strResult;
            //打分
            int tempScore = 0;
            if (strResult.Contains("A"))
            {
                tempScore += 5;
            }
            if (strResult.Contains("B"))
            {
                tempScore += 5;
            }
            if (strResult.Contains("C"))
            {
                tempScore += 5;
            }
            if (strResult.Contains("D"))
            {
                tempScore += 5;
            }
            if (tempScore > 10) tempScore = 10;
            question.QuestionScore = tempScore;

            ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.KangFuZuHuai);

            QuestionEight frmNext = new QuestionEight();
            frmNext.TopMost = false;
            frmNext.ShowDialog();
            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmMain = new ScreeningSelect();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this);
            quitComfirmFrm.ShowDialog();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionSix frmBefore = new QuestionSix();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }

        private void QuestionSeven_Load(object sender, EventArgs e)
        {
            string answer = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuZuHuai, QuestionnaireCode.KangFuZuHuai + ".7");

            if (answer.Contains("A")) chkA.Checked = true;
            if (answer.Contains("B")) chkB.Checked = true;
            if (answer.Contains("C")) chkC.Checked = true;
            if (answer.Contains("D")) chkD.Checked = true;
            if (answer.Contains("E")) chkE.Checked = true;
        }
    }
}
