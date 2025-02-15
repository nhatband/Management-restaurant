﻿namespace QLNH.ThietKe
{
    partial class FrmDesignTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtY = new QLNH.CauTruc.iSpinText();
            this.txtH = new QLNH.CauTruc.iSpinText();
            this.txtW = new QLNH.CauTruc.iSpinText();
            this.txtX = new QLNH.CauTruc.iSpinText();
            this.grpInfo = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cboRank_Id = new QLNH.CauTruc.iComboBox();
            this.txtNum_Chair = new QLNH.CauTruc.iSpinText();
            this.txtValue_Name = new QLNH.CauTruc.iTextBox();
            this.btnXoaBan = new DevExpress.XtraEditors.SimpleButton();
            this.btnVuong = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.iCombo = new QLNH.CauTruc.iComboBox();
            this.iEle = new System.Windows.Forms.Integration.ElementHost();
            this.iE = new QLNH.ThietKe.iEnvironment();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpInfo)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.grpInfo);
            this.groupControl1.Controls.Add(this.btnXoaBan);
            this.groupControl1.Controls.Add(this.btnVuong);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 32);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(222, 494);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thuộc tính bàn";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtY);
            this.groupControl3.Controls.Add(this.txtH);
            this.groupControl3.Controls.Add(this.txtW);
            this.groupControl3.Controls.Add(this.txtX);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(2, 386);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(218, 78);
            this.groupControl3.TabIndex = 11;
            this.groupControl3.Text = "groupControl3";
            // 
            // txtY
            // 
            this.txtY.Caption = "Y";
            this.txtY.LabelLengh = 39;
            this.txtY.Location = new System.Drawing.Point(114, 25);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(99, 22);
            this.txtY.TabIndex = 0;
            this.txtY.TextLengh = 60;
            // 
            // txtH
            // 
            this.txtH.Caption = "Cao";
            this.txtH.LabelLengh = 39;
            this.txtH.Location = new System.Drawing.Point(114, 51);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(99, 22);
            this.txtH.TabIndex = 0;
            this.txtH.TextLengh = 60;
            // 
            // txtW
            // 
            this.txtW.Caption = "Dài";
            this.txtW.LabelLengh = 39;
            this.txtW.Location = new System.Drawing.Point(10, 51);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(99, 22);
            this.txtW.TabIndex = 0;
            this.txtW.TextLengh = 60;
            // 
            // txtX
            // 
            this.txtX.Caption = "X";
            this.txtX.LabelLengh = 39;
            this.txtX.Location = new System.Drawing.Point(10, 25);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(99, 22);
            this.txtX.TabIndex = 0;
            this.txtX.TextLengh = 60;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.simpleButton1);
            this.grpInfo.Controls.Add(this.cboRank_Id);
            this.grpInfo.Controls.Add(this.txtNum_Chair);
            this.grpInfo.Controls.Add(this.txtValue_Name);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Location = new System.Drawing.Point(2, 187);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(218, 199);
            this.grpInfo.TabIndex = 10;
            this.grpInfo.Text = "Thông tin bàn";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::QLNH.Properties.Resources._4438;
            this.simpleButton1.Location = new System.Drawing.Point(93, 109);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(120, 41);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Chọn ảnh";
            // 
            // cboRank_Id
            // 
            this.cboRank_Id.Caption = "Hạng bàn";
            this.cboRank_Id.FrmDetail = null;
            this.cboRank_Id.LabelLengh = 83;
            this.cboRank_Id.Location = new System.Drawing.Point(10, 82);
            this.cboRank_Id.Name = "cboRank_Id";
            this.cboRank_Id.Size = new System.Drawing.Size(203, 20);
            this.cboRank_Id.TabIndex = 2;
            // 
            // txtNum_Chair
            // 
            this.txtNum_Chair.Caption = "Số ghế";
            this.txtNum_Chair.LabelLengh = 83;
            this.txtNum_Chair.Location = new System.Drawing.Point(10, 55);
            this.txtNum_Chair.Name = "txtNum_Chair";
            this.txtNum_Chair.Size = new System.Drawing.Size(203, 23);
            this.txtNum_Chair.TabIndex = 1;
            this.txtNum_Chair.TextLengh = 120;
            // 
            // txtValue_Name
            // 
            this.txtValue_Name.Caption = "Tên bàn";
            this.txtValue_Name.Location = new System.Drawing.Point(10, 29);
            this.txtValue_Name.Name = "txtValue_Name";
            this.txtValue_Name.Size = new System.Drawing.Size(203, 20);
            this.txtValue_Name.TabIndex = 0;
            this.txtValue_Name.TextWidthLengh = 120;
            // 
            // btnXoaBan
            // 
            this.btnXoaBan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXoaBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXoaBan.Image = global::QLNH.Properties.Resources._4158;
            this.btnXoaBan.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnXoaBan.Location = new System.Drawing.Point(2, 132);
            this.btnXoaBan.Margin = new System.Windows.Forms.Padding(10);
            this.btnXoaBan.Name = "btnXoaBan";
            this.btnXoaBan.Padding = new System.Windows.Forms.Padding(5);
            this.btnXoaBan.Size = new System.Drawing.Size(218, 55);
            this.btnXoaBan.TabIndex = 9;
            this.btnXoaBan.Text = "Xóa bàn";
            this.btnXoaBan.Click += new System.EventHandler(this.btnXoaBan_Click);
            // 
            // btnVuong
            // 
            this.btnVuong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVuong.Image = global::QLNH.Properties.Resources.Box_Green1;
            this.btnVuong.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVuong.Location = new System.Drawing.Point(2, 77);
            this.btnVuong.Margin = new System.Windows.Forms.Padding(10);
            this.btnVuong.Name = "btnVuong";
            this.btnVuong.Padding = new System.Windows.Forms.Padding(5);
            this.btnVuong.Size = new System.Drawing.Size(218, 55);
            this.btnVuong.TabIndex = 7;
            this.btnVuong.Text = "Thêm bàn vuông";
            this.btnVuong.Click += new System.EventHandler(this.btnVuong_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.iCombo);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(2, 22);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(218, 55);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Tầng";
            // 
            // iCombo
            // 
            this.iCombo.Caption = "Tầng";
            this.iCombo.FrmDetail = null;
            this.iCombo.LabelLengh = 83;
            this.iCombo.Location = new System.Drawing.Point(10, 25);
            this.iCombo.Name = "iCombo";
            this.iCombo.Size = new System.Drawing.Size(203, 20);
            this.iCombo.TabIndex = 0;
            // 
            // iEle
            // 
            this.iEle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iEle.Location = new System.Drawing.Point(222, 32);
            this.iEle.Name = "iEle";
            this.iEle.Size = new System.Drawing.Size(477, 494);
            this.iEle.TabIndex = 5;
            this.iEle.Text = "elementHost1";
            this.iEle.Child = this.iE;
            // 
            // FrmDesignTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 526);
            this.Controls.Add(this.iEle);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmDesignTable";
            this.Text = "FrmDesignTable";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.iEle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpInfo)).EndInit();
            this.grpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Integration.ElementHost iEle;
        private iEnvironment iE;
        private DevExpress.XtraEditors.SimpleButton btnXoaBan;
        private DevExpress.XtraEditors.SimpleButton btnVuong;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private CauTruc.iComboBox iCombo;
        private DevExpress.XtraEditors.GroupControl grpInfo;
        private CauTruc.iComboBox cboRank_Id;
        private CauTruc.iSpinText txtNum_Chair;
        private CauTruc.iTextBox txtValue_Name;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private CauTruc.iSpinText txtY;
        private CauTruc.iSpinText txtX;
        private CauTruc.iSpinText txtH;
        private CauTruc.iSpinText txtW;
    }
}