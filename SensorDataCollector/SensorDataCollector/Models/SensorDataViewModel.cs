using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorDataCollector.Models
{
    public class SensorDataViewModel
    {
        /// <summary>
        /// ハッシュ化前のキー
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 計測日時
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        public double Temp { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        public double Humid { get; set; }
    }
}