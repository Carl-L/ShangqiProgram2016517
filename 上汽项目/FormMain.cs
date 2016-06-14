using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 上汽项目.DAL;
using 上汽项目.BLL;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Collections;

namespace 上汽项目
{
    public partial class FormMain : Form
    {
        private string[] searchType = { "单值查询", "多值查询", "范围查询" };
        private string[] accidentType = { "1仅乘用车", "2仅货车", "3仅客车", "4乘用车+货车", "5乘用车+客车", "6客车+货车", "7所有车型"};
        private string[] crashType = { "All", "A类=追尾事故被碰撞方", "B类=追尾事故碰撞方", "C类=无法比较的案例" };
        //private string tableSelected = "['01环境和一般事故数据$']";
        private string accTypeStr = "select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where ([(CLLX4)C车辆类型] in (0,1,2,3,4,5,6,9)) and ([(SGDABH)案例编号] not in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (7,14,15,16,17, 8,10,11,12)))";
        private List<string> Data = new List<string>();
        private List<string> list_cboField = new List<string>();
        private List<string> listNew_cboField = new List<string>();
        private List<string> list_cboForDisplay = new List<string>();
        private List<string> listNew_cboForDisplay = new List<string>();

        private Dictionary<string, List<string>> dict_tables = new Dictionary<string,List<string>>();

        string str_albh = "";
        string str_cyfbh = "";
        string str_rybh = "";
        bool albh_flag = false;
        bool rybh_flag = false;
        bool cyfbh_flag = false;

        // 存储含有对应字段的表名
        private List<string> rybh_tableList_stable = new List<string>();
        private List<string> albh_tableList_stable = new List<string>();
        private List<string> cyfbh_tableList_stable = new List<string>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAccidents();

            //根据列名排序
            dgvCars.RowsAdded += new DataGridViewRowsAddedEventHandler(
                dgvCars_RowsAdded);
            dgvCars.CellValueChanged += new DataGridViewCellEventHandler(
                dgvCars_CellValueChanged);
            dgvCars.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(
                dgvCars_ColumnHeaderMouseClick);

        }

        /// <summary>
        /// 初始表
        /// </summary>
        private void LoadAccidents()
        {
            string sqlStr = "select * from ['01环境和一般事故数据$']";
            //DataTable dt = SqlHelper.GetDataTable(sqlStr);
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            dgvCars.DataSource = dt;

            DataTable dtcols = SqlHelper.ExecuteDataTable("select * from information_schema.columns where table_name='''01环境和一般事故数据$'''");
            //MessageBox.Show(dtcols.Columns.ToString());
            dgvCars.DataSource = dtcols;

            //foreach (DataRow row in dtcols.Rows)
            //{ 
            //    string columnname = (string)row["COLUMN_NAME"];
            //}

            foreach (string st in searchType)
            {
                cboSearchType.Items.Add(st);
            }

            foreach (string at in accidentType)
            {
                cboAccidentType.Items.Add(at);
            }


            // 获取所有字段名
            sqlStr = "select * from information_schema.columns where table_name!='T_User'";
            dtcols = SqlHelper.ExecuteDataTable(sqlStr);

            cboField.Items.Clear();

            foreach (DataRow row in dtcols.Rows)
            {
                string columnname = '[' + (string)row["TABLE_NAME"] + "].[" + (string)row["COLUMN_NAME"] + "]";
                cboField.Items.Add(columnname);
                list_cboField.Add(columnname);
                if ((string)row["COLUMN_NAME"] == "(RYBH)人员编号")
                {
                    rybh_tableList_stable.Add('[' + (string)row["TABLE_NAME"] + ']');
                }
                else if ((string)row["COLUMN_NAME"] == "(SGDABH)案例编号")
                {
                    albh_tableList_stable.Add('[' + (string)row["TABLE_NAME"] + ']');
                }
                else if ((string)row["COLUMN_NAME"] == "(CYFBH)参与方编号")
                {
                    cyfbh_tableList_stable.Add('[' + (string)row["TABLE_NAME"] + ']');
                }
            }
            //MessageBox.Show(rybh_tableList_stable.Count.ToString());
            //MessageBox.Show(albh_tableList_stable.Count.ToString());
            //MessageBox.Show(cyfbh_tableList_stable.Count.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tf;
            if (cboField.SelectedIndex == -1)
            {
                tf = cboField.Text.ToString();
            }
            else
            {
                tf = cboField.SelectedItem.ToString();
            }
            
            string[] tmpList = tf.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            string table = tmpList[0];
            string cateId = tmpList[1];
            string searchType_cbo = "";
            string searchTxt = "";
            if (cboSearchType.SelectedIndex != -1)
            {
                searchType_cbo = cboSearchType.SelectedItem.ToString();
                searchTxt = txtSearchType.Text.Trim(); // 单值查询 多值查询 范围查询
            }

            string sqlStr = "select * from " + table + " where " + table + ".[(SGDABH)案例编号] in (" + accTypeStr + ")";

            if (!string.IsNullOrEmpty(searchTxt))
            {
                if (searchType_cbo == searchType[0])
                {
                    sqlStr += " and " + cateId + "='" + searchTxt + "'";
                }
                else if (searchType_cbo == searchType[1])
                {
                    string lang = "";
                    string[] strList = searchTxt.Split(new string[] { "or" }, StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;
                    for (; i < strList.Length - 1; i++)
                    {
                        lang += cateId + "='" + strList[i] + "' or ";
                    }
                    lang += cateId + "='" + strList[i] + "'";
                    sqlStr += " and " + lang;
                }
                else if (searchType_cbo == searchType[2])
                {
                    string lang = "";
                    string[] strList = searchTxt.Split(new string[] { "to" }, StringSplitOptions.RemoveEmptyEntries);
                    lang += " and " + tf + " between '" + strList[0] + "' and '" + strList[1] + "'";
                    sqlStr += lang;
                }
            }
            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            dgvCars.AllowUserToAddRows = false;
            dgvCars.DataSource = dt;
        }

        // 添加检索条件
        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            string tf = "";
            // 如果字段没有选中，则取字段框中的信息
            if (cboField.SelectedIndex == -1)
            { 
                tf = cboField.Text.ToString();
            }
            else
            {
                tf = cboField.SelectedItem.ToString();
            }
            string[] tmpList = tf.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            string table = tmpList[0];
            string cateId = tmpList[1];
            List<string> tableList = new List<string>();

            if (cboSearchType.SelectedIndex != -1)
            {
                string searchType_cbo = cboSearchType.SelectedItem.ToString();
                string searchTxt = txtSearchType.Text.Trim();
                if (!string.IsNullOrEmpty(searchTxt))
                {
                    string clbCondition = searchType_cbo + "." + tf + "." + searchTxt;
                    clbConditions.Items.Add(clbCondition);
                }

                foreach (var item in clbConditions.Items)
                {
                    //MessageBox.Show(item.ToString());

                    if (!tableList.Contains(item))
                    {
                        tableList.Add(item.ToString());
                    }
                }

                foreach (var tl in tableList)
                {
                    string[] tmp = tl.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    string tmp_table = tmp[1].Replace("[", "");
                    tmp_table = tmp_table.Replace("]", "");
                    string sqlStr = "select * from information_schema.columns where table_name=''" + tmp_table + "''";
                    DataTable dtcols = SqlHelper.ExecuteDataTable(sqlStr);

                    // 将用户选择的表的对应列名显示
                    foreach (DataRow row in dtcols.Rows)
                    {
                        string columnname = (string)row["COLUMN_NAME"];
                        string tmp1 = "[" + tmp_table + "].[" + columnname + "]";
                        clbColumnForDisplay.Items.Add(tmp1);
                        list_cboForDisplay.Add(tmp1);
                        cboForDisplay.Items.Add(tmp1);
                        //MessageBox.Show("[" + table + "]." + columnname);
                    }
                }

                for (int j = 0; j < clbColumnForDisplay.Items.Count; j++)
                {
                    clbColumnForDisplay.SetItemChecked(j, true);
                }
            }
        }

