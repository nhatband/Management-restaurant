﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLNH.CoSo;
using QLNH.CauTruc;
using QLNH.DanhMuc;

namespace QLNH.BanHang
{
    public partial class FrmCheBienMonAn : FrmTransaction
    {
        public FrmCheBienMonAn()
        {
            InitializeComponent();
        }
        public FrmCheBienMonAn(NHMain nhmain, DataSet dataset, string nametable, string nametable_n, double pr_key)
            : base(nhmain, dataset, nametable, nametable_n, pr_key)
        {
            InitializeComponent();
            LoadDm();
            this.BindGrid();
            SetControls();
            this.BindHearderControls();
        }

        public FrmCheBienMonAn(NHMain nhmain, DataSet dataset, string nametable, string nametable_n, bool isnew)
            : base(nhmain, dataset, nametable, nametable_n, isnew)
        {
            InitializeComponent();

            this.BindGrid();
            SetControls();
            this.BindHearderControls();
            if (NHMain.UserInfo != null)
            txtUser_Id.TextBoxEdit.EditValue = NHMain.UserInfo.User_Id;
            txtUser_Id.Enabled = false;
        }
        public override void BindHearderControls()
        {
            this.txtInvoice_No.TextBoxEdit.DataBindings.Add("EditValue", this.DataSet, this.NameTable_1 + ".TRAN_NO");
            //this.txtUser_Id.DataBindings.Add("EditValue", this.DataSet, this.NameTable_1 + ".USER_ID");
            this.txtComment.TextBoxEdit.DataBindings.Add("EditValue", this.DataSet, this.NameTable_1 + ".COMMENT");
            //this.cboPay_Type_ID.ComboBoxEdit.DataBindings.Add("EditValue", this.DataSet, this.NameTable_1 + ".PAY_TYPE_ID");
            cboWarehouse_ID.ComboBoxEdit.DataBindings.Add("EditValue", this.DataSet, this.NameTable_1 + ".WAREHOUSE_ID");
        }
        public override void SetControls()
        {
            this.cboWarehouse_ID.SetData(NHMain, "", this.DataSet.Tables["DM_WAREHOUSES"], "WAREHOUSE_ID", "WAREHOUSE_NAME", ComboBoxTypeView.NameID);
            this.cboWarehouse_ID.FrmDetail = new FrmDm_Warehouses_List(NHMain);
            //this.cboPay_Type_ID.SetData(NHMain, "", this.DataSet.Tables["DM_PAY_TYPE"], "PAY_TYPE_ID", "PAY_TYPE_NAME", ComboBoxTypeView.NameID);
            //this.cboPay_Type_ID.FrmDetail = new FrmDm_Pay_List(NHMain);
        }
        public override void LoadDm()
        {
            try
            {
                //if (this.DataSet.Tables.IndexOf("DM_PAY_TYPE") >= 0) this.DataSet.Tables.Remove("DM_PAY_TYPE");
                //this.DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DM_PAY_TYPE", "DM_PAY_TYPE"));

                if (this.DataSet.Tables.IndexOf("DM_WAREHOUSES") >= 0) this.DataSet.Tables.Remove("DM_WAREHOUSES");
                this.DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DM_WAREHOUSES", "DM_WAREHOUSES"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
