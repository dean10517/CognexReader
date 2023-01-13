using Cognex.DataMan.SDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private void btn_Trigger_Click(object sender, EventArgs e)
        {
            string recvData = "";
            CognexReader.Read(ref recvData);
            tb_ReadResult.Text = recvData;
        }
    }

    public class CognexReader
    {
        //=====Parameter=====
        private static DataManSystem _MySys;
        private static bool _RecvedFlag = false;
        private static string _RecvedData;

        //=====Property======
        public static bool IsConnect { get; set; }

        //=====Event======
        private static void _MySys_SystemDisconnected(object sender, EventArgs args)
        {
            IsConnect = false;
        }
        private static void _MySys_SystemConnected(object sender, EventArgs args)
        {
            IsConnect = true;
        }
        private static void _MySys_ReadStringArrived(object sender, ReadStringArrivedEventArgs args)
        {
            _RecvedData = args.ReadString;
            _RecvedFlag = true;
        }

        //=====Method========
        public static int Open()
        {
            int nErrCode = -1;

            try
            {
                EthSystemConnector conn = new EthSystemConnector(System.Net.IPAddress.Parse("192.168.100.1"));
                _MySys = new DataManSystem(conn);
                _MySys.SystemConnected += _MySys_SystemConnected;
                _MySys.SystemDisconnected += _MySys_SystemDisconnected;
                _MySys.ReadStringArrived += _MySys_ReadStringArrived;
                _MySys.Connect(50);  //單位不確定ms還是s
                _MySys.SetResultTypes(ResultTypes.ReadString);

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }

        

        public static int Close()
        {
            int nErrCode = -1;

            try
            {
                _MySys.Disconnect();
                _MySys.Dispose();

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int Read(ref string recvData)
        {
            int nErrCode = -1;
            
            try
            {
                _RecvedData = "";       //讀取前先清空
                _RecvedFlag = false;    //讀取前先重置旗標
                _MySys.SendCommand("TRIGGER ON");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (_RecvedFlag == false)
                {
                    if(watch.ElapsedMilliseconds > 2000)
                    {
                        //超過兩秒沒收到條碼內容表示逾時
                        watch.Stop();
                        return -1;                        
                    }
                }
                recvData = _RecvedData;
                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int Cmd(string cmd, ref string recvData)
        {
            int nErrCode = -1;

            try
            {
                _RecvedData = "";       //讀取前先清空
                _RecvedFlag = false;    //讀取前先重置旗標
                _MySys.SendCommand(cmd + "\r\n");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (_RecvedFlag == false)
                {
                    if (watch.ElapsedMilliseconds > 2000)
                    {
                        //超過兩秒沒收到條碼內容表示逾時
                        watch.Stop();
                        return -1;
                    }
                }
                recvData = _RecvedData;
                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
    }
}
