﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using QLNH.CoSo;

namespace QLNH.CoSo
{
    public partial class FrmDataList : Form
    {
        public delegate void SelectRowEventHandler(object sender, SelectRowEventArgs e);
        public event SelectRowEventHandler ChooseRow;
        public bool isSelect = false;
        public string Condition = "";
        public FrmDataList()
        {
            InitializeComponent();
        }
        public FrmDataList(NHMain nhmain, string nametable)
        {
            NHMain = nhmain;
            NameTable = nametable;
            InitializeComponent();
            try
            {
                //this.gridView1.RestoreLayoutFromXml(NHMain.StartUpPath + "\\Share\\" + NameTable + ".xml");
            }
            catch
            {

            }
            this.DataSet = new System.Data.DataSet();
            this.DataSet.DataSetName = nametable + "S";
            LoadData();
            this.gridView1.RefreshEditor(true);
            this.gridView1.RefreshData();
            this.gridControl1.Refresh();
            this.gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
            //LoadLayout();
            LoadLayout();
        }
        public string NameTable;
        public NHMain NHMain;
        public DataSet DataSet;
        public DataTable DataTable;
        public FrmEditDetail FrmEditDetail;
        public virtual void LoadLayout()
        {
            this.gridView1.Columns.Clear();
            GridColumn c = new GridColumn();
            DataTable dt;
            if (NHMain.WorkingMode == WorkingMode.Online)
                dt = this.NHMain.GetDataByQuery("select * from sys_field where visible = 1 and table_id = '" + NameTable + "'", "sys_field");
            else
            {
                NHMain.Xml = new XmlExecute(NHMain, "struct_" + NameTable);
                dt = NHMain.Xml.DataTable;
            }
            if (dt.Rows.Count < 1)
            {
                dt = NHMain.GetTables(NameTable);
                foreach (DataRow dr in dt.Rows)
                {
                    c = new GridColumn();
                    c.Name = dr["nameCL"].ToString();
                    c.FieldName = dr["nameCL"].ToString();
                    c.Caption = dr["nameCL"].ToString();
                    c.BestFit();
                    c.Visible = true;
                    c.VisibleIndex = 0;
                    c.OptionsColumn.AllowEdit = false;
                    c.OptionsColumn.AllowFocus = false;
                    this.gridView1.Columns.Add(c);
                }
                dt.Columns["nameCL"].ColumnName = "FIELD_ID";
                dt.Columns["nameTP"].ColumnName = "FIELD_TYPE";
                dt.Columns["nameTB"].ColumnName = "TABLE_ID";
                dt.Columns["User_Type_Id"].ColumnName = "FIELD_MAX";
                dt.Columns.Add(new DataColumn("FIELD_NAME"));
                dt.Columns.Add(new DataColumn("VISIBLE"));
                string l = "";
                foreach (DataRow item in dt.Rows)
                {
                    l += NHMain.InsertTo("SYS_FIELD", item);
                }
                NHMain.ExecuteNonQuery(l);
            }
            else
                foreach (DataRow dr in dt.Rows)
                {
                    c = new GridColumn();
                    c.Name = dr["Field_id"].ToString();
                    c.FieldName = dr["Field_id"].ToString();
                    c.Caption = dr["Field_name"].ToString();
                    c.BestFit();
                    c.Visible = true;
                    c.VisibleIndex = 0;
                    c.OptionsColumn.AllowEdit = false;
                    c.OptionsColumn.AllowFocus = false;
                    this.gridView1.Columns.Add(c);
                }
            this.gridView1.RefreshEditor(true);
            this.gridView1.RefreshData();
            this.gridControl1.Refresh();
        }
        public virtual void LoadData()
        {
            try
            {
                DataTable dtt = null;
                if (NHMain.WorkingMode == WorkingMode.Online)
                {
                    string sql = "select * from " + NameTable;
                    if (this.DataSet.Tables.IndexOf(NameTable) < 0)
                    {
                        dtt = this.NHMain.GetDataByQuery(sql, NameTable);
                        //if (dtt != null)
                        this.DataSet.Tables.Add(dtt);
                    }
                    else
                    {
                        dtt = this.NHMain.GetDataByQuery(sql, NameTable);
                        this.DataSet.Tables.Remove(NameTable);
                        this.DataSet.Tables.Add(dtt);
                    }
                    DataTable = this.DataSet.Tables[NameTable];
                    this.gridControl1.DataSource = DataTable;
                    this.gridView1.RefreshData();
                    NHMain.Xml = new XmlExecute(NHMain, DataTable);
                    DataTable dt = this.NHMain.GetDataByQuery("select * from sys_field where table_id = '" + NameTable + "'", NameTable);
                    dt.TableName = "struct_" + NameTable;
                    NHMain.Xml = new XmlExecute(NHMain, dt);

                }
                else
                {
                    NHMain.Xml = new XmlExecute(NHMain, NameTable);
                    if (this.DataSet.Tables.IndexOf(NameTable) < 0)
                        this.DataSet.Tables.Add(NHMain.Xml.DataTable);
                    else
                    {
                        this.DataSet.Tables.Remove(NameTable);
                        this.DataSet.Tables.Add(NHMain.Xml.DataTable);
                    }
                    DataTable = this.DataSet.Tables[NameTable];
                    this.gridControl1.DataSource = DataTable;
                    this.gridView1.RefreshData();
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }
        public virtual void NewRecord()
        {

        }
        public virtual void DeleteRecord()
        {
            string key = NHMain.ColumnPrimaryKey(NameTable);
            NHMain.ExecuteNonQuery(NHMain.DeleteTo(NameTable, this.gridView1.GetFocusedDataRow()));
            //NHMain.Xml.Delete(key, this.gridView1.GetFocusedDataRow());
            Refresh();
        }
        public DataRow NewRow()
        {
            return DataTable.NewRow();
        }
        public virtual void EditRecord()
        {
            try
            {
                FrmEditDetail.ShowDialog();
                this.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public DataRow GetDataRow()
        {
            return this.gridView1.GetFocusedDataRow();
        }
        public virtual void Export()
        {

        }
        public virtual void PrintRecord()
        {
            FrmReport f = new FrmReport(NHMain);
            f.LoadReport();
        }
        public virtual void ConfigRecord()
        {
            FrmConfig config = new FrmConfig(NHMain, NameTable);
            config.ShowDialog();
            LoadLayout();
        }

        private void btnConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfigRecord();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewRecord();
        }

        private void btnConfigOff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string dir = NHMain.StartUpPath + "\\Share\\" + NameTable + ".xml";
            if (!File.Exists(dir))
            {
                try
                {
                    File.Create(dir);
                    this.gridView1.SaveLayoutToXml(dir, OptionsLayoutBase.FullLayout);
                }
                catch
                {
                }

            }
            else
            {
                this.gridView1.SaveLayoutToXml(dir, OptionsLayoutBase.FullLayout);
            }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export();
            //SaveFile.ShowDialog();
            //this.gridView1.ExportToXls(SaveFile.FileName);
        }

        //private void gridControl1_DoubleClick(object sender, EventArgs e)
        //{
        //    if (!this.gridView1.OptionsBehavior.Editable)
        //    {
        //        GridView view = sender as GridView;
        //        if (view != null)
        //        {
        //            GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition));
        //            if (hi.RowHandle >= 0)
        //            {
        //                if (ChooseRow != null)
        //                {
        //                    ChooseRow(this.gridView1,
        //                              new SelectRowEventArgs(this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle)));
        //                }
        //            }
        //        }
        //    }
        //}
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (!isSelect)
            {
                EditRecord();
            }
            else
            { this.Close(); }
        }


        private static void DoRowDoubleClick(GridView view, Point pt)
        {

            GridHitInfo info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {

                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

                MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle,
        colCaption));

            }

        }
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.EditRecord();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Refresh();
        }
        public virtual void Refresh()
        {
            LoadData();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintRecord();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }
    }

    public class SelectRowEventArgs : EventArgs
    {
        private DataRow mrowvalue;

        public SelectRowEventArgs(DataRow dr)
        {
            this.mrowvalue = dr;
        }

        public DataRow rowvalue
        {
            get { return this.mrowvalue; }
        }
    }
}
