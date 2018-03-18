using SensorTest.Util;
using System.Runtime.InteropServices;

namespace SensorTest.Repositories
{
    /// <summary>
    /// USBデバイスを使用するためのリポジトリ
    /// </summary>
    class UsbMeterRepository
    {
        /// <summary>
        /// USBデバイスのIndex
        /// </summary>
        private int _devIndex;

        /// <summary>
        /// USBデバイス名
        /// </summary>
        private string _devName;

        /// <summary>
        /// センサー情報
        /// </summary>
        public struct SensorData
        {
            /// <summary>
            /// 温度
            /// </summary>
            public double temp;

            /// <summary>
            /// 湿度
            /// </summary>
            public double humid;
        }

        /// <summary>
        /// USBデバイスを取得し、使用準備をする
        /// </summary>
        public UsbMeterRepository()
        {
            System.IntPtr intPtr = UsbMeterUtil.FindUSB(out _devIndex);
            _devName = Marshal.PtrToStringAnsi(intPtr);
            
        }

        /// <summary>
        /// センサーから現在の情報を取得する
        /// </summary>
        /// <returns></returns>
        public SensorData GetSensorData()
        {
            SensorData data;
            UsbMeterUtil.GetTempHumid(_devName, out data.temp, out data.humid);
            return data;
        }
    }
}
