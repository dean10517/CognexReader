using Cognex.DataMan.SDK;
using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public class CognexReader
    {
        public static string[] ReaderIP = new string[] { "192.168.100.1",
                                                        "192.168.100.2" };        

        private static CognexReaderUnit[] Reader = new CognexReaderUnit[2];
        private static string _ConfigFilePath = @"C:\Users\柏閔\Desktop\readerIp.cfg";
        private static bool _IsInitial = false;     //判斷是否已經初始化


        public static int LoadConfig()
        {
            int nErrCode = -1;

            try
            {
                if (System.IO.File.Exists(_ConfigFilePath) == false)
                {
                    nErrCode = SaveConfig();
                    if (nErrCode != 0)
                        return nErrCode;
                }
                else
                {
                    ReaderIP = (string[])JsonConvert.DeserializeObject(System.IO.File.ReadAllText(_ConfigFilePath));
                }

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int SaveConfig()
        {
            int nErrCode = -1;

            try
            {
                string jsonStr = JsonConvert.SerializeObject(ReaderIP); //序列化JSON字串
                System.IO.File.AppendAllText(_ConfigFilePath, jsonStr); //寫檔

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int Open()
        {
            int nErrCode = -1;

            try
            {
                for (int i = 0; i < Reader.Length; i++)
                {
                    //初始化條碼機
                    Reader[i] = new CognexReaderUnit(ReaderIP[i]);
                    nErrCode = Reader[i].Open();
                    if (nErrCode != 0)
                        return nErrCode;
                }
                _IsInitial = true;
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
                for (int i = 0; i < Reader.Length; i++)
                {
                    //關閉條碼機
                    Reader[i]?.Close();
                }

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static bool IsConnected(int readerId)
        {
            //確認readerId是否合法
            int nErrCode = _IsValid(readerId);
            if (nErrCode != 0)
                return false;

            return Reader[readerId].IsConnect;
        }
        public static int SingleRead(int readerId, ref string recvData)
        {
            int nErrCode = -1;

            try
            {
                //確認readerId是否合法
                nErrCode = _IsValid(readerId);
                if (nErrCode != 0)
                    return nErrCode;


                //讀取單個條碼
                nErrCode = Reader[readerId].SingleRead(ref recvData);
                if (nErrCode != 0)
                    return nErrCode;

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int MutiRead(int readerId, ref string[] recvData)
        {
            int nErrCode = -1;

            try
            {
                //確認readerId是否合法
                nErrCode = _IsValid(readerId);
                if (nErrCode != 0)
                    return nErrCode;

                //讀取單個條碼
                nErrCode = Reader[readerId].MutiRead(ref recvData);
                if (nErrCode != 0)
                    return nErrCode;

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public static int Cmd(int readerId, string cmd, ref string recvData)
        {
            int nErrCode = -1;

            try
            {
                //確認readerId是否合法
                nErrCode = _IsValid(readerId);
                if (nErrCode != 0)
                    return nErrCode;

                //執行Cmd
                nErrCode = Reader[readerId].Cmd(cmd, ref recvData);
                if (nErrCode != 0)
                    return nErrCode;

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        private static int _IsValid(int readerId)
        {
            int nErrCode = -1;

            //檢查是否已經初始化
            if (_IsInitial == false)
                return nErrCode;

            //檢查條碼機ID是否合法
            if (readerId < 0 || readerId > Reader.Length - 1)
                return nErrCode;

            return 0;   //表示合法
        }
    }
    public class CognexReaderUnit
    {
        public CognexReaderUnit(string ip)
        {
            this._IP = ip;
        }

        //=====Parameter=====
        private DataManSystem _Reader;          //Cognex條碼機控制物件
        private string _IP = "192.168.100.1";   //連線資訊
        private bool _RecvedFlag = false;       //條碼接收旗標
        private string _RecvedData;             //條碼接收到的內容
        private int _ReadTimeout = 2000;        //讀取條碼的逾時時間，單位ms

        //=====Property======
        public bool IsConnect { get; set; }  //連線狀態

        //=====Event======
        private void _Reader_SystemDisconnected(object sender, EventArgs args)
        {
            IsConnect = false;
        }
        private void _Reader_SystemConnected(object sender, EventArgs args)
        {
            IsConnect = true;
        }
        private void _Reader_ReadStringArrived(object sender, ReadStringArrivedEventArgs args)
        {
            _RecvedData = args.ReadString;
            _RecvedFlag = true;
            //Console.WriteLine(args.ReadString);
        }

        //=====Method========
        public int Open()
        {
            int nErrCode = -1;

            try
            {
                if (_Reader != null && IsConnect)
                {
                    _Reader.SystemConnected -= _Reader_SystemConnected;       //條碼機建立連線事件
                    _Reader.SystemDisconnected -= _Reader_SystemDisconnected; //條碼機斷線事件
                    _Reader.ReadStringArrived -= _Reader_ReadStringArrived;   //接收到資料的事件        
                    Close();
                }

                EthSystemConnector readerConn = new EthSystemConnector(System.Net.IPAddress.Parse("192.168.100.1"));
                _Reader = new DataManSystem(readerConn);
                _Reader.SystemConnected += _Reader_SystemConnected;         //條碼機建立連線事件
                _Reader.SystemDisconnected += _Reader_SystemDisconnected;   //條碼機斷線事件
                _Reader.ReadStringArrived += _Reader_ReadStringArrived;     //接收到資料的事件              
                _Reader.Connect(50);                                        //建立連線，逾時的時間單位不確定ms還是s
                _Reader.SetResultTypes(ResultTypes.ReadString);             //要設定這個_Reader_ReadStringArrived事件才會有作用
                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public int Close()
        {
            int nErrCode = -1;

            try
            {
                _Reader?.Disconnect();
                _Reader?.Dispose();

                return 0;
            }
            catch (Exception ex)
            {
                nErrCode = -1;
                //mylog.WriteEventLog(LogType.SYSTEM, EventType.ACTIVE, "BoatBarCode_On 例外 錯誤訊息:" + ex.Message);
                return nErrCode;
            }
        }
        public int SingleRead(ref string recvData)
        {
            int nErrCode = -1;
            string originData = "";

            try
            {
                nErrCode = _Trigger(ref originData);    //讀取完整的字串資料
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
        public int MutiRead(ref string[] recvData)
        {
            int nErrCode = -1;
            string originData = "";

            try
            {
                nErrCode = _Trigger(ref originData);    //讀取完整的字串資料
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
        public int Cmd(string cmd, ref string recvData)
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
        private int _Trigger(ref string recvData)
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

