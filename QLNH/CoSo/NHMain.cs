﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace QLNH.CoSo
{
    public class NHMain
    {
        public NHMain()
        {
            try
            {
                string sql = "select count(*) from sys.tables";
                GetDataByQuery(sql, "Test");
                this.WorkingMode = CoSo.WorkingMode.Online;
            }
            catch
            {
                this.WorkingMode = CoSo.WorkingMode.Offline;
            }
        }
        public Form MainForm
        {
            get;
            set;
        }
        public XmlExecute Xml;
        public WorkingMode WorkingMode
        {
            get;
            set;
        }
        public string connInter = ConfigurationManager.ConnectionStrings["StringConn"].ConnectionString;
        public DataTable GetDataByQuery(string sql, string Nametable)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(connInter))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                        }
                    }
                }

                if (ds.Tables[0] != null)
                {
                    DataTable dataTable = ds.Tables[0].Clone();
                    DataRow dr = null;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dr = dataTable.NewRow();
                        dr.ItemArray = row.ItemArray;
                        dataTable.Rows.Add(dr);
                    }
                    dataTable.AcceptChanges();
                    if (Nametable != "")
                        dataTable.TableName = Nametable;
                    return dataTable;
                }
                return null;
            }
            catch (Exception exx)
            {
                if (exx.Message == "Unable to connect to the remote server")
                {
                    WorkingMode = CoSo.WorkingMode.Offline;
                }
                return null;

            }
        }
        public UserInfo UserInfo
        {
            get;
            set;
        }
        public string StartUpPath
        {
            get { return Application.StartupPath; }
        }
        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connInter))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return true;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        public DataTable GetFields(string Nametable)
        {
            try
            {
                string strStruct = @" SELECT * FROM SYS_FIELD WHERE TABLE_ID = '" + Nametable + "'";
                return this.GetDataByQuery(strStruct, "SYS_FIELD");
            }
            catch
            {
                MessageBox.Show("Không tìm thấy cấu hình bảng phù hợp");
                return null;
            }

        }
        public DataTable GetTables(string NameTable)
        {
            DataTable dt = new DataTable();
            string strStruct = @" SELECT  tb.name AS nameTB ,
        col.name AS nameCL ,
        col.user_type_id ,
        type.name AS nameTP
FROM    sys.Tables tb ,
        SYS.COLUMNS col ,
        sys.systypes type
WHERE   ( tb.object_id = col.OBJECT_ID )
        AND col.user_type_id = type.xusertype AND tb.name = '" + NameTable + @"'
UNION
SELECT  tb.name AS nameTB ,
        col.name AS nameCL ,
        col.user_type_id ,
        type.name AS nameTP
FROM    sys.views tb ,
        SYS.COLUMNS col ,
        sys.systypes type
WHERE   ( tb.object_id = col.OBJECT_ID )
        AND col.user_type_id = type.xusertype AND tb.name = '" + NameTable + "'";
            dt = this.GetDataByQuery(strStruct, NameTable);
            return dt;
        }
        #region Insert Data
        public string InsertTo(string TableName, DataRow Data)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this.GetTables(TableName);
                string temp = string.Empty;
                string str = "INSERT INTO " + TableName + "(<{ListCol}>) VALUES (";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    //if (dt.Rows[j]["NameCL"].ToString() == "PR_KEY")
                    //{

                    //    str += " " + GetPr_Key(TableName) + ",";
                    //}
                    //else
                    if (j != dt.Rows.Count - 1) str += " " + GetDataSQL(Data[dt.Rows[j]["NameCL"].ToString()], dt.Rows[j]["NameTP"].ToString()) + ",";
                    else str += "" + GetDataSQL(Data[dt.Rows[j]["NameCL"].ToString()], dt.Rows[j]["NameTP"].ToString()) + ")";
                }
                foreach (DataRow item in dt.Rows)
                {
                    temp += "[" + item["nameCL"] + "]";
                }
                temp = temp.Replace("][", "],[");
                str = str.Replace("<{ListCol}>", temp);

                return str;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        public string InsertByStore(string NameStoreProcedure, int count, List<string> Data)
        {
            try
            {
                string str = NameStoreProcedure + " ";
                for (int j = 0; j < count; j++)
                {
                    if (j != count - 1) str += "N'" + Data[j] + "',";
                    else str += "N'" + Data[j] + "'";
                }
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public double GetPr_Key(string NameTable)
        {
            DataTable dt = GetDataByQuery("select * from SYS_LASTKEY where TABLE_NAME = '" + NameTable + "'", "temp");
            if (dt != null)
                if (dt.Rows.Count > 0)
                {
                    ExecuteNonQuery("UPDATE SYS_LASTKEY SET LAST_NUM = LAST_NUM + 1 WHERE TABLE_NAME = '" + NameTable + "'");
                    return Convert.ToDouble(dt.Rows[0]["LAST_NUM"]) + 1;
                }
                else
                {
                    ExecuteNonQuery("INSERT INTO SYS_LASTKEY VALUES(N'" + NameTable + "',0)");
                    return 0;
                }
            else
            {
                ExecuteNonQuery("INSERT INTO SYS_LASTKEY VALUES(N'" + NameTable + "',0)");
                return 0;
            }
        }
        public static string ParseDate(DateTime d)
        {
            string year = d.Year.ToString();
            string month = d.Month.ToString();
            string day = d.Day.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            return "'" + month + "/" + day + "/" + year + "'";
        }
        private string GetDataSQL(object value, string type)
        {
            if (type == "int" || type == "money" || type == "smallint" || type == "bigint")
            {
                if (value == null || value.ToString() == "") value = 0;
                return (string)value.ToString();
            }
            if (type == "nvarchar" || type == "varchar" || type == "nchar" || type == "text")
            {
                return "N'" + value.ToString() + "'";
            }
            if (type == "date" || type == "datetime" || type == "smalldatetime")
            {
                return ParseDate((DateTime)value);
            }
            if (type == "image")
            {
                //return @"SELECT * FROM OPENROWSET(BULK N'" + value + "', SINGLE_BLOB) ";
                return "null";
            }
            if (type == "bit") return value == "false" ? "0" : "1";
            return "'" + (string)value == null ? "" : value + "'";
        }
        #region Update data
        public string UpdateTo(string NameTable, DataRow Data, string ConditionOperator)
        {
            try
            {
                string Field_Key = ColumnPrimaryKey(NameTable);
                DataTable dt = new DataTable();
                //dr = Data;
                string NameField = "";
                string TypeField = "";
                string CO = ConditionOperator;
                if (CO == "") CO = "=";
                dt = this.GetTables(NameTable);
                string str = " UPDATE " + NameTable + " SET ";
                int i = 0;
                foreach (DataRow datarow in dt.Rows)
                {
                    if (datarow["NameCL"].ToString() != Field_Key)
                        if (i < dt.Rows.Count)
                            str += "[" + datarow["NameCL"].ToString() + "] = " + GetDataSQL(Data[datarow["NameCL"].ToString()], datarow["NameTP"].ToString()) + ",";
                        else str += "[" + datarow["NameCL"].ToString() + "] = " + GetDataSQL(Data[datarow["NameCL"].ToString()], datarow["NameTP"].ToString()) + " ";
                    else
                    {
                        NameField = datarow["NameCL"].ToString();
                        TypeField = datarow["NameTP"].ToString();
                    }
                    i++;
                }
                str = str.Remove(str.Length - 1, 1);
                if (NameField == "") return str;
                else
                {
                    str += " WHERE [" + NameField + "] " + CO + " " + GetDataSQL(Data[Field_Key], TypeField) + "";
                    str = str.Replace(", WHERE", " WHERE");
                    return str;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateTo(string NameTable, DataRow Data, int IndexCondition, string ConditionOperator)
        {
            try
            {
                DataTable dt = new DataTable();
                //dr = Data;
                string NameField = "";
                string TypeField = "";
                string CO = ConditionOperator;
                if (CO == "") CO = "=";
                dt = this.GetTables(NameTable);
                string str = " UPDATE " + NameTable + " SET ";
                int i = 0;
                foreach (DataRow datarow in dt.Rows)
                {
                    if (i != IndexCondition)
                        if (i < dt.Rows.Count)
                            str += "[" + datarow["NameCL"].ToString() + "] = " + GetDataSQL(Data[datarow["NameCL"].ToString()], datarow["NameTP"].ToString()) + ",";
                        else str += "[" + datarow["NameCL"].ToString() + "] = " + GetDataSQL(Data[datarow["NameCL"].ToString()], datarow["NameTP"].ToString()) + " ";
                    else
                    {
                        NameField = datarow["NameCL"].ToString();
                        TypeField = datarow["NameTP"].ToString();
                    }
                    i++;
                }
                str = str.Remove(str.Length - 1, 1);
                NameField = ColumnPrimaryKey(NameTable);
                if (NameField == "") return str;
                else
                {
                    str += " WHERE [" + NameField + "] " + CO + " " + GetDataSQL(Data[IndexCondition], TypeField) + "";
                    str = str.Replace(", WHERE", " WHERE");
                    return str;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ColumnPrimaryKey(string NameTable)
        {
            string strTemp = @"SELECT COLUMN_NAME 
                                FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE a 
                                WHERE 
                                 EXISTS(
                                  SELECT * 
                                  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS b 
                                  WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
                                   AND a.CONSTRAINT_NAME = b.CONSTRAINT_NAME) AND 
                                 TABLE_NAME = '{<NameTable>}'";
            string result = "";
            DataTable dt = GetDataByQuery(strTemp.Replace("{<NameTable>}", NameTable), NameTable);
            foreach (DataRow dr in dt.Rows)
            {
                result = dr["COLUMN_NAME"].ToString();
                break;
            }
            return result;
        }
        public bool isPrimaryKeyTable(string NameTable, string ColumnName)
        {
            string strTemp = @"SELECT COLUMN_NAME 
                                FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE a 
                                WHERE 
                                 EXISTS(
                                  SELECT * 
                                  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS b 
                                  WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
                                   AND a.CONSTRAINT_NAME = b.CONSTRAINT_NAME) AND 
                                 TABLE_NAME = '{<NameTable>}'";
            DataTable dt = GetDataByQuery(strTemp.Replace("{<NameTable>}", NameTable), NameTable);
            bool value = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["COLUMN_NAME"].ToString() == ColumnName)
                {
                    value = true;
                    break;
                }
            }
            return value;
        }
        public DbType GetType(string type)
        {
            DbType mType;
            mType = DbType.String;
            switch (type)
            {
                case "nvarchar": mType = DbType.String; break;
                case "smalldatetime": mType = DbType.Date; break;
                case "int": mType = DbType.Int32; break;
                case "smallint": mType = DbType.Int32; break;
                case "money": mType = DbType.Currency; break;
                default:
                    break;
            }
            return mType;
        }
        public string UpdateTo(string NameStoreProcedure, DataRow Data)
        {
            try
            {
                DataTable dt = new DataTable();
                //dr = Data;x
                dt = this.GetTables(NameStoreProcedure);
                string str = NameStoreProcedure;
                int i = 0;
                foreach (DataRow datarow in dt.Rows)
                {
                    if (i < dt.Rows.Count)
                        str += " [" + datarow["NameCL"].ToString() + "] = " + GetDataSQL(Data[i], datarow["NameTP"].ToString()) + ",";
                    else str += "[" + datarow["NameCL"].ToString() + "] = " + GetDataSQL(Data[i], datarow["NameTP"].ToString()) + " ";
                    i++;
                }
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete Data
        public string DeleteTo(string NameTable, DataRow row)
        {
            try
            {
                string key = ColumnPrimaryKey(NameTable);
                DataTable dt = GetTables(NameTable);
                dt.PrimaryKey = new[] { dt.Columns["nameCL"] };
                DataRow dr = dt.Rows.Find(key);
                if (dr != null)
                {
                    string s = "DELETE FROM " + NameTable + " WHERE " + key + "=" + GetDataSQL(row[key], dr["nameTP"].ToString());
                    return s;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteTo(string NameTable, string Condition)
        {
            try
            {
                return "DELETE FROM " + NameTable + " WHERE" + Condition;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteByStore(string NameStoreProcedure, string Condition)
        {
            try
            {
                return NameStoreProcedure + " " + Condition;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void UpdateDataTable(DataTable dataTable)
        {
            try
            {
                string listsql = string.Empty;
                foreach (DataRow item in dataTable.Rows)
                {
                    if (item.RowState == DataRowState.Modified)
                    {
                        listsql += UpdateTo(dataTable.TableName, item, "");
                    }
                    else if (item.RowState == DataRowState.Added)
                    {
                        listsql += InsertTo(dataTable.TableName, item);
                    }
                    else if (item.RowState == DataRowState.Deleted)
                    {
                        listsql += DeleteTo(dataTable.TableName, item);
                    }
                }
                if (listsql != "")
                {
                    ExecuteNonQuery(listsql);
                    dataTable.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
