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
            this.btn_Trigger = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.tb_ReadResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Status = new System.Windows.Forms.Label();
            this.tmr_Status = new System.Windows.Forms.Timer(this.components);
            this.tb_Command = new System.Windows.Forms.TextBox();
            this.btn_CmdSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Trigger
            // 
            this.btn_Trigger.Location = new System.Drawing.Point(57, 585);
            this.btn_Trigger.Name = "btn_Trigger";
            this.btn_Trigger.Size = new System.Drawing.Size(318, 128);
            this.btn_Trigger.TabIndex = 0;
            this.btn_Trigger.Text = "Trigger";
            this.btn_Trigger.UseVisualStyleBackColor = true;
            this.btn_Trigger.Click += new System.EventHandler(this.btn_Trigger_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(57, 433);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(318, 128);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // tb_ReadResult
            // 
            this.tb_ReadResult.Font = new System.Drawing.Font("PMingLiU", 24F);
            this.tb_ReadResult.Location = new System.Drawing.Point(57, 312);
            this.tb_ReadResult.Name = "tb_ReadResult";
            this.tb_ReadResult.Size = new System.Drawing.Size(659, 84);
            this.tb_ReadResult.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 24F);
            this.label1.Location = new System.Drawing.Point(55, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 64);
            this.label1.TabIndex = 3;
            this.label1.Text = "狀態：";
            // 
            // lb_Status
            // 
            this.lb_Status.Font = new System.Drawing.Font("PMingLiU", 24F);
            this.lb_Status.Location = new System.Drawing.Point(364, 68);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(353, 100);
            this.lb_Status.TabIndex = 4;
            this.lb_Status.Text = "N/A";
            // 
            // tmr_Status
            // 
            this.tmr_Status.Interval = 1000;
            this.tmr_Status.Tick += new System.EventHandler(this.tmr_Status_Tick);
            // 
            // tb_Command
            // 
            this.tb_Command.Font = new System.Drawing.Font("PMingLiU", 24F);
            this.tb_Command.Location = new System.Drawing.Point(57, 209);
            this.tb_Command.Name = "tb_Command";
            this.tb_Command.Size = new System.Drawing.Size(659, 84);
            this.tb_Command.TabIndex = 5;
            // 
            // btn_CmdSend
            // 
            this.btn_CmdSend.Location = new System.Drawing.Point(398, 433);
            this.btn_CmdSend.Name = "btn_CmdSend";
            this.btn_CmdSend.Size = new System.Drawing.Size(318, 128);
            this.btn_CmdSend.TabIndex = 6;
            this.btn_CmdSend.Text = "Cmd";
            this.btn_CmdSend.UseVisualStyleBackColor = true;
            this.btn_CmdSend.Click += new System.EventHandler(this.btn_CmdSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 807);
            this.Controls.Add(this.btn_CmdSend);
            this.Controls.Add(this.tb_Command);
            this.Controls.Add(this.lb_Status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ReadResult);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_Trigger);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Trigger;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox tb_ReadResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Timer tmr_Status;
        private System.Windows.Forms.TextBox tb_Command;
        private System.Windows.Forms.Button btn_CmdSend;
    }
}

