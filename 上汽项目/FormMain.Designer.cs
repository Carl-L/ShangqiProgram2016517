namespace 上汽项目
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.clbConditions = new System.Windows.Forms.CheckedListBox();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.txtSearchType = new System.Windows.Forms.TextBox();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMulti = new System.Windows.Forms.Button();
            this.lblAccidentType = new System.Windows.Forms.Label();
            this.cboAccidentType = new System.Windows.Forms.ComboBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.btnClearConditions = new System.Windows.Forms.Button();
            this.cbSelectAllConditions = new System.Windows.Forms.CheckBox();
            this.btnDeleteCondition = new System.Windows.Forms.Button();
            this.cbSelectAllColumns = new System.Windows.Forms.CheckBox();
            this.lblColumnForDisplay = new System.Windows.Forms.Label();
            this.clbColumnForDisplay = new System.Windows.Forms.CheckedListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAveVal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaxVal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMinVal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMiddleVal = new System.Windows.Forms.TextBox();
            this.dgvDataDistribution = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentName = new System.Windows.Forms.TextBox();
            this.cboForDisplay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseField = new System.Windows.Forms.Button();
            this.btnOutputAL = new System.Windows.Forms.Button();
            this.btnInputAL = new System.Windows.Forms.Button();
            this.btnInputRY = new System.Windows.Forms.Button();
            this.btnOutputRY = new System.Windows.Forms.Button();
            this.btnInputCYF = new System.Windows.Forms.Button();
            this.btnOutputCYF = new System.Windows.Forms.Button();
            this.btnAccidentType = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMeanVal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDistribution)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCars
            // 
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Location = new System.Drawing.Point(8, 20);
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.RowTemplate.Height = 23;
            this.dgvCars.Size = new System.Drawing.Size(687, 362);
            this.dgvCars.TabIndex = 2;
            this.dgvCars.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCars_MouseClick);
            // 
            // clbConditions
            // 
            this.clbConditions.FormattingEnabled = true;
            this.clbConditions.HorizontalScrollbar = true;
            this.clbConditions.Location = new System.Drawing.Point(6, 34);
            this.clbConditions.Name = "clbConditions";
            this.clbConditions.Size = new System.Drawing.Size(567, 180);
            this.clbConditions.TabIndex = 10;
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Location = new System.Drawing.Point(255, 33);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(104, 32);
            this.btnAddCondition.TabIndex = 11;
            this.btnAddCondition.Text = "添加检索条件";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Location = new System.Drawing.Point(6, 98);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(65, 12);
            this.lblSearchType.TabIndex = 13;
            this.lblSearchType.Text = "查询类型：";
            // 
            // txtSearchType
            // 
            this.txtSearchType.Location = new System.Drawing.Point(80, 140);
            this.txtSearchType.Name = "txtSearchType";
            this.txtSearchType.Size = new System.Drawing.Size(156, 21);
            this.txtSearchType.TabIndex = 14;
            // 
            // cboSearchType
            // 
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Location = new System.Drawing.Point(80, 95);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(156, 20);
            this.cboSearchType.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "查询条件：";
            // 
            // btnMulti
            // 
            this.btnMulti.Location = new System.Drawing.Point(255, 86);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(104, 55);
            this.btnMulti.TabIndex = 17;
            this.btnMulti.Text = "多条件搜索";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // lblAccidentType
            // 
            this.lblAccidentType.AutoSize = true;
            this.lblAccidentType.Location = new System.Drawing.Point(6, 53);
            this.lblAccidentType.Name = "lblAccidentType";
            this.lblAccidentType.Size = new System.Drawing.Size(65, 12);
            this.lblAccidentType.TabIndex = 23;
            this.lblAccidentType.Text = "事故类型：";
            // 
            // cboAccidentType
            // 
            this.cboAccidentType.FormattingEnabled = true;
            this.cboAccidentType.Location = new System.Drawing.Point(80, 53);
            this.cboAccidentType.Name = "cboAccidentType";
            this.cboAccidentType.Size = new System.Drawing.Size(156, 20);
            this.cboAccidentType.TabIndex = 22;
            this.cboAccidentType.Text = "1仅乘用车";
            this.cboAccidentType.SelectedIndexChanged += new System.EventHandler(this.cboAccidentType_SelectedIndexChanged);
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(19, 12);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(89, 12);
            this.lblCondition.TabIndex = 29;
            this.lblCondition.Text = "条件选择列表：";
            // 
            // btnClearConditions
            // 
            this.btnClearConditions.Location = new System.Drawing.Point(184, 8);
            this.btnClearConditions.Name = "btnClearConditions";
            this.btnClearConditions.Size = new System.Drawing.Size(53, 23);
            this.btnClearConditions.TabIndex = 34;
            this.btnClearConditions.Text = "清 除";
            this.btnClearConditions.UseVisualStyleBackColor = true;
            this.btnClearConditions.Click += new System.EventHandler(this.btnClearConditions_Click);
            // 
            // cbSelectAllConditions
            // 
            this.cbSelectAllConditions.AutoSize = true;
            this.cbSelectAllConditions.Location = new System.Drawing.Point(114, 11);
            this.cbSelectAllConditions.Name = "cbSelectAllConditions";
            this.cbSelectAllConditions.Size = new System.Drawing.Size(54, 16);
            this.cbSelectAllConditions.TabIndex = 36;
            this.cbSelectAllConditions.Text = "全 选";
            this.cbSelectAllConditions.UseVisualStyleBackColor = true;
            this.cbSelectAllConditions.CheckedChanged += new System.EventHandler(this.cbSelectAllConditions_CheckedChanged);
            // 
            // btnDeleteCondition
            // 
            this.btnDeleteCondition.Location = new System.Drawing.Point(253, 8);
            this.btnDeleteCondition.Name = "btnDeleteCondition";
            this.btnDeleteCondition.Size = new System.Drawing.Size(53, 23);
            this.btnDeleteCondition.TabIndex = 37;
            this.btnDeleteCondition.Text = "删 除";
            this.btnDeleteCondition.UseVisualStyleBackColor = true;
            this.btnDeleteCondition.Click += new System.EventHandler(this.btnDeleteCondition_Click);
            // 
            // cbSelectAllColumns
            // 
            this.cbSelectAllColumns.AutoSize = true;
            this.cbSelectAllColumns.Location = new System.Drawing.Point(125, 47);
            this.cbSelectAllColumns.Name = "cbSelectAllColumns";
            this.cbSelectAllColumns.Size = new System.Drawing.Size(54, 16);
            this.cbSelectAllColumns.TabIndex = 40;
            this.cbSelectAllColumns.Text = "全 选";
            this.cbSelectAllColumns.UseVisualStyleBackColor = true;
            this.cbSelectAllColumns.CheckedChanged += new System.EventHandler(this.cbSelectAllColumns_CheckedChanged);
            // 
            // lblColumnForDisplay
            // 
            this.lblColumnForDisplay.AutoSize = true;
            this.lblColumnForDisplay.Location = new System.Drawing.Point(6, 48);
            this.lblColumnForDisplay.Name = "lblColumnForDisplay";
            this.lblColumnForDisplay.Size = new System.Drawing.Size(113, 12);
            this.lblColumnForDisplay.TabIndex = 39;
            this.lblColumnForDisplay.Text = "选择需要显示的列：";
            // 
            // clbColumnForDisplay
            // 
            this.clbColumnForDisplay.FormattingEnabled = true;
            this.clbColumnForDisplay.HorizontalScrollbar = true;
            this.clbColumnForDisplay.Location = new System.Drawing.Point(6, 73);
            this.clbColumnForDisplay.Name = "clbColumnForDisplay";
            this.clbColumnForDisplay.Size = new System.Drawing.Size(243, 148);
            this.clbColumnForDisplay.TabIndex = 38;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(136, 162);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(111, 43);
            this.btnDownload.TabIndex = 43;
            this.btnDownload.Text = "导 出 Excel";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "表名-字段：";
            // 
            // cboField
            // 
            this.cboField.DropDownWidth = 364;
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(80, 14);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(156, 20);
            this.cboField.TabIndex = 48;
            this.cboField.Text = "[\'01环境和一般事故数据$\'].[(SGDABH)案例编号]";
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            this.cboField.TextUpdate += new System.EventHandler(this.cboField_TextUpdate);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 391);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "平均值：";
            // 
            // txtAveVal
            // 
            this.txtAveVal.Location = new System.Drawing.Point(190, 388);
            this.txtAveVal.Name = "txtAveVal";
            this.txtAveVal.Size = new System.Drawing.Size(89, 21);
            this.txtAveVal.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "最大值：";
            // 
            // txtMaxVal
            // 
            this.txtMaxVal.Location = new System.Drawing.Point(332, 389);
            this.txtMaxVal.Name = "txtMaxVal";
            this.txtMaxVal.Size = new System.Drawing.Size(84, 21);
            this.txtMaxVal.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(422, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 53;
            this.label8.Text = "最小值：";
            // 
            // txtMinVal
            // 
            this.txtMinVal.Location = new System.Drawing.Point(469, 389);
            this.txtMinVal.Name = "txtMinVal";
            this.txtMinVal.Size = new System.Drawing.Size(84, 21);
            this.txtMinVal.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(559, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "中位数：";
            // 
            // txtMiddleVal
            // 
            this.txtMiddleVal.Location = new System.Drawing.Point(608, 389);
            this.txtMiddleVal.Name = "txtMiddleVal";
            this.txtMiddleVal.Size = new System.Drawing.Size(93, 21);
            this.txtMiddleVal.TabIndex = 56;
            // 
            // dgvDataDistribution
            // 
            this.dgvDataDistribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDistribution.Location = new System.Drawing.Point(993, 252);
            this.dgvDataDistribution.Name = "dgvDataDistribution";
            this.dgvDataDistribution.RowTemplate.Height = 23;
            this.dgvDataDistribution.Size = new System.Drawing.Size(193, 362);
            this.dgvDataDistribution.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 59;
            this.label2.Text = "当前字段名：";
            // 
            // tbCurrentName
            // 
            this.tbCurrentName.Location = new System.Drawing.Point(91, 13);
            this.tbCurrentName.Name = "tbCurrentName";
            this.tbCurrentName.Size = new System.Drawing.Size(156, 21);
            this.tbCurrentName.TabIndex = 60;
            // 
            // cboForDisplay
            // 
            this.cboForDisplay.DropDownWidth = 400;
            this.cboForDisplay.FormattingEnabled = true;
            this.cboForDisplay.Location = new System.Drawing.Point(77, 14);
            this.cboForDisplay.Name = "cboForDisplay";
            this.cboForDisplay.Size = new System.Drawing.Size(156, 20);
            this.cboForDisplay.TabIndex = 63;
            this.cboForDisplay.TextUpdate += new System.EventHandler(this.cboForDisplay_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "显示字段：";
            // 
            // btnChooseField
            // 
            this.btnChooseField.Location = new System.Drawing.Point(188, 44);
            this.btnChooseField.Name = "btnChooseField";
            this.btnChooseField.Size = new System.Drawing.Size(53, 23);
            this.btnChooseField.TabIndex = 64;
            this.btnChooseField.Text = "选 中";
            this.btnChooseField.UseVisualStyleBackColor = true;
            this.btnChooseField.Click += new System.EventHandler(this.btnChooseField_Click);
            // 
            // btnOutputAL
            // 
            this.btnOutputAL.Location = new System.Drawing.Point(6, 40);
            this.btnOutputAL.Name = "btnOutputAL";
            this.btnOutputAL.Size = new System.Drawing.Size(106, 32);
            this.btnOutputAL.TabIndex = 65;
            this.btnOutputAL.Text = "导 出 案例编号";
            this.btnOutputAL.UseVisualStyleBackColor = true;
            this.btnOutputAL.Click += new System.EventHandler(this.btnOutputAL_Click);
            // 
            // btnInputAL
            // 
            this.btnInputAL.Location = new System.Drawing.Point(135, 40);
            this.btnInputAL.Name = "btnInputAL";
            this.btnInputAL.Size = new System.Drawing.Size(106, 32);
            this.btnInputAL.TabIndex = 66;
            this.btnInputAL.Text = "导 入 案例编号";
            this.btnInputAL.UseVisualStyleBackColor = true;
            this.btnInputAL.Click += new System.EventHandler(this.btnInputAL_Click);
            // 
            // btnInputRY
            // 
            this.btnInputRY.Location = new System.Drawing.Point(135, 78);
            this.btnInputRY.Name = "btnInputRY";
            this.btnInputRY.Size = new System.Drawing.Size(106, 32);
            this.btnInputRY.TabIndex = 68;
            this.btnInputRY.Text = "导 入 人员编号";
            this.btnInputRY.UseVisualStyleBackColor = true;
            this.btnInputRY.Click += new System.EventHandler(this.btnInputRY_Click);
            // 
            // btnOutputRY
            // 
            this.btnOutputRY.Location = new System.Drawing.Point(6, 78);
            this.btnOutputRY.Name = "btnOutputRY";
            this.btnOutputRY.Size = new System.Drawing.Size(106, 32);
            this.btnOutputRY.TabIndex = 67;
            this.btnOutputRY.Text = "导 出 人员编号";
            this.btnOutputRY.UseVisualStyleBackColor = true;
            this.btnOutputRY.Click += new System.EventHandler(this.btnOutputRY_Click);
            // 
            // btnInputCYF
            // 
            this.btnInputCYF.Location = new System.Drawing.Point(135, 116);
            this.btnInputCYF.Name = "btnInputCYF";
            this.btnInputCYF.Size = new System.Drawing.Size(112, 32);
            this.btnInputCYF.TabIndex = 70;
            this.btnInputCYF.Text = "导 入 参与方编号";
            this.btnInputCYF.UseVisualStyleBackColor = true;
            this.btnInputCYF.Click += new System.EventHandler(this.btnInputCYF_Click);
            // 
            // btnOutputCYF
            // 
            this.btnOutputCYF.Location = new System.Drawing.Point(6, 116);
            this.btnOutputCYF.Name = "btnOutputCYF";
            this.btnOutputCYF.Size = new System.Drawing.Size(112, 32);
            this.btnOutputCYF.TabIndex = 71;
            this.btnOutputCYF.Text = "导 出 参与方编号";
            this.btnOutputCYF.UseVisualStyleBackColor = true;
            this.btnOutputCYF.Click += new System.EventHandler(this.btnOutputCYF_Click);
            // 
            // btnAccidentType
            // 
            this.btnAccidentType.Location = new System.Drawing.Point(6, 162);
            this.btnAccidentType.Name = "btnAccidentType";
            this.btnAccidentType.Size = new System.Drawing.Size(106, 43);
            this.btnAccidentType.TabIndex = 72;
            this.btnAccidentType.Text = "生成事故类型";
            this.btnAccidentType.UseVisualStyleBackColor = true;
            this.btnAccidentType.Click += new System.EventHandler(this.btnAccidentType_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.cboField);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblAccidentType);
            this.groupBox1.Controls.Add(this.cboAccidentType);
            this.groupBox1.Controls.Add(this.btnMulti);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboSearchType);
            this.groupBox1.Controls.Add(this.txtSearchType);
            this.groupBox1.Controls.Add(this.lblSearchType);
            this.groupBox1.Controls.Add(this.btnAddCondition);
            this.groupBox1.Location = new System.Drawing.Point(19, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 166);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询输入";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.btnChooseField);
            this.groupBox2.Controls.Add(this.cboForDisplay);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbSelectAllColumns);
            this.groupBox2.Controls.Add(this.lblColumnForDisplay);
            this.groupBox2.Controls.Add(this.clbColumnForDisplay);
            this.groupBox2.Location = new System.Drawing.Point(18, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 234);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询输出选项选择";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Lavender;
            this.groupBox3.Controls.Add(this.btnAccidentType);
            this.groupBox3.Controls.Add(this.btnOutputCYF);
            this.groupBox3.Controls.Add(this.btnInputCYF);
            this.groupBox3.Controls.Add(this.btnInputRY);
            this.groupBox3.Controls.Add(this.btnOutputRY);
            this.groupBox3.Controls.Add(this.btnInputAL);
            this.groupBox3.Controls.Add(this.btnOutputAL);
            this.groupBox3.Controls.Add(this.tbCurrentName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnDownload);
            this.groupBox3.Location = new System.Drawing.Point(18, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 211);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "导入导出选项";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Lavender;
            this.groupBox4.Controls.Add(this.btnDeleteCondition);
            this.groupBox4.Controls.Add(this.cbSelectAllConditions);
            this.groupBox4.Controls.Add(this.btnClearConditions);
            this.groupBox4.Controls.Add(this.lblCondition);
            this.groupBox4.Controls.Add(this.clbConditions);
            this.groupBox4.Location = new System.Drawing.Point(402, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(585, 219);
            this.groupBox4.TabIndex = 76;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Lavender;
            this.groupBox5.Controls.Add(this.txtMeanVal);
            this.groupBox5.Controls.Add(this.txtMiddleVal);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtMinVal);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtMaxVal);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtAveVal);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.dgvCars);
            this.groupBox5.Location = new System.Drawing.Point(280, 232);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(707, 418);
            this.groupBox5.TabIndex = 77;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "查询输出显示";
            // 
            // txtMeanVal
            // 
            this.txtMeanVal.Location = new System.Drawing.Point(9, 388);
            this.txtMeanVal.Name = "txtMeanVal";
            this.txtMeanVal.ReadOnly = true;
            this.txtMeanVal.Size = new System.Drawing.Size(122, 21);
            this.txtMeanVal.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(993, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 78;
            this.label3.Text = "分类统计：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(993, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 202);
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 673);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDataDistribution);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "交通事故查询系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDistribution)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.CheckedListBox clbConditions;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.TextBox txtSearchType;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Label lblAccidentType;
        private System.Windows.Forms.ComboBox cboAccidentType;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Button btnClearConditions;
        private System.Windows.Forms.CheckBox cbSelectAllConditions;
        private System.Windows.Forms.Button btnDeleteCondition;
        private System.Windows.Forms.CheckBox cbSelectAllColumns;
        private System.Windows.Forms.Label lblColumnForDisplay;
        private System.Windows.Forms.CheckedListBox clbColumnForDisplay;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAveVal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaxVal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMinVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMiddleVal;
        private System.Windows.Forms.DataGridView dgvDataDistribution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrentName;
        private System.Windows.Forms.ComboBox cboForDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseField;
        private System.Windows.Forms.Button btnOutputAL;
        private System.Windows.Forms.Button btnInputAL;
        private System.Windows.Forms.Button btnInputRY;
        private System.Windows.Forms.Button btnOutputRY;
        private System.Windows.Forms.Button btnInputCYF;
        private System.Windows.Forms.Button btnOutputCYF;
        private System.Windows.Forms.Button btnAccidentType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtMeanVal;
    }
}

