namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_MutiRead = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.tb_ReadResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Status0 = new System.Windows.Forms.Label();
            this.tmr_Status = new System.Windows.Forms.Timer(this.components);
            this.tb_Command = new System.Windows.Forms.TextBox();
            this.btn_CmdSend = new System.Windows.Forms.Button();
            this.btn_SingleRead = new System.Windows.Forms.Button();
            this.lb_Status1 = new System.Windows.Forms.Label();
            this.cmb_ReaderId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_MutiRead
            // 
            this.btn_MutiRead.Location = new System.Drawing.Point(370, 357);
            this.btn_MutiRead.Margin = new System.Windows.Forms.Padding(2);
            this.btn_MutiRead.Name = "btn_MutiRead";
            this.btn_MutiRead.Size = new System.Drawing.Size(159, 62);
            this.btn_MutiRead.TabIndex = 0;
            this.btn_MutiRead.Text = "MutiRead";
            this.btn_MutiRead.UseVisualStyleBackColor = true;
            this.btn_MutiRead.Click += new System.EventHandler(this.btn_MutiRead_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(20, 75);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(142, 62);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "Open All";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // tb_ReadResult
            // 
            this.tb_ReadResult.Font = new System.Drawing.Font("新細明體", 24F);
            this.tb_ReadResult.Location = new System.Drawing.Point(34, 313);
            this.tb_ReadResult.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ReadResult.Multiline = true;
            this.tb_ReadResult.Name = "tb_ReadResult";
            this.tb_ReadResult.Size = new System.Drawing.Size(332, 177);
            this.tb_ReadResult.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 24F);
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "狀態：";
            // 
            // lb_Status0
            // 
            this.lb_Status0.Font = new System.Drawing.Font("新細明體", 24F);
            this.lb_Status0.Location = new System.Drawing.Point(182, 32);
            this.lb_Status0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Status0.Name = "lb_Status0";
            this.lb_Status0.Size = new System.Drawing.Size(176, 48);
            this.lb_Status0.TabIndex = 4;
            this.lb_Status0.Text = "N/A";
            // 
            // tmr_Status
            // 
            this.tmr_Status.Interval = 1000;
            this.tmr_Status.Tick += new System.EventHandler(this.tmr_Status_Tick);
            // 
            // tb_Command
            // 
            this.tb_Command.Font = new System.Drawing.Font("新細明體", 24F);
            this.tb_Command.Location = new System.Drawing.Point(34, 264);
            this.tb_Command.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Command.Name = "tb_Command";
            this.tb_Command.Size = new System.Drawing.Size(332, 46);
            this.tb_Command.TabIndex = 5;
            // 
            // btn_CmdSend
            // 
            this.btn_CmdSend.Location = new System.Drawing.Point(370, 264);
            this.btn_CmdSend.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CmdSend.Name = "btn_CmdSend";
            this.btn_CmdSend.Size = new System.Drawing.Size(159, 42);
            this.btn_CmdSend.TabIndex = 6;
            this.btn_CmdSend.Text = "Cmd";
            this.btn_CmdSend.UseVisualStyleBackColor = true;
            this.btn_CmdSend.Click += new System.EventHandler(this.btn_CmdSend_Click);
            // 
            // btn_SingleRead
            // 
            this.btn_SingleRead.Location = new System.Drawing.Point(370, 427);
            this.btn_SingleRead.Name = "btn_SingleRead";
            this.btn_SingleRead.Size = new System.Drawing.Size(159, 62);
            this.btn_SingleRead.TabIndex = 7;
            this.btn_SingleRead.Text = "SingleRead";
            this.btn_SingleRead.UseVisualStyleBackColor = true;
            this.btn_SingleRead.Click += new System.EventHandler(this.btn_SingleRead_Click);
            // 
            // lb_Status1
            // 
            this.lb_Status1.Font = new System.Drawing.Font("新細明體", 24F);
            this.lb_Status1.Location = new System.Drawing.Point(182, 89);
            this.lb_Status1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Status1.Name = "lb_Status1";
            this.lb_Status1.Size = new System.Drawing.Size(176, 48);
            this.lb_Status1.TabIndex = 8;
            this.lb_Status1.Text = "N/A";
            // 
            // cmb_ReaderId
            // 
            this.cmb_ReaderId.Font = new System.Drawing.Font("新細明體", 24F);
            this.cmb_ReaderId.FormattingEnabled = true;
            this.cmb_ReaderId.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmb_ReaderId.Location = new System.Drawing.Point(34, 219);
            this.cmb_ReaderId.Name = "cmb_ReaderId";
            this.cmb_ReaderId.Size = new System.Drawing.Size(121, 40);
            this.cmb_ReaderId.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 24F);
            this.label2.Location = new System.Drawing.Point(160, 222);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "192.168.100.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 548);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_ReaderId);
            this.Controls.Add(this.lb_Status1);
            this.Controls.Add(this.btn_SingleRead);
            this.Controls.Add(this.btn_CmdSend);
            this.Controls.Add(this.tb_Command);
            this.Controls.Add(this.lb_Status0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ReadResult);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_MutiRead);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_MutiRead;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox tb_ReadResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Status0;
        private System.Windows.Forms.Timer tmr_Status;
        private System.Windows.Forms.TextBox tb_Command;
        private System.Windows.Forms.Button btn_CmdSend;
        private System.Windows.Forms.Button btn_SingleRead;
        private System.Windows.Forms.Label lb_Status1;
        private System.Windows.Forms.ComboBox cmb_ReaderId;
        private System.Windows.Forms.Label label2;
    }
}

