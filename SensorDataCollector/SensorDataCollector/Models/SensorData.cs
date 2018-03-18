using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SensorDataCollector.Models
{
    /// <summary>
    /// 温湿度センサーからの情報
    /// </summary>
    public class SensorData
    {
        /// <summary>
        /// ユーザID
        /// </summary>
        [ForeignKey("ApiKey")]
        [Required]
        [DisplayName("ユーザID")]
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Index("SensorData", 1)]
        public string UserId { get; set; }


        /// <summary>
        /// APIのID
        /// </summary>
        [ForeignKey("ApiKey")]
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Index("SensorData", 2)]
        public int ApiKeyId { get; set; }

        /// <summary>
        /// API
        /// </summary>
        public virtual ApiKey ApiKey { get; set; }

        /// <summary>
        /// 計測日時
        /// </summary>
        [DisplayName("計測日時")]
        [Key]
        [Column(Order = 2)]
        [Index("SensorData", 3)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        [DisplayName("温度")]
        public double Temp { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        [DisplayName("湿度")]
        public double Humid { get; set; }
    }
}