﻿using QLNH.CoSo;
using System;
using System.Windows.Forms;

namespace QLNH.BanHang
{
    public partial class FrmSale_Confirm_Listing : FrmDataList
    {
        public FrmSale_Confirm_Listing(NHMain nhmain)
            : base(nhmain, "SALE_CONFIRM_VIEW")
        {
            InitializeComponent();
        }

        public override void EditRecord()
        {
            try
            {
                FrmSale f = new FrmSale(NHMain, this.DataSet, "SALE", "SALE_DETAIL", double.Parse(this.GetDataRow()["FR_KEY"].ToString().Replace(",0000", "")));
                f.isNew = false;
                f.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public override void NewRecord()
        {
            FrmSale f = new FrmSale(NHMain, this.DataSet, "SALE", "SALE_DETAIL", true);
            f.isNew = true;
            f.ShowDialog();

        }
    }
}

