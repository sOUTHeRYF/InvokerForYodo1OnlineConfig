namespace Yodo1OnlineConfigCaller
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxForPrefixOfTimes = new System.Windows.Forms.TextBox();
            this.BtnForStartAdd = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.TextBox();
            this.TextBoxForPrefixOfDes = new System.Windows.Forms.TextBox();
            this.TextBoxForPrefixOfKey = new System.Windows.Forms.TextBox();
            this.TextBoxForGameAppKey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnForStartModify = new System.Windows.Forms.Button();
            this.TextBoxForModifyPerKeyCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxForModifyKeyCount = new System.Windows.Forms.TextBox();
            this.ifExceptAdllVersion = new System.Windows.Forms.CheckBox();
            this.ifExceptAllChannel = new System.Windows.Forms.CheckBox();
            this.ifRandomConfig = new System.Windows.Forms.CheckBox();
            this.TextBoxForDataKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxForChannel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxForVersion = new System.Windows.Forms.TextBox();
            this.BtnForGetData = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RadioBtnFor132 = new System.Windows.Forms.RadioButton();
            this.RadioBtnForLocalhost = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game App Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "参数Key前缀:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "参数Des前缀:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "添加条数:";
            // 
            // TextBoxForPrefixOfTimes
            // 
            this.TextBoxForPrefixOfTimes.Location = new System.Drawing.Point(514, 31);
            this.TextBoxForPrefixOfTimes.Name = "TextBoxForPrefixOfTimes";
            this.TextBoxForPrefixOfTimes.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForPrefixOfTimes.TabIndex = 7;
            this.TextBoxForPrefixOfTimes.TextChanged += new System.EventHandler(this.TextBoxForAddConfig_TextChanged);
            // 
            // BtnForStartAdd
            // 
            this.BtnForStartAdd.Location = new System.Drawing.Point(643, 29);
            this.BtnForStartAdd.Name = "BtnForStartAdd";
            this.BtnForStartAdd.Size = new System.Drawing.Size(91, 23);
            this.BtnForStartAdd.TabIndex = 8;
            this.BtnForStartAdd.Text = "天火！！！";
            this.BtnForStartAdd.UseVisualStyleBackColor = true;
            this.BtnForStartAdd.Click += new System.EventHandler(this.BtnForStartAdd_Click);
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(14, 403);
            this.LogOut.Multiline = true;
            this.LogOut.Name = "LogOut";
            this.LogOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogOut.Size = new System.Drawing.Size(740, 143);
            this.LogOut.TabIndex = 9;
            // 
            // TextBoxForPrefixOfDes
            // 
            this.TextBoxForPrefixOfDes.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Yodo1OnlineConfigCaller.Properties.Settings.Default, "prefix_des", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBoxForPrefixOfDes.Location = new System.Drawing.Point(295, 31);
            this.TextBoxForPrefixOfDes.Name = "TextBoxForPrefixOfDes";
            this.TextBoxForPrefixOfDes.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForPrefixOfDes.TabIndex = 5;
            this.TextBoxForPrefixOfDes.Text = global::Yodo1OnlineConfigCaller.Properties.Settings.Default.prefix_des;
            this.TextBoxForPrefixOfDes.TextChanged += new System.EventHandler(this.TextBoxForAddConfig_TextChanged);
            // 
            // TextBoxForPrefixOfKey
            // 
            this.TextBoxForPrefixOfKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Yodo1OnlineConfigCaller.Properties.Settings.Default, "prefix_key", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBoxForPrefixOfKey.Location = new System.Drawing.Point(95, 31);
            this.TextBoxForPrefixOfKey.Name = "TextBoxForPrefixOfKey";
            this.TextBoxForPrefixOfKey.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForPrefixOfKey.TabIndex = 3;
            this.TextBoxForPrefixOfKey.Text = global::Yodo1OnlineConfigCaller.Properties.Settings.Default.prefix_key;
            this.TextBoxForPrefixOfKey.TextChanged += new System.EventHandler(this.TextBoxForAddConfig_TextChanged);
            // 
            // TextBoxForGameAppKey
            // 
            this.TextBoxForGameAppKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Yodo1OnlineConfigCaller.Properties.Settings.Default, "game_appkey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBoxForGameAppKey.Location = new System.Drawing.Point(109, 19);
            this.TextBoxForGameAppKey.Name = "TextBoxForGameAppKey";
            this.TextBoxForGameAppKey.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForGameAppKey.TabIndex = 1;
            this.TextBoxForGameAppKey.Text = global::Yodo1OnlineConfigCaller.Properties.Settings.Default.game_appkey;
            this.TextBoxForGameAppKey.TextChanged += new System.EventHandler(this.TextBoxForAddConfig_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnForStartAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TextBoxForPrefixOfTimes);
            this.groupBox1.Controls.Add(this.TextBoxForPrefixOfKey);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TextBoxForPrefixOfDes);
            this.groupBox1.Location = new System.Drawing.Point(14, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 81);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.BtnForStartModify);
            this.groupBox2.Controls.Add(this.TextBoxForModifyPerKeyCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TextBoxForModifyKeyCount);
            this.groupBox2.Controls.Add(this.ifExceptAdllVersion);
            this.groupBox2.Controls.Add(this.ifExceptAllChannel);
            this.groupBox2.Controls.Add(this.ifRandomConfig);
            this.groupBox2.Controls.Add(this.TextBoxForDataKey);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(14, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 103);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modify";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "每个Key修改次数:";
            // 
            // BtnForStartModify
            // 
            this.BtnForStartModify.Location = new System.Drawing.Point(643, 55);
            this.BtnForStartModify.Name = "BtnForStartModify";
            this.BtnForStartModify.Size = new System.Drawing.Size(91, 23);
            this.BtnForStartModify.TabIndex = 8;
            this.BtnForStartModify.Text = "吹风！！！";
            this.BtnForStartModify.UseVisualStyleBackColor = true;
            this.BtnForStartModify.Click += new System.EventHandler(this.BtnForStartModify_Click);
            // 
            // TextBoxForModifyPerKeyCount
            // 
            this.TextBoxForModifyPerKeyCount.Location = new System.Drawing.Point(514, 55);
            this.TextBoxForModifyPerKeyCount.Name = "TextBoxForModifyPerKeyCount";
            this.TextBoxForModifyPerKeyCount.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForModifyPerKeyCount.TabIndex = 7;
            this.TextBoxForModifyPerKeyCount.TextChanged += new System.EventHandler(this.TextBoxForModifyPerKeyCount_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "修改Key个数:";
            // 
            // TextBoxForModifyKeyCount
            // 
            this.TextBoxForModifyKeyCount.Location = new System.Drawing.Point(295, 55);
            this.TextBoxForModifyKeyCount.Name = "TextBoxForModifyKeyCount";
            this.TextBoxForModifyKeyCount.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForModifyKeyCount.TabIndex = 5;
            // 
            // ifExceptAdllVersion
            // 
            this.ifExceptAdllVersion.AutoSize = true;
            this.ifExceptAdllVersion.Checked = true;
            this.ifExceptAdllVersion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ifExceptAdllVersion.Location = new System.Drawing.Point(557, 21);
            this.ifExceptAdllVersion.Name = "ifExceptAdllVersion";
            this.ifExceptAdllVersion.Size = new System.Drawing.Size(102, 16);
            this.ifExceptAdllVersion.TabIndex = 4;
            this.ifExceptAdllVersion.Text = "不包含All版本";
            this.ifExceptAdllVersion.UseVisualStyleBackColor = true;
            // 
            // ifExceptAllChannel
            // 
            this.ifExceptAllChannel.AutoSize = true;
            this.ifExceptAllChannel.Checked = true;
            this.ifExceptAllChannel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ifExceptAllChannel.Location = new System.Drawing.Point(424, 21);
            this.ifExceptAllChannel.Name = "ifExceptAllChannel";
            this.ifExceptAllChannel.Size = new System.Drawing.Size(102, 16);
            this.ifExceptAllChannel.TabIndex = 3;
            this.ifExceptAllChannel.Text = "不包含All渠道";
            this.ifExceptAllChannel.UseVisualStyleBackColor = true;
            // 
            // ifRandomConfig
            // 
            this.ifRandomConfig.AutoSize = true;
            this.ifRandomConfig.Checked = true;
            this.ifRandomConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ifRandomConfig.Location = new System.Drawing.Point(99, 20);
            this.ifRandomConfig.Name = "ifRandomConfig";
            this.ifRandomConfig.Size = new System.Drawing.Size(96, 16);
            this.ifRandomConfig.TabIndex = 2;
            this.ifRandomConfig.Text = "修改随机参数";
            this.ifRandomConfig.UseVisualStyleBackColor = true;
            this.ifRandomConfig.CheckedChanged += new System.EventHandler(this.ifRandomConfig_CheckedChanged);
            // 
            // TextBoxForDataKey
            // 
            this.TextBoxForDataKey.Location = new System.Drawing.Point(295, 18);
            this.TextBoxForDataKey.Name = "TextBoxForDataKey";
            this.TextBoxForDataKey.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForDataKey.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Data Key:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnForGetData);
            this.groupBox3.Controls.Add(this.TextBoxForVersion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TextBoxForChannel);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(14, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(740, 96);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client Get";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Channel:";
            // 
            // TextBoxForChannel
            // 
            this.TextBoxForChannel.Location = new System.Drawing.Point(95, 35);
            this.TextBoxForChannel.Name = "TextBoxForChannel";
            this.TextBoxForChannel.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForChannel.TabIndex = 1;
            this.TextBoxForChannel.Text = "360";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(214, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Version:";
            // 
            // TextBoxForVersion
            // 
            this.TextBoxForVersion.Location = new System.Drawing.Point(295, 34);
            this.TextBoxForVersion.Name = "TextBoxForVersion";
            this.TextBoxForVersion.Size = new System.Drawing.Size(100, 21);
            this.TextBoxForVersion.TabIndex = 3;
            this.TextBoxForVersion.Text = "1.1.0";
            // 
            // BtnForGetData
            // 
            this.BtnForGetData.Location = new System.Drawing.Point(643, 35);
            this.BtnForGetData.Name = "BtnForGetData";
            this.BtnForGetData.Size = new System.Drawing.Size(91, 23);
            this.BtnForGetData.TabIndex = 4;
            this.BtnForGetData.Text = "陨石！！！";
            this.BtnForGetData.UseVisualStyleBackColor = true;
            this.BtnForGetData.Click += new System.EventHandler(this.BtnForGetData_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RadioBtnForLocalhost);
            this.groupBox4.Controls.Add(this.RadioBtnFor132);
            this.groupBox4.Location = new System.Drawing.Point(231, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 30);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "服务器切换";
            // 
            // RadioBtnFor132
            // 
            this.RadioBtnFor132.AutoSize = true;
            this.RadioBtnFor132.Checked = true;
            this.RadioBtnFor132.Location = new System.Drawing.Point(80, 10);
            this.RadioBtnFor132.Name = "RadioBtnFor132";
            this.RadioBtnFor132.Size = new System.Drawing.Size(77, 16);
            this.RadioBtnFor132.TabIndex = 0;
            this.RadioBtnFor132.TabStop = true;
            this.RadioBtnFor132.Text = "132服务器";
            this.RadioBtnFor132.UseVisualStyleBackColor = true;
            // 
            // RadioBtnForLocalhost
            // 
            this.RadioBtnForLocalhost.AutoSize = true;
            this.RadioBtnForLocalhost.Location = new System.Drawing.Point(182, 10);
            this.RadioBtnForLocalhost.Name = "RadioBtnForLocalhost";
            this.RadioBtnForLocalhost.Size = new System.Drawing.Size(83, 16);
            this.RadioBtnForLocalhost.TabIndex = 1;
            this.RadioBtnForLocalhost.TabStop = true;
            this.RadioBtnForLocalhost.Text = "本地服务器";
            this.RadioBtnForLocalhost.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 558);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.TextBoxForGameAppKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LogOut);
            this.Name = "Main";
            this.Text = "Yodo1 Online Config Caller";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxForGameAppKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxForPrefixOfKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxForPrefixOfDes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxForPrefixOfTimes;
        private System.Windows.Forms.Button BtnForStartAdd;
        private System.Windows.Forms.TextBox LogOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnForStartModify;
        private System.Windows.Forms.TextBox TextBoxForModifyPerKeyCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxForModifyKeyCount;
        private System.Windows.Forms.CheckBox ifExceptAdllVersion;
        private System.Windows.Forms.CheckBox ifExceptAllChannel;
        private System.Windows.Forms.CheckBox ifRandomConfig;
        private System.Windows.Forms.TextBox TextBoxForDataKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnForGetData;
        private System.Windows.Forms.TextBox TextBoxForVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextBoxForChannel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RadioBtnForLocalhost;
        private System.Windows.Forms.RadioButton RadioBtnFor132;
    }
}

