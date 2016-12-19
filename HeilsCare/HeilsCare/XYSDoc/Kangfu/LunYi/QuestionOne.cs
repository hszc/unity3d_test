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

namespace XYS.Remp.Screening.Kangfu.LunYi
{
    public partial class QuestionOne : BaseForm
    {
        public QuestionOne()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            string strResult = "";

            if (rdA.Checked) strResult = "A,";
            if (rdB.Checked) strResult = "B,";
            if (rdC.Checked) strResult = "C,";
            if (rdD.Checked) strResult = "D,";

            question1.QuestionResult = strResult;
            question1.QuestionCode = QuestionnaireCode.KangFuLunYi + ".1";
            question1.QuestionType = 1;
            //打分
            if (strResult.Contains("A") || strResult.Contains("B"))
            {
                question1.QuestionScore = 5;
            }
            else
            {
                question1.QuestionScore = 0;
            }

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.KangFuLunYi);

            QuestionTwo frmNext = new QuestionTwo();
            frmNext.TopMost = false;
            frmNext.ShowDialog();
            //frmNext.Show();
            this.Close();
        }

        private void QuestionOne_Load(object sender, EventArgs e)
        {
            string answer = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuLunYi, QuestionnaireCode.KangFuLunYi + ".1");

            if (answer.Contains("A")) rdA.Checked = true;
            if (answer.Contains("B")) rdB.Checked = true;
            if (answer.Contains("C")) rdC.Checked = true;
            if (answer.Contains("D")) rdD.Checked = true;

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
            btnBack_Click(this, e);
        }
    }
}
