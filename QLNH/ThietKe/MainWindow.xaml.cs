﻿using System;
using System.Data;
using System.Windows.Forms;
using QLNH.CoSo;

using QLNH.ThietKe.ObjectClass;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using QLNH.CauTruc;
using QLNH.DanhMuc;

namespace QLNH.ThietKe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private DataSet DataSet;
        private DataTable DataTable;
        public string Floor_Id = string.Empty;
        NHMain NHMain = new NHMain();
        iComboBox iCombo = new iComboBox();
        public MainWindow()
        {
            InitializeComponent();
            DataSet = new DataSet();
            this.cboFloor.Child = iCombo;
            iCombo.Caption = "Tầng: ";
            iCombo.ComboBoxEdit.EditValueChanged += new EventHandler(ComboBoxEdit_EditValueChanged);
            LoadData();
            SetControls();
            this.iCombo.ComboBoxEdit.ItemIndex = 0;
            LoadingMap();
        }

        void ComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            DataRow dr = this.DataSet.Tables["DM_FLOORS"].Rows.Find(this.iCombo.ComboBoxEdit.EditValue);
            byte[] t = (byte[])dr["IMAGE_FLOOR"];
            iE.LoadImage(t);
            LoadingMap();
        }
        public void LoadData()
        {
            try
            {
                LoadDm();
                if (NHMain.WorkingMode == WorkingMode.Online)
                {
                    this.DataSet.Tables.Add(this.NHMain.GetDataByQuery(@"
                        SELECT   a.TABLE_ID ,
                                a.VALUE_ID ,
                                X ,
                                Y ,
                                PR_KEY,
                                ENABLE ,
                                RGB ,
                                IMAGE ,
                                EX_LAYER ,
                                EX_OPACITY ,
                                EX_HEIGHT ,
                                EX_WIDTH ,
                                EX_TAGITEM ,
                                TABLE_NAME ,
                                TOTAL_CHAIR ,
                                RANK_ID ,
                                b.ACTIVE ,
                                b.VALUE_ID
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
        public void SetControls()
        {
            this.iCombo.SetData(NHMain, "1=1", this.DataSet.Tables["DM_FLOORS"], "VALUE_ID", "VALUE_NAME", ComboBoxTypeView.NameID);
            this.iCombo.FrmDetail = new FrmDm_Floors_List(NHMain);
        }
        public void LoadDm()
        {
            if (this.DataSet.Tables.IndexOf("DS_LAYER") > 0) this.DataSet.Tables.Remove("DS_LAYER");
            this.DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DS_LAYER", "DS_LAYER"));

            if (this.DataSet.Tables.IndexOf("DM_FLOORS") > 0) this.DataSet.Tables.Remove("DM_FLOORS");
            this.DataSet.Tables.Add(NHMain.GetDataByQuery("select * from DM_FLOORS where WORKSTATION_ID = 0", "DM_FLOORS"));
            this.DataSet.Tables["DM_FLOORS"].PrimaryKey = new[] { this.DataSet.Tables["DM_FLOORS"].Columns["VALUE_ID"] };
        }
        public void LoadingMap()
        {
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
        }
        public ImageSource LoadImage(string ImageSource)
        {
            Image i = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(ImageSource, UriKind.RelativeOrAbsolute);
            src.EndInit();
            return src;
        }
        private int i = 2;
        private void AddNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataRow dr = this.DataSet.Tables["DM_POSTION_TABLE"].NewRow();
            dr["PR_KEY"] = NHMain.GetPr_Key("DM_POSTION_TABLE");
            dr["TABLE_ID"] = i++;
            dr["EX_LAYER"] = 0;
            dr["EX_OPACITY"] = 1;
            dr["EX_HEIGHT"] = 100;
            dr["EX_WIDTH"] = 100;
            dr["X"] = 100;
            //dr["Parent_Id"] = 100;
            dr["Y"] = 1;
            dr["EX_TAGITEM"] = "0";
            this.DataSet.Tables["DM_POSTION_TABLE"].Rows.Add(dr);
            this.iE.AddItem(new Item(dr));
        }

        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            for (int i = 0; i < this.DataTable.Rows.Count; i++)
            {
                if (this.DataTable.Rows[i].RowState == DataRowState.Added)
                {
                    this.DataTable.Rows[i]["PR_KEY"] = NHMain.GetPr_Key(this.DataTable.TableName);
                    this.DataTable.Rows[i]["VALUE_ID"] = this.iCombo.ComboBoxEdit.EditValue;
                    this.DataTable.Rows[i]["ENABLE"] = 1;
                }
            }
            NHMain.UpdateDataTable(this.DataTable);
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.iE.RemoveItem();
        }
    }
}
