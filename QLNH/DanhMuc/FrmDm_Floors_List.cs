﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLNH.CoSo;

namespace QLNH.DanhMuc
{
    public partial class FrmDm_Floors_List : FrmDataList
    {
        public FrmDm_Floors_List(NHMain nhmain)
            : base(nhmain, "DM_FLOORS")
        {
            InitializeComponent();
        }
        public override void EditRecord()
        {
            this.FrmEditDetail = new FrmDm_Floors_Detail(NHMain, this.DataSet, "DM_FLOORS", false, this.DataSet.Tables[NameTable].Rows.IndexOf(this.GetDataRow()))
                                     {isNew = false};
            this.FrmEditDetail.ShowDialog();
        }
        public override void NewRecord()
        {
            this.FrmEditDetail = new FrmDm_Floors_Detail(NHMain, this.DataSet, "DM_FLOORS", true, 0);
            this.FrmEditDetail.ShowDialog();
        }
    }
}