        // 多条件筛选
        private void btnMulti_Click(object sender, EventArgs e)
        {
            List<string> rybh_tableList = new List<string>();
            List<string> albh_tableList = new List<string>();
            List<string> cyfbh_tableList = new List<string>();
            // tableList用于存储表名
            List<string> tableList = new List<string>();
            string table = "";
            string albh_str_tmp = "";
            string rybh_str_tmp = "";
            string cyfbh_str_tmp = "";


            #region 显示用户选择的字段名
            string userSelectedField = "";
            foreach (string itemName in clbColumnForDisplay.CheckedItems)
            {
                if (userSelectedField.Length == 0)
                {
                    userSelectedField = itemName;
                }
                else
                {
                    userSelectedField += "," + itemName;
                }
            } 
            #endregion

            string sqlStr = "";
            if (userSelectedField.Length == 0)
            {
                sqlStr = "select * from ";
            }
            else
            {
                sqlStr = "select " + userSelectedField + " from ";
            }

            string lang = "";
            string table_list_tmp = "";
            foreach (string itemName in clbConditions.CheckedItems)
            {
                string[] itemArray = itemName.Split(new char[1]{'.'}); // 搜索类型 表名 字段名 条件
                table = itemArray[1];
                // 如果tableList中没有当前表名，则加入
                if (!tableList.Contains(itemArray[1]))
                {
                    if (tableList.Count == 0)
                    {
                        tableList.Add(itemArray[1]);
                        table_list_tmp = itemArray[1];
                    }
                    else
                    {
                        table_list_tmp += ", " + itemArray[1];
                    }
                    // 判断含有相应字段的表
                    //MessageBox.Show(itemArray[1]);
                    if (rybh_tableList_stable.Contains(itemArray[1]))
                    {
                        rybh_tableList.Add(itemArray[1]);
                        rybh_str_tmp = itemArray[1];
                    }
                    if (albh_tableList_stable.Contains(itemArray[1]))
                    {
                        albh_tableList.Add(itemArray[1]);
                        albh_str_tmp = itemArray[1];
                    }
                    if (cyfbh_tableList_stable.Contains(itemArray[1]))
                    {
                        cyfbh_tableList.Add(itemArray[1]);
                        cyfbh_str_tmp = itemArray[1];
                    }

                }
                if (itemArray[0] == searchType[0])
                {
                    if (lang.Length > 0)
                    {
                        lang += " and";
                    }
                    lang += " (" + itemArray[1] + "." + itemArray[2] + "='" + itemArray[3] + "')";
                }
                else if (itemArray[0] == searchType[1])
                {
                    string[] strList = itemArray[3].Split(new string[] { "or" }, StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;
                    int flag = 0;
                    if (lang.Length > 0)
                    {
                        flag = 1;
                        lang += " and (";
                    }
                    for (; i < strList.Length - 1; i++)
                    {
                        lang += " " + itemArray[1] + "." + itemArray[2] + "='" + strList[i] + "' or ";
                    }
                    lang += itemArray[1] + "." + itemArray[2] + "='" + strList[i] + "'";
                    if (flag == 1)
                    {
                        lang += ")";
                    }
                }
                else if (itemArray[0] == searchType[2])
                {
                    int flag = 0;
                    if (lang.Length > 0)
                    {
                        flag = 1;
                        lang += " and (";
                    }
                    string[] strList = itemArray[3].Split(new string[] { "to" }, StringSplitOptions.RemoveEmptyEntries);
                    lang += " " + itemArray[1] + "." + itemArray[2] + " between '" + strList[0] + "' and '" + strList[1] + "'";
                    if (flag == 1)
                    {
                        lang += ")";
                    }
                }
            }

            string prime_key_join = "";
            if (rybh_tableList.Count > 1)
            {
                for (int i = 1; i < rybh_tableList.Count; i++ )
                {
                    if (prime_key_join.Length == 0)
                    {
                        prime_key_join = rybh_tableList[i-1] + ".[(RYBH)人员编号]=" + rybh_tableList[i] + ".[(RYBH)人员编号]";
                    }
                    else
                    {
                        prime_key_join += " and " + rybh_tableList[i - 1] + ".[(RYBH)人员编号]=" + rybh_tableList[i] + ".[(RYBH)人员编号]";
                    }
                }
            }
            if (albh_tableList.Count > 1)
            {
                for (int i = 1; i < albh_tableList.Count; i++)
                {
                    if (prime_key_join.Length == 0)
                    {
                        prime_key_join = albh_tableList[i - 1] + ".[(SGDABH)案例编号]=" + albh_tableList[i] + ".[(SGDABH)案例编号]";
                    }
                    else
                    {
                        prime_key_join += " and " + albh_tableList[i - 1] + ".[(SGDABH)案例编号]=" + albh_tableList[i] + ".[(SGDABH)案例编号]";
                    }
                }
            }
            if (cyfbh_tableList.Count > 1)
            {
                for (int i = 1; i < cyfbh_tableList.Count; i++)
                {
                    if (prime_key_join.Length == 0)
                    {
                        prime_key_join = cyfbh_tableList[i - 1] + ".[(CYFBH)参与方编号]=" + cyfbh_tableList[i] + ".[(CYFBH)参与方编号]";
                    }
                    else
                    {
                        prime_key_join += " and " + cyfbh_tableList[i - 1] + ".[(CYFBH)参与方编号]=" + cyfbh_tableList[i] + ".[(CYFBH)参与方编号]";
                    }
                }
            }

            //MessageBox.Show(prime_key_join);
            if (table_list_tmp.Length > 0)
            {
                sqlStr += table_list_tmp + " where " + table + ".[(SGDABH)案例编号] in (" + accTypeStr + ")";
                if (prime_key_join.Length != 0)
                {
                    sqlStr += " and " + prime_key_join;
                }

                #region 用户导入导出限制
                if (str_albh.Length != 0 && albh_flag == true && albh_str_tmp.Length != 0)
                    sqlStr += " and " + albh_str_tmp + ".[(SGDABH)案例编号] in " + str_albh;

                if (str_rybh.Length != 0 && rybh_flag == true && rybh_str_tmp.Length != 0)
                    sqlStr += " and " + rybh_str_tmp + ".[(RYBH)人员编号] in " + str_rybh;

                if (str_cyfbh.Length != 0 && cyfbh_flag == true && cyfbh_str_tmp.Length != 0)
                    sqlStr += " and " + cyfbh_str_tmp + ".[(CYFBH)参与方编号] in " + str_cyfbh;
                #endregion

                if (lang.Length != 0)
                {
                    sqlStr += " and " + lang;
                }

                //MessageBox.Show(sqlStr);
                DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
                dgvCars.AllowUserToAddRows = false;
                dgvCars.DataSource = dt;

            }
            albh_flag = false;
            cyfbh_flag = false;
            rybh_flag = false;
        }

        private void cboAccidentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accType = cboAccidentType.SelectedItem.ToString();
            string sqlStr = "select * from ['01环境和一般事故数据$']";

            if (accType == accidentType[0])
            {
                // 仅乘用车 0,1,2,3,4,5,6,9
                //accTypeStr = "select * from ['02车辆数据$'] where ['02车辆数据$'].[(SGDABH)案例编号] in (select [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型]=0 or [(CLLX4)C车辆类型]=1 or [(CLLX4)C车辆类型]=2 or [(CLLX4)C车辆类型]=3 or [(CLLX4)C车辆类型]=4 or [(CLLX4)C车辆类型]=5 or [(CLLX4)C车辆类型]=6 or [(CLLX4)C车辆类型]=9) and ([(CLLX4)C车辆类型]=21 or [(CLLX4)C车辆类型]=22 or [(CLLX4)C车辆类型]=23 or [(CLLX4)C车辆类型]=98)";
                accTypeStr = "select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where ([(CLLX4)C车辆类型] in (0,1,2,3,4,5,6,9)) and ([(SGDABH)案例编号] not in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (7,14,15,16,17, 8,10,11,12)))";
            }
            else if (accType == accidentType[1])
            {
                // 仅货车7,14,15,16,17
                accTypeStr = "select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where ([(CLLX4)C车辆类型] in (7,14,15,16,17)) and ([(SGDABH)案例编号] not in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (0,1,2,3,4,5,6,9, 8,10,11,12)))";
            }
            else if (accType == accidentType[2])
            {
                // 仅客车8,10,11,12
                accTypeStr = "select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where ([(CLLX4)C车辆类型] in (8,10,11,12)) and ([(SGDABH)案例编号] not in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (0,1,2,3,4,5,6,9, 7,14,15,16,17)))";
            }
            else if (accType == accidentType[3])
            {
                // 乘用车+货车
                accTypeStr = "select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where ([(CLLX4)C车辆类型] in (0,1,2,3,4,5,6,9)) and ([(SGDABH)案例编号] in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (7,14,15,16,17))) and ([(SGDABH)案例编号] not in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (8,10,11,12)))";
            }
            else if (accType == accidentType[4])
            {
                // 乘用车+客车
                accTypeStr = "select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where ([(CLLX4)C车辆类型] in (0,1,2,3,4,5,6,9)) and ([(SGDABH)案例编号] in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (8,10,11,12))) and ([(SGDABH)案例编号] not in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (7,14,15,16,17)))";
            }
            else if (accType == accidentType[5])
            {
                // 货车+客车
                accTypeStr = "select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where ([(CLLX4)C车辆类型] in (7,14,15,16,17)) and ([(SGDABH)案例编号] in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (8,10,11,12))) and ([(SGDABH)案例编号] not in (select distinct [(SGDABH)案例编号] from ['02车辆数据$'] where [(CLLX4)C车辆类型] in (0,1,2,3,4,5,6,9)))";
            }
            else// if (accType == accidentType[6])
            {
                accTypeStr = "select distinct [(SGDABH)案例编号] from ['01环境和一般事故数据$']";
            }

            DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
            dgvCars.DataSource = dt;
            
        }

