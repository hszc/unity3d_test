﻿namespace XYS.Remp.Screening.Kangfu.Ankle._1._0
{
    partial class Result
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Result));
            this.lblVisitor = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.timerPrint = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlTips = new System.Windows.Forms.Panel();
            this.pnlAction.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTips.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.Size = new System.Drawing.Size(166, 0);
            // 
            // btnBefore
            // 
            this.btnBefore.FlatAppearance.BorderSize = 0;
            this.btnBefore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBefore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBefore.Size = new System.Drawing.Size(166, 0);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(109)))), ((int)(((byte)(158)))));
            this.btnBack.Visible = false;
            // 
            // pnlAction
            // 
            this.pnlAction.AutoSize = true;
            this.pnlAction.Location = new System.Drawing.Point(0, 848);
            this.pnlAction.Size = new System.Drawing.Size(1280, 0);
            this.pnlAction.Visible = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pictureBox1);
            this.pnlContent.Controls.Add(this.lblVisitor);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.pnlTips);
            this.pnlContent.Controls.Add(this.lblResult);
            this.pnlContent.Controls.Add(this.btnPrintPreview);
            this.pnlContent.Controls.Add(this.btnPrint);
            this.pnlContent.Size = new System.Drawing.Size(1155, 689);
            // 
            // lblVisitor
            // 
            this.lblVisitor.AutoSize = true;
            this.lblVisitor.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVisitor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblVisitor.Location = new System.Drawing.Point(254, 12);
            this.lblVisitor.Name = "lblVisitor";
            this.lblVisitor.Size = new System.Drawing.Size(117, 28);
            this.lblVisitor.TabIndex = 35;
            this.lblVisitor.Text = "游客编号：";
            this.lblVisitor.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblResult.Location = new System.Drawing.Point(254, 46);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(107, 26);
            this.lblResult.TabIndex = 32;
            this.lblResult.Text = "筛查结果：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XYS.Remp.Screening.Properties.Resources.result;
            this.pictureBox1.Location = new System.Drawing.Point(20, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 336);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Font = new System.Drawing.Font("宋体", 24F);
            this.btnPrintPreview.Location = new System.Drawing.Point(378, 677);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(162, 52);
            this.btnPrintPreview.TabIndex = 38;
            this.btnPrintPreview.Text = "打印预览";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(672, 677);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(162, 52);
            this.btnPrint.TabIndex = 37;
            this.btnPrint.Text = "打印结果";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // timerPrint
            // 
            this.timerPrint.Interval = 1000;
            this.timerPrint.Tick += new System.EventHandler(this.timerPrint_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(254, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 34;
            this.label1.Text = "健康小贴士：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "1.选择穿合适的鞋是保障足部健康的先决条件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(42, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(749, 105);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "2.简单的足部放松";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(42, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(749, 105);
            this.label4.TabIndex = 4;
            this.label4.Text = "* 爱穿高跟鞋的女士们可以在办公室换上平底鞋或拖鞋，坐在凳子上，双腿略分开，把脚平放在地上。先\r\n  把脚跟提起，到最大限度，坚持5秒，然后还原。整个动作过程要缓" +
    "慢，感觉到跟腱循序渐进地被拉伸，\r\n  最少重复10次。\r\n* 足疗给足部以良性刺激，使局部血管扩张，也是一种有效的缓解手段。\r\n* 晚上回家脱下鞋时，可以给累" +
    "了一天的脚做做按摩，舒缓僵硬的踝关节。";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(53, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(730, 84);
            this.label7.TabIndex = 6;
            this.label7.Text = "足部辅具作为一种以减轻足底骨骼肌肉系统的功能障碍为目的的辅助器具，包括矫形鞋、矫形鞋垫，是\r\n国际上公认的最有效的改善和医治足部病变的方法。常用于通过控制距下关节" +
    "的内外翻等减少髋关节、\r\n膝关节、踝关节及脊柱的受力并吸收部分地面反作用力；减少溃疡、趾骨疼痛；支撑足弓，辅助步行；\r\n为糖尿病、脑卒中、关节炎等提供合理的足部" +
    "承载力。";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(25, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 27);
            this.label9.TabIndex = 7;
            this.label9.Text = "3.足部辅具的应用";
            // 
            // pnlTips
            // 
            this.pnlTips.Controls.Add(this.label9);
            this.pnlTips.Controls.Add(this.label7);
            this.pnlTips.Controls.Add(this.label4);
            this.pnlTips.Controls.Add(this.label5);
            this.pnlTips.Controls.Add(this.label3);
            this.pnlTips.Controls.Add(this.label2);
            this.pnlTips.Location = new System.Drawing.Point(259, 237);
            this.pnlTips.Name = "pnlTips";
            this.pnlTips.Size = new System.Drawing.Size(800, 410);
            this.pnlTips.TabIndex = 33;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1280, 912);
            this.Name = "Result";
            this.Opacity = 1D;
            this.pnlAction.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTips.ResumeLayout(false);
            this.pnlTips.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVisitor;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Timer timerPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTips;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
