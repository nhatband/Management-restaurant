﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLNH.CoSo;
using System.Windows.Media;
using QLNH.ThietKe.ObjectClass;
using System.Windows.Media.Imaging;
using QLNH.DanhMuc;
using QLNH.CauTruc;
using System.Windows.Documents;
using System.Windows.Controls;

namespace QLNH.ThietKe
{
    public partial class FrmDesignTable : FrmEditDetail
    {
        public FrmDesignTable()
        {
            InitializeComponent();
        }
        public FrmDesignTable(NHMain nhmain)
        {
            this.NHMain = nhmain;
            InitializeComponent();
            this.DataSet = new DataSet();
            this.DataTable = new DataTable();
            LoadData();
            BinControls();
            SetControls();
            iCombo.ComboBoxEdit.EditValueChanged += new EventHandler(ComboBoxEdit_EditValueChanged);
            this.iCombo.ComboBoxEdit.ItemIndex = 0;
            LoadingMap();
            this.iE.GridDesign.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(GridDesign_PreviewMouseLeftButtonDown);
            
        }
        public FrmDesignTable(NHMain nhmain, DataSet dataset, string nametable, bool isnew, int pos)
            : base(nhmain, nametable, dataset, pos, isnew)
        {
            InitializeComponent();
            BinControls();
            LoadData();
            SetControls();
            iCombo.ComboBoxEdit.EditValueChanged += new EventHandler(ComboBoxEdit_EditValueChanged);
            LoadingMap();
            this.iE.GridDesign.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(GridDesign_PreviewMouseLeftButtonDown);
        }
        void ComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            DataRow dr = this.DataSet.Tables["DM_FLOORS"].Rows.Find(this.iCombo.ComboBoxEdit.EditValue);
            if (dr != null)
            {
                byte[] t = (byte[])dr["IMAGE_FLOOR"];
                iE.LoadImage(t);
                LoadingMap();
            }
        }
        public void LoadingMap()
        {
            this.iE.GridDesign.Children.Clear();
            this.iE.Layers.Clear();
            foreach (DataRow i in this.DataSet.Tables["DS_LAYER"].Rows)
            {
                this.iE.Layers.Add(new Layer()
                 {
                     Layer_Id = Functions.PasteDouble(i["LAYER_ID"]),
                     Layer_Name = Functions.PasteString(i["LAYER_NAME"]),
                     Width = Functions.PasteDouble(i["WIDTH"]),
                     Height = Functions.PasteDouble(i["HEIGHT"]),
                     Opacity = Functions.PasteDouble(i["OPACITY"]),
                     Isvisible = Functions.PasteInt(i["VISIBLE"])
                 });

            }
            this.iE.Items.Clear();
            foreach (DataRow i in this.DataSet.Tables["DM_POSTION_TABLE"].Rows)
            {
                if (iCombo.ComboBoxEdit.EditValue != null)
                    if (i["VALUE_ID"].ToString() == iCombo.ComboBoxEdit.EditValue.ToString())
                        this.iE.Items.Add(new Item(i));
                // Trạng thái binding giữa datarow và item
            }
            this.iE.BindData();
            //for (int i = 0; i < this.iE.ObjectItem.Count; i++)
            //{
            //    this.iE.ObjectItem[i].MouseDown += new System.Windows.Input.MouseButtonEventHandler(FrmDesignTable_MouseDown);
            //}
        }

