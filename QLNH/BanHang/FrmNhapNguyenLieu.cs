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
    public partial class FrmNhapNguyenLieu : FrmTransaction
    {
        public FrmNhapNguyenLieu()
        {
            InitializeComponent();
        }
          public FrmNhapNguyenLieu(NHMain nhmain, DataSet dataset, string nametable, string nametable_n, double pr_key)
            : base(nhmain, dataset, nametable, nametable_n, pr_key)
        {
            InitializeComponent();
            LoadDm();
            BindGrid();
            SetControls();
            BindHearderControls();
        }
          public FrmNhapNguyenLieu(NHMain nhmain, DataSet dataset, string nametable, string nametable_n, bool isnew)
            : base(nhmain, dataset, nametable, nametable_n, isnew)
        {
            InitializeComponent();

            BindGrid();
            SetControls();
            BindHearderControls();
            if (NHMain.UserInfo != null)
                txtUser_Id.TextBoxEdit.EditValue = NHMain.UserInfo.User_Id;
            txtUser_Id.Enabled = false;
        }
        public override void BindHearderControls()
        {
            txtInvoice_No.TextBoxEdit.DataBindings.Add("EditValue", DataSet, NameTable_1 + ".TRAN_NO");
            txtUser_Id.TextBoxEdit.DataBindings.Add("EditValue", DataSet, NameTable_1 + ".USER_ID");
            txtComment.TextBoxEdit.DataBindings.Add("EditValue", DataSet, NameTable_1 + ".COMMENT");
            cboPay_Type_ID.ComboBoxEdit.DataBindings.Add("EditValue", DataSet, NameTable_1 + ".PAY_TPYE_ID");
            cboWarehouse_ID.ComboBoxEdit.DataBindings.Add("EditValue", DataSet, NameTable_1 + ".WAREHOUSE_ID");
        }
        public override void SetControls()
        {
            cboWarehouse_ID.SetData(NHMain, "", DataSet.Tables["DM_WAREHOUSES"], "WAREHOUSE_ID", "WAREHOUSE_NAME", ComboBoxTypeView.NameID);
            cboWarehouse_ID.FrmDetail = new FrmDm_Warehouses_List(NHMain);
            cboPay_Type_ID.SetData(NHMain, "", DataSet.Tables["DM_PAY_TYPE"], "PAY_TYPE_ID", "PAY_TYPE_NAME", ComboBoxTypeView.NameID);
            cboPay_Type_ID.FrmDetail = new FrmDm_Pay_List(NHMain);
        }
        public override void LoadDm()
        {
            try
            {
                if (DataSet.Tables.IndexOf("DM_PAY_TYPE") >= 0) DataSet.Tables.Remove("DM_PAY_TYPE");
                DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DM_PAY_TYPE", "DM_PAY_TYPE"));

                if (DataSet.Tables.IndexOf("DM_WAREHOUSES") >= 0) DataSet.Tables.Remove("DM_WAREHOUSES");
                DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DM_WAREHOUSES", "DM_WAREHOUSES"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
