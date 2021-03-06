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

namespace XYS.Remp.Screening.Other.COPD
{
    public partial class CopdTwo : BaseForm
    {
        public CopdTwo()
        {
            InitializeComponent();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            var screenOtherSelect = new ScreenOtherSelect();
            screenOtherSelect.TopMost = false;
            screenOtherSelect.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            var quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //上一页
        private void btnBefore_Click(object sender, EventArgs e)
        {
            var copdOne=new CopdOne();
            copdOne.TopMost = false;
            copdOne.Show();
            Close();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //第三题
            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            string strResult3 = "";
            if (rbQ3A.Checked) { strResult3 = "A,"; }
            if (rbQ3B.Checked) { strResult3 = "B,"; }

            question3.QuestionResult = strResult3;
            question3.QuestionCode = QuestionnaireCode.Copd + ".3";
            question3.PQuestionCode = QuestionnaireCode.Copd + ".3";
            question3.QuestionType = 1;
            question3.QuestionScore = strResult3.Contains("A") ? 20 : 0;
            question3.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question3, QuestionnaireCode.Copd);

            //第四题
            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            string strResult4 = "";
            if (rbQ4A.Checked) { strResult4 = "A,"; }
            if (rbQ4B.Checked) { strResult4 = "B,"; }

            question4.QuestionResult = strResult4;
            question4.QuestionCode = QuestionnaireCode.Copd + ".4";
            question4.PQuestionCode = QuestionnaireCode.Copd + ".4";
            question4.QuestionType = 1;
            question4.QuestionScore = strResult4.Contains("A") ? 20 : 0;
            question4.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question4, QuestionnaireCode.Copd);

            //下一页
            var copdThree = new CopdThree();
            copdThree.TopMost = false;
            copdThree.Show();
            Close();
        }
        //加载
        private void CopdTwo_Load(object sender, EventArgs e)
        {
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".3");
            if (answer3.Contains("A")) { rbQ3A.Checked = true; }
            if (answer3.Contains("B")) { rbQ3B.Checked = true; }

            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".4");
            if (answer4.Contains("A")) { rbQ4A.Checked = true; }
            if (answer4.Contains("B")) { rbQ4B.Checked = true; }
        }

    }
}