        //// 实现combobox下拉提示
        //private void cboTable_TextUpdate(object sender, EventArgs e)
        //{ 
        //    // 清空combobox
        //    this.cboTable.Items.Clear();
        //    // 清空 listNew_cboTable
        //    listNew_cboTable.Clear();
        //    // 遍历全部备查数据
        //    foreach (var item in list_cboTable)
        //    {
        //        if (item.Contains(this.cboTable.Text))
        //        {
        //            listNew_cboTable.Add(item);
        //        }
        //    }
        //    // combobox添加已经查到的关键词
        //    this.cboTable.Items.AddRange(listNew_cboTable.ToArray());
        //    // 设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
        //    this.cboTable.SelectionStart = this.cboTable.Text.Length;
        //    // 保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
        //    Cursor = Cursors.Default;
        //    // 自动弹出下拉框
        //    this.cboTable.DroppedDown = true;
        //}

        //private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    tableSelected = cboTable.SelectedItem.ToString();
        //    //MessageBox.Show(tableSelected);

        //    int cboCateIndex = cboCate.SelectedIndex;
        //    //MessageBox.Show(cboCateIndex.ToString());

        //    string cateId;
        //    if (cboCateIndex == -1)
        //    {
        //        cateId = cboCate.Text;
        //    }
        //    else
        //    {
        //        cateId = cboCate.SelectedItem.ToString();
        //        //MessageBox.Show(cateId);
        //    }

