namespace WenKu                 //已看
{
    partial class baidu
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)  //Dispose是做什么的？  定义布尔类型变量disposing有什么用？（dispose:处理）
        {
            if (disposing && (components != null))     //(component:组件)
            {
                components.Dispose();        //Dispose()函数有什么用？
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baidu));
            this.label1 = new System.Windows.Forms.Label();
            this.WebSiteAdd = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.beginBtn = new System.Windows.Forms.Button();
            this.suspendBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.sPassword = new System.Windows.Forms.TextBox();
            this.sName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.serverName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverAdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStat = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.WebOInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.websiteName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LtimeGo = new System.Windows.Forms.Label();
            this.LfileADD = new System.Windows.Forms.Label();
            this.CurrKWord = new System.Windows.Forms.Label();
            this.NKWord = new System.Windows.Forms.Label();
            this.KeyConnect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmBInterval = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmBOrder = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "网站地址：";
            // 
            // WebSiteAdd
            // 
            this.WebSiteAdd.Location = new System.Drawing.Point(87, 66);
            this.WebSiteAdd.Name = "WebSiteAdd";
            this.WebSiteAdd.Size = new System.Drawing.Size(152, 21);
            this.WebSiteAdd.TabIndex = 3;
            this.WebSiteAdd.Text = "http://wenku.baidu.com/";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 183);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(259, 198);
            this.LogBox.TabIndex = 6;
            this.LogBox.Text = "";
            // 
            // beginBtn
            // 
            this.beginBtn.Location = new System.Drawing.Point(13, 24);
            this.beginBtn.Name = "beginBtn";
            this.beginBtn.Size = new System.Drawing.Size(75, 23);
            this.beginBtn.TabIndex = 7;
            this.beginBtn.Text = "开始抓取";
            this.beginBtn.UseVisualStyleBackColor = true;
            this.beginBtn.Click += new System.EventHandler(this.BeginBtn_Click);
            // 
            // suspendBtn
            // 
            this.suspendBtn.Location = new System.Drawing.Point(13, 69);
            this.suspendBtn.Name = "suspendBtn";
            this.suspendBtn.Size = new System.Drawing.Size(75, 23);
            this.suspendBtn.TabIndex = 9;
            this.suspendBtn.Text = "暂停抓取";
            this.suspendBtn.UseVisualStyleBackColor = true;
            this.suspendBtn.Click += new System.EventHandler(this.suspendBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(13, 117);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 10;
            this.stopBtn.Text = "停止";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectBtn);
            this.groupBox1.Controls.Add(this.sPassword);
            this.groupBox1.Controls.Add(this.sName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.serverName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.serverAdd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 147);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(198, 113);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(55, 23);
            this.connectBtn.TabIndex = 8;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // sPassword
            // 
            this.sPassword.Location = new System.Drawing.Point(69, 115);
            this.sPassword.Name = "sPassword";
            this.sPassword.Size = new System.Drawing.Size(118, 21);
            this.sPassword.TabIndex = 7;
            this.sPassword.Text = "jindian0928";
            this.sPassword.UseSystemPasswordChar = true;
            // 
            // sName
            // 
            this.sName.Location = new System.Drawing.Point(69, 88);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(51, 21);
            this.sName.TabIndex = 6;
            this.sName.Text = "sa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "登录名：";
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(99, 54);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(134, 21);
            this.serverName.TabIndex = 3;
            this.serverName.Text = "SPIDER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据库名称：";
            // 
            // serverAdd
            // 
            this.serverAdd.Location = new System.Drawing.Point(99, 25);
            this.serverAdd.Name = "serverAdd";
            this.serverAdd.Size = new System.Drawing.Size(134, 21);
            this.serverAdd.TabIndex = 1;
            this.serverAdd.Text = "202.196.37.60";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "服务器地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStat);
            this.groupBox2.Controls.Add(this.beginBtn);
            this.groupBox2.Controls.Add(this.suspendBtn);
            this.groupBox2.Controls.Add(this.stopBtn);
            this.groupBox2.Location = new System.Drawing.Point(423, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 207);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnStat
            // 
            this.btnStat.Location = new System.Drawing.Point(13, 169);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(75, 23);
            this.btnStat.TabIndex = 11;
            this.btnStat.Text = "统计";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.WebOInfo);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.websiteName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.WebSiteAdd);
            this.groupBox3.Location = new System.Drawing.Point(289, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 147);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "抓取目标";
            // 
            // WebOInfo
            // 
            this.WebOInfo.Location = new System.Drawing.Point(87, 99);
            this.WebOInfo.Name = "WebOInfo";
            this.WebOInfo.Size = new System.Drawing.Size(135, 21);
            this.WebOInfo.TabIndex = 12;
            this.WebOInfo.Text = "search?word=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "附加信息：";
            // 
            // websiteName
            // 
            this.websiteName.Location = new System.Drawing.Point(87, 33);
            this.websiteName.Name = "websiteName";
            this.websiteName.Size = new System.Drawing.Size(135, 21);
            this.websiteName.TabIndex = 10;
            this.websiteName.Text = "百度文库";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "网站名称：";
            // 
            // LtimeGo
            // 
            this.LtimeGo.AutoSize = true;
            this.LtimeGo.Location = new System.Drawing.Point(10, 405);
            this.LtimeGo.Name = "LtimeGo";
            this.LtimeGo.Size = new System.Drawing.Size(77, 12);
            this.LtimeGo.TabIndex = 14;
            this.LtimeGo.Text = "已运行时间：";
            // 
            // LfileADD
            // 
            this.LfileADD.AutoSize = true;
            this.LfileADD.Location = new System.Drawing.Point(287, 405);
            this.LfileADD.Name = "LfileADD";
            this.LfileADD.Size = new System.Drawing.Size(89, 12);
            this.LfileADD.TabIndex = 15;
            this.LfileADD.Text = "已解析出链接：";
            // 
            // CurrKWord
            // 
            this.CurrKWord.AutoSize = true;
            this.CurrKWord.Location = new System.Drawing.Point(287, 427);
            this.CurrKWord.Name = "CurrKWord";
            this.CurrKWord.Size = new System.Drawing.Size(77, 12);
            this.CurrKWord.TabIndex = 18;
            this.CurrKWord.Text = "当前检索词：";
            // 
            // NKWord
            // 
            this.NKWord.AutoSize = true;
            this.NKWord.Location = new System.Drawing.Point(10, 427);
            this.NKWord.Name = "NKWord";
            this.NKWord.Size = new System.Drawing.Size(77, 12);
            this.NKWord.TabIndex = 19;
            this.NKWord.Text = "已检索词数：";
            // 
            // KeyConnect
            // 
            this.KeyConnect.Location = new System.Drawing.Point(52, 169);
            this.KeyConnect.Name = "KeyConnect";
            this.KeyConnect.Size = new System.Drawing.Size(61, 23);
            this.KeyConnect.TabIndex = 11;
            this.KeyConnect.Text = "参数确认";
            this.KeyConnect.UseVisualStyleBackColor = true;
            this.KeyConnect.Click += new System.EventHandler(this.KeyConnect_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmBInterval);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cmBOrder);
            this.groupBox4.Controls.Add(this.KeyConnect);
            this.groupBox4.Location = new System.Drawing.Point(289, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 207);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设置";
            // 
            // cmBInterval
            // 
            this.cmBInterval.FormattingEnabled = true;
            this.cmBInterval.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "60"});
            this.cmBInterval.Location = new System.Drawing.Point(67, 138);
            this.cmBInterval.Name = "cmBInterval";
            this.cmBInterval.Size = new System.Drawing.Size(46, 20);
            this.cmBInterval.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "间隔：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "排序：";
            // 
            // cmBOrder
            // 
            this.cmBOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBOrder.FormattingEnabled = true;
            this.cmBOrder.Items.AddRange(new object[] {
            "相关",
            "最新",
            "最多"});
            this.cmBOrder.Location = new System.Drawing.Point(67, 103);
            this.cmBOrder.Name = "cmBOrder";
            this.cmBOrder.Size = new System.Drawing.Size(46, 20);
            this.cmBOrder.TabIndex = 16;
            // 
            // baidu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 451);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.NKWord);
            this.Controls.Add(this.CurrKWord);
            this.Controls.Add(this.LfileADD);
            this.Controls.Add(this.LtimeGo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LogBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baidu";
            this.Text = "Baidu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WebSiteAdd;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Button beginBtn;
        private System.Windows.Forms.Button suspendBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox sPassword;
        private System.Windows.Forms.TextBox sName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox websiteName;
        private System.Windows.Forms.Label LtimeGo;
        private System.Windows.Forms.Label LfileADD;
        private System.Windows.Forms.Label CurrKWord;
        private System.Windows.Forms.Label NKWord;
        private System.Windows.Forms.Button KeyConnect;
        private System.Windows.Forms.TextBox WebOInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmBOrder;
        private System.Windows.Forms.ComboBox cmBInterval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnStat;
    }
}

