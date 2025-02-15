﻿namespace QLNH.BanHang
{
    partial class FrmSale
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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.Grid = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboExportType_Id = new QLNH.CauTruc.iComboBox();
            this.cboPayType_Id = new QLNH.CauTruc.iComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboTable_Id = new QLNH.CauTruc.iComboBox();
            this.cboCustomer_id = new QLNH.CauTruc.iComboBox();
            this.txtUser_Id = new QLNH.CauTruc.iTextBox();
            this.txtComment = new QLNH.CauTruc.iTextBox();
            this.txtTranDate = new QLNH.CauTruc.iCandenla();
            this.txtTranNo = new QLNH.CauTruc.iTextBox();
            this.txtCus_Tra = new QLNH.CauTruc.iSpinText();
            this.ckPro = new DevExpress.XtraEditors.CheckEdit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckPro.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ckPro);
            this.MainPanel.Controls.Add(this.txtCus_Tra);
            this.MainPanel.Controls.Add(this.groupControl2);
            this.MainPanel.Controls.Add(this.groupControl1);
            this.MainPanel.Controls.Add(this.txtUser_Id);
            this.MainPanel.Controls.Add(this.txtComment);
            this.MainPanel.Controls.Add(this.txtTranDate);
            this.MainPanel.Controls.Add(this.txtTranNo);
            this.MainPanel.Size = new System.Drawing.Size(563, 194);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(563, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Size = new System.Drawing.Size(563, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 418);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(563, 32);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 418);
            // 
            // Grid
            // 
            this.Grid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Grid.Location = new System.Drawing.Point(0, 226);
            this.Grid.MainView = this.gridView2;
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(563, 224);
            this.Grid.TabIndex = 4;
            this.Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.Grid;
            this.gridView2.Name = "gridView2";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboExportType_Id);
            this.groupControl2.Controls.Add(this.cboPayType_Id);
            this.groupControl2.Location = new System.Drawing.Point(285, 34);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(272, 91);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "Thanh toán";
            // 
            // cboExportType_Id
            // 
            this.cboExportType_Id.Caption = "Hình thức xuất";
            this.cboExportType_Id.FrmDetail = null;
            this.cboExportType_Id.LabelLengh = 95;
            this.cboExportType_Id.Location = new System.Drawing.Point(5, 61);
            this.cboExportType_Id.Name = "cboExportType_Id";
            this.cboExportType_Id.Size = new System.Drawing.Size(258, 22);
            this.cboExportType_Id.TabIndex = 3;
            // 
            // cboPayType_Id
            // 
            this.cboPayType_Id.Caption = "Hình thức th.toán";
            this.cboPayType_Id.FrmDetail = null;
            this.cboPayType_Id.LabelLengh = 95;
            this.cboPayType_Id.Location = new System.Drawing.Point(5, 33);
            this.cboPayType_Id.Name = "cboPayType_Id";
            this.cboPayType_Id.Size = new System.Drawing.Size(258, 22);
            this.cboPayType_Id.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboTable_Id);
            this.groupControl1.Controls.Add(this.cboCustomer_id);
            this.groupControl1.Location = new System.Drawing.Point(2, 34);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(277, 91);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Khách hàng";
            // 
            // cboTable_Id
            // 
            this.cboTable_Id.Caption = "Bàn";
            this.cboTable_Id.FrmDetail = null;
            this.cboTable_Id.LabelLengh = 95;
            this.cboTable_Id.Location = new System.Drawing.Point(10, 61);
            this.cboTable_Id.Name = "cboTable_Id";
            this.cboTable_Id.Size = new System.Drawing.Size(258, 22);
            this.cboTable_Id.TabIndex = 3;
            // 
            // cboCustomer_id
            // 
            this.cboCustomer_id.Caption = "Khách hàng";
            this.cboCustomer_id.FrmDetail = null;
            this.cboCustomer_id.LabelLengh = 95;
            this.cboCustomer_id.Location = new System.Drawing.Point(10, 33);
            this.cboCustomer_id.Name = "cboCustomer_id";
            this.cboCustomer_id.Size = new System.Drawing.Size(258, 22);
            this.cboCustomer_id.TabIndex = 2;
            // 
            // txtUser_Id
            // 
            this.txtUser_Id.Caption = "Người lập";
            this.txtUser_Id.Location = new System.Drawing.Point(434, 131);
            this.txtUser_Id.Name = "txtUser_Id";
            this.txtUser_Id.Size = new System.Drawing.Size(114, 22);
            this.txtUser_Id.TabIndex = 7;
            this.txtUser_Id.TextWidthLengh = 53;
            // 
            // txtComment
            // 
            this.txtComment.Caption = "Ghi chú";
            this.txtComment.Location = new System.Drawing.Point(11, 158);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(537, 22);
            this.txtComment.TabIndex = 4;
            this.txtComment.TextWidthLengh = 440;
            // 
            // txtTranDate
            // 
            this.txtTranDate.Caption = "Ngày chứng từ";
            this.txtTranDate.LabelLengh = 53;
            this.txtTranDate.Location = new System.Drawing.Point(290, 6);
            this.txtTranDate.Name = "txtTranDate";
            this.txtTranDate.Size = new System.Drawing.Size(258, 22);
            this.txtTranDate.TabIndex = 5;
            this.txtTranDate.TextLengh = 205;
            // 
            // txtTranNo
            // 
            this.txtTranNo.Caption = "Số chứng từ";
            this.txtTranNo.Location = new System.Drawing.Point(12, 6);
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.Size = new System.Drawing.Size(258, 22);
            this.txtTranNo.TabIndex = 6;
            this.txtTranNo.TextWidthLengh = 53;
            // 
            // txtCus_Tra
            // 
            this.txtCus_Tra.Caption = "Khách trả";
            this.txtCus_Tra.LabelLengh = 63;
            this.txtCus_Tra.Location = new System.Drawing.Point(11, 131);
            this.txtCus_Tra.Name = "txtCus_Tra";
            this.txtCus_Tra.Size = new System.Drawing.Size(268, 23);
            this.txtCus_Tra.TabIndex = 10;
            this.txtCus_Tra.TextLengh = 205;
            // 
            // ckPro
            // 
            this.ckPro.Location = new System.Drawing.Point(290, 132);
            this.ckPro.Name = "ckPro";
            this.ckPro.Properties.Caption = "Hoàn thành t.toán";
            this.ckPro.Size = new System.Drawing.Size(138, 19);
            this.ckPro.TabIndex = 11;
            // 
            // FrmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 478);
            this.Name = "FrmSale";
            this.Text = "FrmSale";
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckPro.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private CauTruc.iComboBox cboExportType_Id;
        private CauTruc.iComboBox cboPayType_Id;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private CauTruc.iComboBox cboTable_Id;
        private CauTruc.iComboBox cboCustomer_id;
        private CauTruc.iTextBox txtUser_Id;
        private CauTruc.iTextBox txtComment;
        private CauTruc.iCandenla txtTranDate;
        private CauTruc.iTextBox txtTranNo;
        private CauTruc.iSpinText txtCus_Tra;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl Grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.CheckEdit ckPro;
    }
}