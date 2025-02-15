﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace QLNH.CoSo
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();
        }
        NHMain NHMain;
        public DataTable DataTable = new DataTable();
        public FrmReport(NHMain nhmain)
        {
            NHMain = nhmain;
            InitializeComponent();
        }
        public virtual void LoadReport()
        {
            try
            {
                NHMain.Xml.LoadReport();

                WB.Url = new Uri(NHMain.StartUpPath + "\\BaoCao\\" + NHMain.Xml.NameTable + ".html");
                WB.Document.Encoding = "UTF-8";
                WB.IsWebBrowserContextMenuEnabled = false;
                this.ShowDialog();
                WB.Print();
                this.Dispose();
                //
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WB.Print();
        }
    }
}