        //    string sqlStr = "select [" + cateId + "] from [" + tableSelected + "]";
        //    //DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
        //    //dgvCars.DataSource = dt;

        //    sqlStr = "select * from information_schema.columns where table_name=''" + tableSelected + "''";
        //    DataTable dtcols = SqlHelper.ExecuteDataTable(sqlStr);
        //    //MessageBox.Show(dtcols.Columns.ToString());
        //    dgvCars.DataSource = dtcols;

        //    cboCate.Items.Clear();

        //    foreach (DataRow row in dtcols.Rows)
        //    {
        //        string columnname = (string)row["COLUMN_NAME"];
        //        cboCate.Items.Add(columnname);
        //        list_cboCate.Add(columnname);
        //    }

        //    tableSelected = "[" + tableSelected + "]";
        //}

        //private void cbSelectAllTables_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbSelectAllTables.Checked)
        //    {
        //        for (int j = 0; j < clbTables.Items.Count; j++)
        //        {
        //            clbTables.SetItemChecked(j, true);
        //        }
        //    }
        //    else
        //    {
        //        for (int j = 0; j < clbTables.Items.Count; j++)
        //        {
        //            clbTables.SetItemChecked(j, false);
        //        }
        //    }
        //}

        private void cbSelectAllConditions_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllConditions.Checked)
            {
                for (int j = 0; j < clbConditions.Items.Count; j++)
                {
                    clbConditions.SetItemChecked(j, true);
                }
            }
            else
            {
                for (int j = 0; j < clbConditions.Items.Count; j++)
                {
                    clbConditions.SetItemChecked(j, false);
                }
            }
        }

        private void btnClearConditions_Click(object sender, EventArgs e)
        {
            for (int j = clbConditions.Items.Count - 1; j >= 0; j--)
            {
                clbConditions.Items.RemoveAt(j);
            }
        }

        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            for (int j = clbConditions.CheckedItems.Count - 1; j >= 0; j--)
            {
                clbConditions.Items.RemoveAt(clbConditions.CheckedIndices[j]);
            }
        }

        private void cbSelectAllColumns_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllColumns.Checked)
            {
                for (int j = 0; j < clbColumnForDisplay.Items.Count; j++)
                {
                    clbColumnForDisplay.SetItemChecked(j, true);
                }
            }
            else
            {
                for (int j = 0; j < clbColumnForDisplay.Items.Count; j++)
                {
                    clbColumnForDisplay.SetItemChecked(j, false);
                }
            }
        }

        #region cboCate下拉提示
        //private void cboCate_TextUpdate(object sender, EventArgs e)
        //{
        //    // 清空cboCate
        //    this.cboCate.Items.Clear();
        //    // 清空 listNew_cboTable
        //    listNew_cboCate.Clear();
        //    // 遍历全部备查数据
        //    foreach (var item in list_cboCate)
        //    {
        //        if (item.Contains(this.cboCate.Text))
        //        {
        //            listNew_cboCate.Add(item);
        //        }
        //    }
        //    // combobox添加已经查到的关键词
        //    this.cboCate.Items.AddRange(listNew_cboCate.ToArray());
        //    // 设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
        //    this.cboCate.SelectionStart = this.cboCate.Text.Length;
        //    // 保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
        //    Cursor = Cursors.Default;
        //    // 自动弹出下拉框
        //    this.cboCate.DroppedDown = true;
        //} 
        #endregion

        #region 导出excel
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            DataTable dt = dgvCars.DataSource as DataTable;
            string fileName = "../../../导出数据/result" + dateTime.ToFileTime().ToString() + ".xlsx";
            TableToExcelForXLSX(dt, fileName);
            MessageBox.Show("Excel导出成功");
        }

        /// <summary>  
        /// 将DataTable数据导出到Excel文件中(xlsx)  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <param name="file"></param>  
        public static void TableToExcelForXLSX(DataTable dt, string file)
        {
            XSSFWorkbook xssfworkbook = new XSSFWorkbook();
            ISheet sheet = xssfworkbook.CreateSheet("accident");

            // 表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            xssfworkbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        } 
        #endregion

        //#region SQL自定义查询模块
        //private void btnSQLSearch_Click(object sender, EventArgs e)
        //{
        //    string sqlStr = rtbSQLLanguage.Text.Trim(); // SQL查询语句
        //    DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
        //    dgvCars.DataSource = dt;
        //} 
        //#endregion

        #region 表名点击排序函数
        //ColumnHeaderMouseClick事件处理器
        private void dgvCars_ColumnHeaderMouseClick(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = dgvCars.Columns[e.ColumnIndex];
            if (clickedColumn.SortMode != DataGridViewColumnSortMode.Automatic)
                this.SortRows(clickedColumn, true);
        }


        //RowsAdded事件处理器
        private void dgvCars_RowsAdded(object sender,
            DataGridViewRowsAddedEventArgs e)
        {
            this.SortRows(dgvCars.SortedColumn, false);
        }


        //CellValueChanged事件处理器
        private void dgvCars_CellValueChanged(object sender,
            DataGridViewCellEventArgs e)
        {
            if (dgvCars.SortedColumn != null &&
                e.ColumnIndex == dgvCars.SortedColumn.Index)
                this.SortRows(dgvCars.SortedColumn, false);
        }


        /// <summary>
        ///以被指定的列为标准进行排序
        /// </summary>
        /// <param name="sortColumn">为标准的列</param>
        /// <param name="orderToggle">变更排序方向的Toggle </param>
        private void SortRows(DataGridViewColumn sortColumn, bool orderToggle)
        {
            if (sortColumn == null)
                return;

            //清除前面的排序
            if (sortColumn.SortMode == DataGridViewColumnSortMode.Programmatic &&
                dgvCars.SortedColumn != null &&
                !dgvCars.SortedColumn.Equals(sortColumn))
            {
                dgvCars.SortedColumn.HeaderCell.SortGlyphDirection =
                    SortOrder.None;
            }

            //设定排序的方向（升序、降序）
            ListSortDirection sortDirection;
            if (orderToggle)
            {
                sortDirection =
                    dgvCars.SortOrder == SortOrder.Descending ?
                    ListSortDirection.Ascending : ListSortDirection.Descending;
            }
            else
            {
                sortDirection =
                    dgvCars.SortOrder == SortOrder.Descending ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            SortOrder sortOrder =
                sortDirection == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;

            //进行排序
            dgvCars.Sort(sortColumn, sortDirection);


            if (sortColumn.SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                //变更排序图标
                sortColumn.HeaderCell.SortGlyphDirection = sortOrder;
            }
        } 
        #endregion

        #region cboField下拉提示
        private void cboField_TextUpdate(object sender, EventArgs e)
        {
            // 清空cboCate
            this.cboField.Items.Clear();
            // 清空 listNew_cboTable
            listNew_cboField.Clear();
            // 遍历全部备查数据
            foreach (var item in list_cboField)
            {
                if (item.Contains(this.cboField.Text))
                {
                    listNew_cboField.Add(item);
                }
            }
            // combobox添加已经查到的关键词
            this.cboField.Items.AddRange(listNew_cboField.ToArray());
            // 设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            this.cboField.SelectionStart = this.cboField.Text.Length;
            // 保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            // 自动弹出下拉框
            this.cboField.DroppedDown = true;
        } 
        #endregion

        #region 计算中位数，平均数，最大最小值，统计分布
        private void dgvCars_MouseClick(object sender, MouseEventArgs e)
        {
            // get the position of SelectedCells
            int colIndex = (dgvCars.SelectedCells[0].ColumnIndex);
            int rowIndex = (dgvCars.SelectedCells[0].RowIndex);
            // get the type of first value of SelectedCells
            string cellValueType = dgvCars.SelectedCells[0].ValueType.ToString();

            // 获取选中单元格对应的表名
            string colName = dgvCars.Columns[colIndex].HeaderText;
            //MessageBox.Show(colName);
            tbCurrentName.Text = colName;

            // 获取行数
            int rowCount = dgvCars.Rows.Count;

            List<Int32> listTmp = new List<Int32>();

            // 判断是否为整形，还需考虑浮点型
            if (cellValueType == "System.Int32" || cellValueType == "System.Int16" || cellValueType == "System.Int64" || cellValueType == "System.Float" || cellValueType == "System.Double")
            {
                //MessageBox.Show(dgvCars.SelectedCells[0].ValueType.ToString());

                Double minVal = double.MaxValue;
                Double maxVal = double.MinValue;
                Double sum = 0;
                int cnt = 0;
                ArrayList al = new ArrayList();
                for (int i = 0; i < rowCount; i++)
                {
                    if (dgvCars.Rows[i].Cells[colIndex].Value != DBNull.Value)
                    {
                        Double curVal = Convert.ToDouble(dgvCars.Rows[i].Cells[colIndex].Value);
                        if (minVal > curVal)
                        {
                            minVal = curVal;
                        }
                        if (maxVal < curVal)
                        {
                            maxVal = curVal;
                        }
                        sum += curVal;
                        cnt++;
                        al.Add(curVal);
                    }
                }
                Double avg = sum / cnt;
                Double[] arr = (Double[])al.ToArray(typeof(Double));

                Double midVal = new T_UserBLL().Median(arr);
                txtAveVal.Text = avg.ToString();
                txtMiddleVal.Text = midVal.ToString();
                txtMaxVal.Text = maxVal.ToString();
                txtMinVal.Text = minVal.ToString();

            }

            #region 统计概率分布
            // 统计概率分布
            Dictionary<object, int> numDistribution = new Dictionary<object, int>();
            for (int i = 0; i < rowCount; i++)
            {
                object tmpVal = dgvCars.Rows[i].Cells[colIndex].Value;

                if (tmpVal != DBNull.Value && tmpVal != null)
                {
                    if (numDistribution.ContainsKey(tmpVal) == false)
                    {
                        numDistribution.Add(tmpVal, 1);
                    }
                    else
                    {
                        numDistribution[tmpVal]++;
                    }
                }
            }

            dgvDataDistribution.Rows.Clear();
            dgvDataDistribution.Columns.Clear();
            dgvDataDistribution.Columns.Add("c1", "数据");
            dgvDataDistribution.Columns.Add("c2", "分布");
            foreach ( var key in numDistribution.Keys)
            {
                int index = this.dgvDataDistribution.Rows.Add();
                dgvDataDistribution.Rows[index].Cells[0].Value = key;
                dgvDataDistribution.Rows[index].Cells[1].Value = numDistribution[key];
            }
            dgvDataDistribution.AllowUserToAddRows = false;
            #endregion


            //MessageBox.Show(dgvCars.SelectedCells[0].Value);
            // 判断数据是否为空
            if (this.dgvCars.SelectedCells[0].Value == DBNull.Value)
            {
                MessageBox.Show("This is empty!");
            }
        }
        #endregion

        #region cboField对应字段内容提示
        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tf = cboField.SelectedItem.ToString();
            if (tf != "")
            {
                string[] strList = tf.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                string table = strList[0];
                string cateId = strList[1];
                //MessageBox.Show(cateId);
                string sqlStr = "select " + cateId + " from " + table;
                DataTable dt = SqlHelper.ExecuteDataTable(sqlStr);
                dgvCars.DataSource = dt;
            }
        }
        #endregion

        private void cboForDisplay_TextUpdate(object sender, EventArgs e)
        {
            // 清空cboForDisplay
            this.cboForDisplay.Items.Clear();
            // 清空 listNew_cboTable
            listNew_cboForDisplay.Clear();
            // 遍历全部备查数据
            foreach (var item in list_cboForDisplay)
            {
                if (item.Contains(this.cboForDisplay.Text))
                {
                    listNew_cboForDisplay.Add(item);
                }
            }
            // combobox添加已经查到的关键词
            this.cboForDisplay.Items.AddRange(listNew_cboForDisplay.ToArray());
            // 设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            this.cboForDisplay.SelectionStart = this.cboForDisplay.Text.Length;
            // 保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            // 自动弹出下拉框
            this.cboForDisplay.DroppedDown = true;
        }

        #region 导出 案例编号，人员编号，参与方编号 到Excel
        private void CreateExcel(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            FileStream sw = File.Create(fileName);
            workbook.Write(sw);
            sw.Close();
        }

        private void WriteInfoToExcel(string fileName)
        {
            CreateExcel(fileName);

            FileStream fs = File.Open(fileName, FileMode.Open);
            IWorkbook workbook = new XSSFWorkbook(fs);
            ISheet sheet = workbook.GetSheetAt(0);

            // get the position of SelectedCells
            int colIndex = (dgvCars.SelectedCells[0].ColumnIndex);
            int rowIndex = (dgvCars.SelectedCells[0].RowIndex);
            int rowCount = dgvCars.Rows.Count;

            IRow row0 = sheet.CreateRow(0);
            row0.CreateCell(0).SetCellValue(tbCurrentName.Text);
            int cnt = 1;

            for (int i = 0; i < rowCount; i++)
            {
                if (dgvCars.Rows[i].Cells[colIndex].Value != DBNull.Value)
                {
                    object curVal = dgvCars.Rows[i].Cells[colIndex].Value;
                    IRow row = sheet.CreateRow(cnt);
                    row.CreateCell(0).SetCellValue(curVal.ToString());
                    cnt++;
                }
            }

            FileStream outFs = new FileStream(fileName, FileMode.Open);
            workbook.Write(outFs);
            outFs.Close();
        }
        private void btnOutputAL_Click(object sender, EventArgs e)
        {
            if (tbCurrentName.Text == "(SGDABH)案例编号")
            {
                string fileName = "案例编号.xlsx";

                WriteInfoToExcel(fileName);
                MessageBox.Show("案例编号导出成功");
            }
            else
            {
                MessageBox.Show("请选择案例编号所在列");
            }
        }

        private void btnOutputRY_Click(object sender, EventArgs e)
        {
            if (tbCurrentName.Text == "(RYBH)人员编号")
            {
                string fileName = "人员编号.xlsx";

                WriteInfoToExcel(fileName);
                MessageBox.Show("人员编号导出成功");
            }
            else
            {
                MessageBox.Show("请选择人员编号所在列");
            }
        }

        private void btnOutputCYF_Click(object sender, EventArgs e)
        {
            if (tbCurrentName.Text == "(CYFBH)参与方编号")
            {
                string fileName = "参与方编号.xlsx";

                WriteInfoToExcel(fileName);
                MessageBox.Show("参与方编号导出成功");
            }
            else
            {
                MessageBox.Show("请选择参与方编号所在列");
            }
        } 
        #endregion

        #region 将显示字段选中
        private void btnChooseField_Click(object sender, EventArgs e)
        {
            if (clbColumnForDisplay.Items.Count > 0)
            {
                //int cfd_index = cboForDisplay.SelectedIndex;
                //MessageBox.Show(cfd_index.ToString());
                string cfd_item = cboForDisplay.SelectedItem.ToString();
                int cfd_index = list_cboForDisplay.IndexOf(cfd_item);
                MessageBox.Show(cfd_item+" 已选中");
                if (cfd_index == -1)
                {
                    clbColumnForDisplay.SetItemChecked(0, true);
                }
                else
                {
                    clbColumnForDisplay.SetItemChecked(cfd_index, true);
                }
            }
        } 
        #endregion

        #region 用户自定义条件导入
        private string ExcelRead(string fileName)
        {
            string str = "";
            ISheet sheet = null;
            List<string> str_list = new List<string>();
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                IWorkbook workbook;
                workbook = new XSSFWorkbook(fs);

                sheet = workbook.GetSheetAt(0);

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int rowCount = sheet.LastRowNum;
                    if (rowCount >= 1)
                    {
                        for (int i = 1; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            //if (row == null) continue;
                            string tmpStr = row.GetCell(0).ToString();
                            if (str.Length == 0)
                            {
                                str = "(" + tmpStr;
                                str_list.Add(tmpStr);
                            }
                            else
                            {
                                if (!str_list.Contains(tmpStr))
                                {
                                    str_list.Add(tmpStr);
                                    str += ',' + tmpStr;
                                }
                            }
                        }
                        str += ")";
                    }
                }
                //MessageBox.Show(str);
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        private void btnInputAL_Click(object sender, EventArgs e)
        {
            string fileName = "案例编号.xlsx";
            if (File.Exists(fileName))
            {
                str_albh = ExcelRead(fileName);
                if (str_albh.Length != 0)
                    albh_flag = true;
                MessageBox.Show("案例编号导入成功");
            }
        }

        private void btnInputRY_Click(object sender, EventArgs e)
        {
            string fileName = "人员编号.xlsx";
            if (File.Exists(fileName))
            {
                str_rybh = ExcelRead(fileName);
                if (str_rybh.Length != 0)
                    rybh_flag = true;
                MessageBox.Show("人员编号导入成功");
            }
        }

        private void btnInputCYF_Click(object sender, EventArgs e)
        {
            string fileName = "参与方编号.xlsx";
            if (File.Exists(fileName))
            {
                str_cyfbh = ExcelRead(fileName);
                if (str_cyfbh.Length != 0)
                    cyfbh_flag = true;
                MessageBox.Show("参与方编号导入成功");
            }
        } 
        #endregion

        #region 在表20中生成追尾事故类型&侧碰事故类型
        private void btnAccidentType_Click(object sender, EventArgs e)
        {
            String sqlStr1 = "ALTER TABLE ['20单个事件的重建数据$'] DROP COLUMN [(ZWSGLX)追尾事故类型]"; // 碰撞类型 改为 追尾事故类型
            String sqlStr2 = "ALTER TABLE ['20单个事件的重建数据$'] ADD [(ZWSGLX)追尾事故类型] nvarchar(255)";
            String sqlStr = "UPDATE ['20单个事件的重建数据$'] set ['20单个事件的重建数据$'].[(ZWSGLX)追尾事故类型]=" +
            "(SELECT " +
                "[(ZWSGLX)追尾事故类型]=CASE WHEN Max速度=999 THEN 'C' WHEN Max速度=Min速度 THEN 'D' " +
                "WHEN [(CSSD2)初始速度]=Max速度 THEN 'B' WHEN [(CSSD2)初始速度]=Min速度 THEN 'A' END " +
            "FROM " +
                "(SELECT DISTINCT " +
                "[(SGDABH)案例编号] " +
                ",[(CYFBH)参与方编号] " +
                ",[(CSSD2)初始速度] " +
                ",MAX(ISNULL([(CSSD2)初始速度],999))OVER(PARTITION BY [(SGDABH)案例编号]) AS Max速度 " +
                ",Min(ISNULL([(CSSD2)初始速度],999))OVER(PARTITION BY [(SGDABH)案例编号]) AS Min速度 " +
                "FROM ['20单个事件的重建数据$']) AS T " +
                "WHERE ['20单个事件的重建数据$'].[(CYFBH)参与方编号]=T.[(CYFBH)参与方编号] " +
                "AND ['20单个事件的重建数据$'].[(CSSD2)初始速度]=T.[(CSSD2)初始速度] " +
                "AND ['20单个事件的重建数据$'].[(SGDABH)案例编号]=T.[(SGDABH)案例编号]) ";
            DataTable dt = SqlHelper.ExecuteDataTable("select COLUMN_NAME from information_schema.columns where table_name='''20单个事件的重建数据$''' and COLUMN_NAME = '(ZWSGLX)追尾事故类型'");
            // MessageBox.Show(dt.Rows.Count.ToString());
            if (dt.Rows.Count != 0)
            {
                SqlHelper.ExecuteNonQuery(sqlStr1);
            }

            SqlHelper.ExecuteNonQuery(sqlStr2);
            dt = SqlHelper.ExecuteDataTable(sqlStr);
            MessageBox.Show("追尾事故类型生成成功！");

            sqlStr = "ALTER TABLE ['20单个事件的重建数据$'] DROP COLUMN [(CPSGLX)侧碰事故类型]";
            dt = SqlHelper.ExecuteDataTable("select COLUMN_NAME from information_schema.columns where table_name='''20单个事件的重建数据$''' and COLUMN_NAME = '(CPSGLX)侧碰事故类型'");
            // MessageBox.Show(dt.Rows.Count.ToString());
            if (dt.Rows.Count != 0)
            {
                SqlHelper.ExecuteNonQuery(sqlStr);
            }

            sqlStr = "ALTER TABLE ['20单个事件的重建数据$'] ADD [(CPSGLX)侧碰事故类型] nvarchar(255)";
            SqlHelper.ExecuteNonQuery(sqlStr);

            sqlStr = "UPDATE ['20单个事件的重建数据$'] set ['20单个事件的重建数据$'].[(CPSGLX)侧碰事故类型]=" +
            "(SELECT " +
                "[(CPSGLX)侧碰事故类型]=CASE WHEN MaxVDI=93 THEN 'C' WHEN MaxVDI=MinVDI THEN 'D' WHEN [VDI减六后的绝对值] " +
                "=MaxVDI THEN 'B' WHEN [VDI减六后的绝对值]=MinVDI THEN 'A' END " +
            "FROM " +
                "(SELECT DISTINCT " +
                "[(SGDABH)案例编号] " +
                ",[(CYFBH)参与方编号] " +
                ",[(VDI_FX)VDI1方向] " +
                ",[VDI减六后的绝对值] " +
                ",MAX(ISNULL([VDI减六后的绝对值],93))OVER(PARTITION BY [(SGDABH)案例编号]) AS MaxVDI " +
                ",Min(ISNULL([VDI减六后的绝对值],93))OVER(PARTITION BY [(SGDABH)案例编号]) AS MinVDI " +
            "FROM " +
                "(SELECT " +
                "[(SGDABH)案例编号] " +
                ",[(CYFBH)参与方编号] " +
                ",[(VDI_FX)VDI1方向] " +
                ",ABS([(VDI_FX)VDI1方向]-6) AS [VDI减六后的绝对值] " +
                "FROM ['20单个事件的重建数据$'] " +
                ") AS b " +
                ") AS T " +
            "WHERE ['20单个事件的重建数据$'].[(CYFBH)参与方编号]=T.[(CYFBH)参与方编号] " +
                "AND ['20单个事件的重建数据$'].[(VDI_FX)VDI1方向]=T.[(VDI_FX)VDI1方向] " +
                "AND ['20单个事件的重建数据$'].[(SGDABH)案例编号]=T.[(SGDABH)案例编号]) ";
            dt = SqlHelper.ExecuteDataTable(sqlStr);
            MessageBox.Show("侧碰事故类型生成成功！");
        } 
        #endregion


    }
}