        void GridDesign_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataRow dr = null;
            if (iE.selectedElement != null)
            {
                dr = (iE.selectedElement as iItem).Item.DataRow;
                int i = this.DataTable.Rows.IndexOf(dr);
                bMgr = this.BindingContext[DataSet, "DM_POSTION_TABLE"];
                bMgr.Position = i;
                this.txtX.SpinEdit.EditValue = Canvas.GetLeft(iE.selectedElement);
                this.txtY.SpinEdit.EditValue = Canvas.GetTop(iE.selectedElement);
            }
        }
        public ImageSource LoadImage(string ImageSource)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(ImageSource, UriKind.RelativeOrAbsolute);
            src.EndInit();
            return src;
        }
        public override void LoadDm()
        {
            if (this.DataSet.Tables.IndexOf("DS_LAYER") >= 0) this.DataSet.Tables.Remove("DS_LAYER");
            this.DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DS_LAYER", "DS_LAYER"));
            if (this.DataSet.Tables.IndexOf("DM_TABLES") >= 0) this.DataSet.Tables.Remove("DM_TABLES");
            this.DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DM_TABLES", "DM_TABLES"));
            this.DataSet.Tables["DM_TABLES"].PrimaryKey = new[] { this.DataSet.Tables["DM_TABLES"].Columns["TABLE_ID"] };

            if (this.DataSet.Tables.IndexOf("DM_FLOORS") >= 0) this.DataSet.Tables.Remove("DM_FLOORS");
            this.DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DM_FLOORS where WORKSTATION_ID = 0", "DM_FLOORS"));
            this.DataSet.Tables["DM_FLOORS"].PrimaryKey = new[] { this.DataSet.Tables["DM_FLOORS"].Columns["VALUE_ID"] };
        }
        public override void LoadData()
        {
            try
            {
                LoadDm();
                if (NHMain.WorkingMode == WorkingMode.Online)
                {
                    this.DataSet.Tables.Add(this.NHMain.GetDataByQuery(@"
                                SELECT  a.TABLE_ID ,
                            a.VALUE_ID ,
                            a.VALUE_ID as VALUE_ID_TEMP ,
                            X ,
                            Y ,
                            PR_KEY ,
                            ENABLE ,
                            RGB ,
                            EX_LAYER ,
                            EX_OPACITY ,
                            EX_HEIGHT ,
                            EX_WIDTH ,
                            EX_TAGITEM ,
                            a.TABLE_NAME ,
                            TOTAL_CHAIR ,
                            RANK_ID ,
                            b.ACTIVE,
                            b.TABLE_IMAGE,
                            b.TABLE_NAME
                    FROM    dbo.DM_POSTION_TABLE a
                            INNER JOIN dbo.DM_TABLES b ON a.TABLE_ID = b.TABLE_ID", "DM_POSTION_TABLE"));
                    this.DataTable = this.DataSet.Tables["DM_POSTION_TABLE"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public override void SetControls()
        {
            this.iCombo.SetData(NHMain, "1=1", this.DataSet.Tables["DM_FLOORS"], "VALUE_ID", "VALUE_NAME", ComboBoxTypeView.NameID);
            this.iCombo.FrmDetail = new FrmDm_Floors_List(NHMain);
        }
        public override void BinControls()
        {
            this.txtValue_Name.TextBoxEdit.DataBindings.Add("EditValue", this.DataSet, "DM_POSTION_TABLE.TABLE_NAME");
            this.txtNum_Chair.SpinEdit.DataBindings.Add("EditValue", this.DataSet, "DM_POSTION_TABLE.TOTAL_CHAIR");
            //this.txtRank_id.DataBindings.Add("Text", this.DataSet, this.NameTable + ".RANK_ID");
            this.iCombo.ComboBoxEdit.DataBindings.Add("EditValue", this.DataSet, "DM_POSTION_TABLE.VALUE_ID_TEMP");
            this.txtH.SpinEdit.DataBindings.Add("EditValue", this.DataSet, "DM_POSTION_TABLE.EX_HEIGHT");
            this.txtW.SpinEdit.DataBindings.Add("EditValue", this.DataSet, "DM_POSTION_TABLE.EX_WIDTH");
            //this.txtX.SpinEdit.DataBindings.Add("EditValue", this.DataSet, "DM_POSTION_TABLE.X");
            //this.txtY.SpinEdit.DataBindings.Add("EditValue", this.DataSet, "DM_POSTION_TABLE.Y");
        }
        int i = 1;
        private int Table_id = 2;
        private void btnVuong_Click(object sender, EventArgs e)
        {
            DataRow dr = this.DataSet.Tables["DM_POSTION_TABLE"].NewRow();
            DataTable dt = NHMain.GetTables("DM_POSTION_TABLE");
            foreach (DataRow item in dt.Rows)
            {
                if (item["NameTP"].Equals("smallint") || item["NameTP"].Equals("int")
                    || item["NameTP"].Equals("bigint") || item["NameTP"].Equals("money"))
                    dr[item["nameCL"].ToString()] = 0;
                if (item["NameTP"].Equals("smalldatetime") || item["NameTP"].Equals("date") ||
                    item["NameTP"].Equals("datetime"))
                    dr[item["nameCL"].ToString()] = DateTime.Now.ToShortDateString();
            }
            dr["PR_KEY"] = NHMain.GetPr_Key("DM_POSTION_TABLE");
            dr["TABLE_ID"] = Table_id;
            dr["EX_LAYER"] = 0;
            dr["EX_OPACITY"] = 1;
            dr["EX_HEIGHT"] = 100;
            dr["EX_WIDTH"] = 100;
            dr["X"] = 100;
            //dr["Parent_Id"] = 100;
            dr["Y"] = 1;
            dr["EX_TAGITEM"] = "0";
            dr["VALUE_ID_TEMP"] = this.iCombo.ComboBoxEdit.EditValue; ;
            dr["VALUE_ID"] = this.iCombo.ComboBoxEdit.EditValue; ;
            bMgr = this.BindingContext[this.DataSet, "DM_POSTION_TABLE"];
            this.DataSet.Tables["DM_POSTION_TABLE"].Rows.Add(dr);
            bMgr.Position = this.DataSet.Tables["DM_POSTION_TABLE"].Rows.Count - 1;
            this.iE.AddItem(new Item(dr));
        }
        private BindingManagerBase bMgr;
        public override void SaveRecord()
        {
            this.EndEdit();
            for (int i = 0; i < this.DataTable.Rows.Count; i++)
            {
                if (this.DataTable.Rows[i].RowState == DataRowState.Added)
                {
                    this.DataTable.Rows[i]["PR_KEY"] = NHMain.GetPr_Key(this.DataTable.TableName);
                    this.DataTable.Rows[i]["VALUE_ID"] = this.iCombo.ComboBoxEdit.EditValue;
                    this.DataTable.Rows[i]["ENABLE"] = 1;
                }
            }
            //DataRow dr;
            //for (int i = 0; i < this.DataSet.Tables["DM_POSTION_TABLE"].Rows.Count; i++)
            //{
            //    dr = this.DataSet.Tables["DM_TABLES"].Rows.Find(this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["TABLE_ID"]);
            //    if (dr != null)
            //    {
            //        dr["TABLE_NAME"] = this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["TABLE_NAME"];
            //        dr["TOTAL_CHAIR"] = this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["TOTAL_CHAIR"];
            //        dr["RANK_ID"] = this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["RANK_ID"];
            //    }
            //    else
            //    {
            //        dr = this.DataSet.Tables["DM_TABLES"].NewRow();
            //        dr["TABLE_NAME"] = this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["TABLE_NAME"];
            //        dr["TOTAL_CHAIR"] = this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["TOTAL_CHAIR"];
            //        dr["RANK_ID"] = this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["RANK_ID"];
            //        dr["TABLE_ID"] = this.DataSet.Tables["DM_POSTION_TABLE"].Rows[i]["TABLE_ID"];
            //        this.DataSet.Tables["DM_TABLES"].Rows.Add(dr);
            //    }
            //}
            //NHMain.UpdateDataTable(this.DataSet.Tables["DM_TABLES"]);
            NHMain.UpdateDataTable(this.DataTable);
        }
        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            this.iE.RemoveItem();
        }
    }
}
