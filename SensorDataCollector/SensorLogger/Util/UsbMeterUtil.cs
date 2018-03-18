using System;
using System.Runtime.InteropServices;
using System.Security;

namespace SensorTest.Util
{
    /// <summary>
    /// USBMeter.dllを使用するためのラッパークラス
    /// </summary>
    static class UsbMeterUtil
    {
        /// <summary>
        /// DLLのバージョンを文字列として取得
        /// </summary>
        /// <param name="dev">デバイス名</param>
        /// <returns>バージョン番号</returns>
        [DllImport("USBMeter.dll", EntryPoint = "_GetVers@4"), SuppressUnmanagedCodeSecurity]
        public extern static string GetVersion(string dev);

        /// <summary>
        /// センサーのデバイス名を取得
        /// </summary>
        /// <param name="index">デバイスの検索順。変更禁止(読み取り専用として使用)</param>
        /// <returns>デバイス名</returns>
        /// <remarks>デバイス使用時に最初に実行する</remarks>
        [DllImport("USBMeter.dll", EntryPoint = "_FindUSB@4"), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr FindUSB(out int index);

        /// <summary>
        /// 温度と湿度を取得。高温域と低温域が不正確。
        /// </summary>
        /// <param name="dev">デバイス名</param>
        /// <param name="temp">温度</param>
        /// <param name="humid">湿度</param>
        /// <returns>0:成功 / -1:失敗</returns>
        [DllImport("USBMeter.dll", EntryPoint = "_GetTempHumid@12"), SuppressUnmanagedCodeSecurity]
        public extern static int GetTempHumid(string dev, out double temp, out double humid);

        /// <summary>
        /// 温度と湿度を取得。高温域と低温域も正確（新DLLで追加された機能）。
        /// </summary>
        /// <param name="dev">デバイス名</param>
        /// <param name="temp">温度</param>
        /// <param name="humid">湿度</param>
        /// <returns>0:成功 / -1:失敗</returns>
        [DllImport("USBMeter.dll", EntryPoint = "_GetTempHumidTrue@12"), SuppressUnmanagedCodeSecurity]
        public extern static int GetTempHumidTrue(string dev, out double temp, out double humid);

        /// <summary>
        /// LEDの点灯設定。
        /// </summary>
        /// <param name="dev">デバイス名</param>
        /// <param name="port">LED番号(0/1)</param>
        /// <param name="state">LED状態(0:消灯[デフォルト]/1:点灯)</param>
        /// <returns>0:成功 / -1:失敗</returns>
        [DllImport("USBMeter.dll", EntryPoint = "_ControlIO@12"), SuppressUnmanagedCodeSecurity]
        public extern static int SetLedState(string dev, int port, int state);

        /// <summary>
        /// 診断用ヒーターのオンオフ。
        /// </summary>
        /// <param name="dev">デバイス名</param>
        /// <param name="val">ヒーター状態(0:オフ[デフォルト] / 1:オン)</param>
        /// <returns>0:成功 / -1:失敗</returns>
        [DllImport("USBMeter.dll", EntryPoint = "_SetHeater@8"), SuppressUnmanagedCodeSecurity]
        public extern static int SetHeater(string dev, int val);
    }
}
