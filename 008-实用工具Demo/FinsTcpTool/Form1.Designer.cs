namespace FinsTcpTool
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_IP = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_WriteBool = new System.Windows.Forms.Button();
            this.txt_InAddr = new System.Windows.Forms.TextBox();
            this.txt_InValue = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_OutAddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_ReadBool = new System.Windows.Forms.Button();
            this.btn_WriteBools = new System.Windows.Forms.Button();
            this.btn_ReadBools = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_IP.Location = new System.Drawing.Point(12, 26);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(50, 20);
            this.lbl_IP.TabIndex = 0;
            this.lbl_IP.Text = "IP地址";
            // 
            // txt_IP
            // 
            this.txt_IP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_IP.Location = new System.Drawing.Point(69, 23);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(139, 23);
            this.txt_IP.TabIndex = 1;
            // 
            // txt_Port
            // 
            this.txt_Port.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Port.Location = new System.Drawing.Point(69, 58);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(139, 23);
            this.txt_Port.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "端口号";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Connect.Location = new System.Drawing.Point(224, 23);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 56);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.Location = new System.Drawing.Point(315, 23);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 56);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "断开";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.Location = new System.Drawing.Point(407, 23);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 56);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "保存参数";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_WriteBools);
            this.groupBox1.Controls.Add(this.txt_InValue);
            this.groupBox1.Controls.Add(this.txt_InAddr);
            this.groupBox1.Controls.Add(this.btn_WriteBool);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 250);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "写入";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(10, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "值";
            // 
            // btn_WriteBool
            // 
            this.btn_WriteBool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WriteBool.Location = new System.Drawing.Point(67, 124);
            this.btn_WriteBool.Name = "btn_WriteBool";
            this.btn_WriteBool.Size = new System.Drawing.Size(80, 29);
            this.btn_WriteBool.TabIndex = 8;
            this.btn_WriteBool.Text = "bool写入";
            this.btn_WriteBool.UseVisualStyleBackColor = true;
            this.btn_WriteBool.Click += new System.EventHandler(this.btn_WriteBool_Click);
            // 
            // txt_InAddr
            // 
            this.txt_InAddr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_InAddr.Location = new System.Drawing.Point(67, 30);
            this.txt_InAddr.Name = "txt_InAddr";
            this.txt_InAddr.Size = new System.Drawing.Size(139, 23);
            this.txt_InAddr.TabIndex = 8;
            // 
            // txt_InValue
            // 
            this.txt_InValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_InValue.Location = new System.Drawing.Point(67, 72);
            this.txt_InValue.Name = "txt_InValue";
            this.txt_InValue.Size = new System.Drawing.Size(139, 23);
            this.txt_InValue.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstBox);
            this.groupBox2.Controls.Add(this.btn_ReadBools);
            this.groupBox2.Controls.Add(this.btn_ReadBool);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_OutAddr);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(232, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 250);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读取";
            // 
            // txt_OutAddr
            // 
            this.txt_OutAddr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OutAddr.Location = new System.Drawing.Point(70, 31);
            this.txt_OutAddr.Name = "txt_OutAddr";
            this.txt_OutAddr.Size = new System.Drawing.Size(139, 23);
            this.txt_OutAddr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "结果";
            // 
            // btn_ReadBool
            // 
            this.btn_ReadBool.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReadBool.Location = new System.Drawing.Point(241, 26);
            this.btn_ReadBool.Name = "btn_ReadBool";
            this.btn_ReadBool.Size = new System.Drawing.Size(80, 29);
            this.btn_ReadBool.TabIndex = 12;
            this.btn_ReadBool.Text = "bool读取";
            this.btn_ReadBool.UseVisualStyleBackColor = true;
            this.btn_ReadBool.Click += new System.EventHandler(this.btn_ReadBool_Click);
            // 
            // btn_WriteBools
            // 
            this.btn_WriteBools.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WriteBools.Location = new System.Drawing.Point(67, 169);
            this.btn_WriteBools.Name = "btn_WriteBools";
            this.btn_WriteBools.Size = new System.Drawing.Size(109, 29);
            this.btn_WriteBools.TabIndex = 10;
            this.btn_WriteBools.Text = "bool数组写入";
            this.btn_WriteBools.UseVisualStyleBackColor = true;
            this.btn_WriteBools.Click += new System.EventHandler(this.btn_WriteBools_Click);
            // 
            // btn_ReadBools
            // 
            this.btn_ReadBools.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReadBools.Location = new System.Drawing.Point(327, 26);
            this.btn_ReadBools.Name = "btn_ReadBools";
            this.btn_ReadBools.Size = new System.Drawing.Size(109, 29);
            this.btn_ReadBools.TabIndex = 14;
            this.btn_ReadBools.Text = "bool数组读取";
            this.btn_ReadBools.UseVisualStyleBackColor = true;
            this.btn_ReadBools.Click += new System.EventHandler(this.btn_ReadBools_Click);
            // 
            // lstBox
            // 
            this.lstBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstBox.FormattingEnabled = true;
            this.lstBox.ItemHeight = 20;
            this.lstBox.Location = new System.Drawing.Point(70, 75);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(393, 164);
            this.lstBox.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 355);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.lbl_IP);
            this.Name = "Form1";
            this.Text = "FinsTcp测试工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_InValue;
        private System.Windows.Forms.TextBox txt_InAddr;
        private System.Windows.Forms.Button btn_WriteBool;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_OutAddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ReadBool;
        private System.Windows.Forms.Button btn_WriteBools;
        private System.Windows.Forms.Button btn_ReadBools;
        private System.Windows.Forms.ListBox lstBox;
    }
}

