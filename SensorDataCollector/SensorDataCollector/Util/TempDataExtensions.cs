using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SensorDataCollector.Util
{
    public static class TempDataExtensions
    {
        /// <summary>
        /// 通知メッセージを設定します。
        /// </summary>
        /// <param name="tempData">一時データ</param>
        /// <param name="message">通知メッセージ</param>
        public static void Notice(this TempDataDictionary tempData, string message)
        {
            tempData["notice"] = message;
        }

        /// <summary>
        /// 通知メッセージを取得します。
        /// </summary>
        /// <param name="tempData">一時データ</param>
        /// <returns>通知メッセージ</returns>
        public static string Notice(this TempDataDictionary tempData)
        {
            return tempData["notice"] as string;
        }

        /// <summary>
        /// アラートメッセージを設定します。
        /// </summary>
        /// <param name="tempData">一時データ</param>
        /// <param name="message">アラートメッセージ</param>
        public static void Alert(this TempDataDictionary tempData, string message)
        {
            tempData["alert"] = message;
        }

        /// <summary>
        /// アラートメッセージを取得します。
        /// </summary>
        /// <param name="tempData">一時データ</param>
        /// <returns>アラートメッセージ</returns>
        public static string Alert(this TempDataDictionary tempData)
        {
            return tempData["alert"] as string;
        }
    }
}