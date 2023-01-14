using Cognex.DataMan.SDK;
using System;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public class CognexReader
    {
        //=====Parameter=====
        private static DataManSystem _Reader;        //Cognex條碼機控制物件
        private static bool _RecvedFlag = false;    //條碼接收旗標
        private static string _RecvedData;          //條碼接收到的內容
        private static int _ReadTimeout = 2000;     //讀取條碼的逾時時間，單位ms

        //=====Property======
        public static bool IsConnect { get; set; }  //連線狀態

        //=====Event======
        private static void _Reader_SystemDisconnected(object sender, EventArgs args)
        {
            IsConnect = false;
        }
        private static void _Reader_SystemConnected(object sender, EventArgs args)
        {
            IsConnect = true;
        }
        private static void _Reader_ReadStringArrived(object sender, ReadStringArrivedEventArgs args)
        {
            _RecvedData = args.ReadString;
            _RecvedFlag = true;
            //Console.WriteLine(args.ReadString);
        }

        //=====Method========
        public static int Open()
        {
            int nErrCode = -1;

            try
            {
                EthSystemConnector readerConn = new EthSystemConnector(System.Net.IPAddress.Parse("192.168.100.1"));
                _Reader = new DataManSystem(readerConn);
                _Reader.SystemConnected += _Reader_SystemConnected;       //條碼機建立連線事件
                _Reader.SystemDisconnected += _Reader_SystemDisconnected; //條碼機斷線事件
                _Reader.ReadStringArrived += _Reader_ReadStringArrived;   //接收到資料的事件              
                _Reader.Connect(50);                                     //建立連線，逾時的時間單位不確定ms還是s
                _Reader.SetResultTypes(ResultTypes.ReadString);          //要設定這個_Reader_ReadStringArrived事件才會有作用
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
                _Reader.Disconnect();
                _Reader.Dispose();

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int SingleRead(ref string recvData)
        {
            int nErrCode = -1;
            string originData = "";

            try
            {
                nErrCode = Read(ref originData);    //讀取完整的字串資料
                if (nErrCode != 0)
                    return nErrCode;

                recvData = originData;
                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int MutiRead(ref string[] recvData)
        {
            int nErrCode = -1;
            string originData = "";

            try
            {
                nErrCode = Read(ref originData);    //讀取完整的字串資料
                if (nErrCode != 0)
                    return nErrCode;

                recvData = originData.Split(',');   //將字串資料以逗號拆解
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
                var result = _Reader.SendCommand(cmd + "\r\n");
                recvData = result.PayLoad;
                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        private static int Read(ref string recvData)
        {
            int nErrCode = -1;

            try
            {
                _RecvedData = "";                   //讀取前先清空
                _RecvedFlag = false;                //讀取前先重置旗標

                _Reader.SendCommand("TRIGGER ON");   //觸發命令

                Stopwatch watch = new Stopwatch();  //逾時判斷，訊息由事件接收
                watch.Start();
                while (_RecvedFlag == false)
                {
                    if (watch.ElapsedMilliseconds > _ReadTimeout)
                    {
                        //超過兩秒沒收到條碼內容表示逾時
                        watch.Stop();
                        return -1;
                    }
                }

                recvData = _RecvedData;             //將完整的字串資料回傳出去

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
