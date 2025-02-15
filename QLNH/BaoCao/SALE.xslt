﻿<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html"  version="1.0" indent="yes" encoding="UTF-8"/>

  <xsl:template match="@* | node()">
    <HTML>
      <body>
        <table border="0" width="100%">
          <tr>
            <td align="left" width="30%">
              <b>NHÀ HÀNG SƠN CƯỚC</b>
            </td>
            <td align="center" width="20%"></td>
            <td align="center" width="50%">CONG HOA XA HOI CHU NGHIA VIET NAM</td>
          </tr>
          <tr>
            <td align="left">Phiếu số:</td>
            <td align="center"></td>
            <td align="center">Độc Lập - Tự Do - Hạnh Phúc</td>
          </tr>
        </table>
        <p align="center">
          <b>
            <font size="5">PHIẾU XUẤT</font>
          </b>
        </p>
        <p></p>

        <table border="0" width="100%">

          <tr>
            <td align="left" width="30%">
              Số chứng từ: 
              <xsl:value-of select="SALE/TRAN_NO"/>

            </td>
            <td align="left" width="5%"></td>
            <td align="left" width="30%">
              Mã nhân viên: 
                <xsl:value-of select="USER_ID"/>
            </td>
            <td align="left" width="5%"></td>
            <td align="left" width="30%">
              Tổng giá trị: <xsl:value-of select="SALE/TOTAL_PRICE"/>
            </td>
          </tr>
          <tr>
            <td align="left">
              Ngày chứng từ: <xsl:value-of select="SALE/TRAN_DATE"/>
            </td>
            <td align="left"></td>
            <td align="left">
              Mã khách hàng: <xsl:value-of select="SALE/CUSTOMER_ID"/>
            </td>
            <td align="left"></td>
            <td align="left">"/>
            </td>
          </tr>
          <tr>
            <td align="left">Số tiền khách đưa: <xsl:value-of select="SALE/TOTAL_CUSTOMER_PAY"/></td>
            <td align="left">Loại chứng từ: <xsl:value-of select="SALE/TRAN_ID"/></td>
            <td align="left"></td>
            <td align="left">
              Loại hình xuất: <xsl:value-of select="SALE/EXPORT_TYPE_ID"/>
            </td>
            <td align="left"></td>
            <td align="left">
              Tạm tính: <xsl:value-of select="SALE/IS_PROVISIONAL"/>
            </td>
          </tr>
          <tr>
            <td align="left"></td>
            <td align="left"></td>
            <td align="left">
              Loại hình thanh toán: <xsl:value-of select="SALE/PAY_TYPE_ID"/>
            </td>
            <td align="left"></td>
            <td align="left"></td>
          </tr>
          <tr>
            <td colspan="5">
              <p align="left">
                Ghi chú: <xsl:value-of select="SALE/COMMENT"/>
              </p>
            </td>
          </tr>

        </table>

        <p></p>
        <table border="1" width="100%" id="table1" style="border-collapse: collapse" bordercolor="#000000">
          <tr>
            <td align="center" width="10%">
              <b>STT</b>
            </td>
            <td align="center" width="10%">
              <b>Mã món</b>
            </td>
            <td align="center" width="40%">
              <b>Tên món</b>
            </td>
            <td align="center" width="25%">
              <b>Đơn giá</b>
            </td>
            <td align="center" width="15%">
              <b>Số lượng</b>
            </td>
            <td align="center" width="15%">
              <b>Thuế</b>
            </td>
          </tr>
          <xsl:for-each select="SALE_DETAIL">
            <tr>
              <td align="left">
                <xsl:value-of select="LIST_ORDER"/>
              </td>
              <td align="left">
                <xsl:value-of select="ITEM_ID"/>
              </td>
              <td align="left">
                <xsl:value-of select="ITEM_NAME"/>
              </td>
              <td align="left">
                <xsl:value-of select="PRICE"/>
              </td>
              <td align="left">
                <xsl:value-of select="AMOUNT"/>
              </td>
              <td align="left">
                <xsl:value-of select="VAT_TAX_NAME"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>

        <p></p>
        <table border="0" width="100%">
          <tr>
            <td width="30%"></td>
            <td width="30%"></td>
            <td align="center" width="40%">Hà Nội, ngày...tháng...năm....</td>
          </tr>
          <tr>
            <td></td>
            <td></td>
            <td align="center">Người lập phiếu</td>
          </tr>
          <tr>
            <td></td>
            <td></td>
            <td align="center">
              (<i>Ký, ghi rõ h tên</i>)
            </td>
          </tr>
        </table>
      </body>
    </HTML>
  </xsl:template>
</xsl:stylesheet>
