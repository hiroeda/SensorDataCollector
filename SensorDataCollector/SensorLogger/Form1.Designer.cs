namespace SensorTest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbTemp = new System.Windows.Forms.ProgressBar();
            this.pbHumid = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblHumid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApiBaseUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "温度(℃)";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbTemp
            // 
            this.pbTemp.Location = new System.Drawing.Point(103, 2);
            this.pbTemp.Name = "pbTemp";
            this.pbTemp.Size = new System.Drawing.Size(211, 19);
            this.pbTemp.TabIndex = 1;
            // 
            // pbHumid
            // 
            this.pbHumid.Location = new System.Drawing.Point(103, 27);
            this.pbHumid.Name = "pbHumid";
            this.pbHumid.Size = new System.Drawing.Size(211, 19);
            this.pbHumid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "湿度(%)";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(68, 9);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(23, 12);
            this.lblTemp.TabIndex = 0;
            this.lblTemp.Text = "---";
            // 
            // lblHumid
            // 
            this.lblHumid.AutoSize = true;
            this.lblHumid.Location = new System.Drawing.Point(68, 31);
            this.lblHumid.Name = "lblHumid";
            this.lblHumid.Size = new System.Drawing.Size(23, 12);
            this.lblHumid.TabIndex = 0;
            this.lblHumid.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "収集APIのURL";
            // 
            // txtApiBaseUrl
            // 
            this.txtApiBaseUrl.Location = new System.Drawing.Point(103, 61);
            this.txtApiBaseUrl.Name = "txtApiBaseUrl";
            this.txtApiBaseUrl.ReadOnly = true;
            this.txtApiBaseUrl.Size = new System.Drawing.Size(211, 19);
            this.txtApiBaseUrl.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "収集状況";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(103, 86);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(211, 19);
            this.txtStatus.TabIndex = 3;
            this.txtStatus.Text = "(状況)";
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(330, 120);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtApiBaseUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbHumid);
            this.Controls.Add(this.pbTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHumid);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "センサー情報";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar pbTemp;
        private System.Windows.Forms.ProgressBar pbHumid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblHumid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApiBaseUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStatus;
    }
}

