﻿using System.Data;
using System.Windows;
using DevExpress.XtraEditors;
using QLNH.CoSo;
using QLNH.HeThong;
using QLNH.DanhMuc;
using QLNH.BanHang;
using QLNH.ThietKe;

namespace QLNH
{
    public partial class MainForm : XtraForm
    {
        NHMain NHMain = new NHMain();
        public MainForm()
        {
            InitializeComponent();

            FrmLogin f = new FrmLogin(NHMain);
            NHMain.MainForm = f;
            f.ShowDialog();
            itmKhachhang.LinkClicked += this.itmKhachhang_LinkClicked;
            itmBan.LinkClicked += this.itmBan_LinkClicked;
            itmNhaCungCap.LinkClicked += this.itmNhaCungCap_LinkClicked;
            itmCa.LinkClicked += this.itmCa_LinkClicked;
            itmTang.LinkClicked += this.itmTang_LinkClicked;
            itmLoaiHinhXuat.LinkClicked += this.itmLoaiHinhXuat_LinkClicked;
            itmLoaiNguyenLieu.LinkClicked += this.itmLoaiNguyenLieu_LinkClicked;
            itmCus_Type.LinkClicked += this.itmCus_Type_LinkClicked;
            itmTypeCustomer.LinkClicked += this.itmTypeCustomer_LinkClicked;
            itmPay_Type.LinkClicked += this.itmPay_Type_LinkClicked;
            itmVat_Tax.LinkClicked += this.itmVat_Tax_LinkClicked;
            itmNguyenLieu.LinkClicked += this.itmNguyenLieu_LinkClicked;
            itmDonViTinh.LinkClicked += this.itmDonViTinh_LinkClicked;

            itmDmNhanVien.LinkClicked += this.itmDmNhanVien_LinkClicked;
            itmCaLamViec.LinkClicked += this.itmCaLamViec_LinkClicked;
            itmCapDo.LinkClicked += this.itmCapDo_LinkClicked;
            itmKhoHang.LinkClicked += this.itmKhoHang_LinkClicked;
            itmGiaBanHang.LinkClicked += this.itmGiaBanHang_LinkClicked;
            itmDmChiNhanh.LinkClicked += this.itmDmChiNhanh_LinkClicked;

            rptDsMonAn.LinkClicked += this.rptDsMonAn_LinkClicked;
            itmBanHang.LinkClicked += this.itmBanHang_LinkClicked;
            itmCheBien.LinkClicked += this.itmCheBien_LinkClicked;
            itmThietke.LinkClicked += this.itmThietke_LinkClicked;

            itmNhapNguyenLieu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(itmNhapNguyenLieu_LinkClicked);
            itmCheBien.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(itmCheBien_LinkClicked);
            itmHoanThanhBanHang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(itmHoanThanhBanHang_LinkClicked);
        }

        void itmHoanThanhBanHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmSale_Confirm_Listing m = new FrmSale_Confirm_Listing(NHMain) { MdiParent = this };
            m.Show();
        }

        void itmNhapNguyenLieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmNhapNguyenLieu_Listing m = new FrmNhapNguyenLieu_Listing(NHMain) { MdiParent = this };
            m.Show();
        }

        void itmThietke_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDesignTable m = new FrmDesignTable(NHMain);
            m.MdiParent = this;
            m.Show();
        }


        void itmCheBien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmCheBienMonAn_Listing m = new FrmCheBienMonAn_Listing(NHMain) { MdiParent = this };
            m.Show();
        }

        void itmBanHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmSale_Listing f = new FrmSale_Listing(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }


        void rptDsMonAn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            FrmSale_Price_Nearest_List f = new FrmSale_Price_Nearest_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        public void ConfigButton(bool val, bool val2)
        {
            itmDangNhap.Enabled = val;
            itmDangXuat.Enabled = val2;

        }
        //Danh sách các Form trong danh mục:
        // Gọi Form Danh mục loại khách hàng
        void itmTypeCustomer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_CustomerType_List f = new FrmDm_CustomerType_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi Form đơn vị tính
        void itmDonViTinh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Unit_List f = new FrmDm_Unit_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }

        // Gọi Form danh mục loại hình thanh toán
        void itmPay_Type_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Pay_List f = new FrmDm_Pay_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi Form danh mục loại khách hàng
        void itmCus_Type_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_CustomerType_List f = new FrmDm_CustomerType_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;

        }
        // Gọi form loại hình xuất
        void itmLoaiHinhXuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_ExportType_List f = new FrmDm_ExportType_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi form danh mục tầng
        void itmTang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Floors_List f = new FrmDm_Floors_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi form danh mục ca làm việc
        void itmCa_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Parts_List f = new FrmDm_Parts_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi form danh mục nhà cung cấp
        void itmNhaCungCap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Providers_List f = new FrmDm_Providers_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;

        }
        // Gọi form danh mục bàn
        void itmBan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Table_List f = new FrmDm_Table_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi form danh mục khách hàng
        private void itmKhachhang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Custumer_List f = new FrmDm_Custumer_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi Form danh mục chi nhánh
        void itmDmChiNhanh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_WorkStations_List f = new FrmDm_WorkStations_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }

        // Gọi form đăng nhập
        private void itmDangNhap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmLogin f = new FrmLogin(NHMain);
            f.ShowDialog();
            f.Visible = true;
            ConfigButton(false, true);
        }
        // Gọi form Đăng xuất
        private void itmDangXuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmLogin f = new FrmLogin(NHMain);
            f.ShowDialog();
            f.Visible = true;
            ConfigButton(false, false);
        }
        // Gọi form nguyên liệu
        private void itmNguyenLieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Item_List f = new FrmDm_Item_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }

        // Gọi form loại nguyên liệu
        private void itmLoaiNguyenLieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Item_Class_List f = new FrmDm_Item_Class_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Form mới
        // Gọi Form danh sách nhân viên
        void itmDmNhanVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Employees_List f = new FrmDm_Employees_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi Form danh mục ca làm việc
        void itmCaLamViec_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Employee_Part_List f = new FrmDm_Employee_Part_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi Form danh mục cấp độ
        void itmCapDo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Levels_List f = new FrmDm_Levels_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi Form danh mục kho hàng
        void itmKhoHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Warehouses_List f = new FrmDm_Warehouses_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi Form danh mục giá hàng bán
        void itmGiaBanHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDmSale_Price_List f = new FrmDmSale_Price_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // End
        private void itmDoiMatKhau_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DataTable dt = this.NHMain.GetDataByQuery("Select top 1 * from DM_EMPLOYEES where USER_ID = '" + NHMain.UserInfo.User_Id + "'", "DM_EMPLOYEES");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            FrmChangePass f = new FrmChangePass(NHMain, ds, "DM_EMPLOYEES") { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
        // Gọi form loại thuế
        private void itmVat_Tax_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmDm_Vat_Tax_List f = new FrmDm_Vat_Tax_List(NHMain) { MdiParent = this };
            f.Show();
            f.Visible = true;
        }
    }
}