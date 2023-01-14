using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //=====FormEvent=====
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CognexReader.Close();
        }
        private void tmr_Status_Tick(object sender, EventArgs e)
        {
            lb_Status.Text = CognexReader.IsConnect ? "Connected" : "Disconnected";
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            CognexReader.Open();
            tmr_Status.Enabled = true;
        }
        private void btn_CmdSend_Click(object sender, EventArgs e)
        {
            try
            {
                string recvData = "";
                CognexReader.Cmd(tb_Command.Text, ref recvData);
                tb_ReadResult.Text = recvData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void btn_MutiRead_Click(object sender, EventArgs e)
        {
            string[] recvData = new string[] { };
            CognexReader.MutiRead(ref recvData);
            tb_ReadResult.Text = "";
            foreach (string s in recvData)
            {
                tb_ReadResult.Text += s + "\r\n";
            }            
        }
        private void btn_SingleRead_Click(object sender, EventArgs e)
        {
            string recvData = "";
            CognexReader.SingleRead(ref recvData);
            tb_ReadResult.Text = recvData;            
        }
    }
}
