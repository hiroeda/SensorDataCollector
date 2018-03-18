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
    /// APIキー(測定単位)
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// ユーザID
        /// </summary>
        [Required]
        [DisplayName("ユーザID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 0)]
        [Index("ApiKey", 1)]
        public string UserId { get; set; }

        /// <summary>
        /// ユーザ
        /// </summary>
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// APIのID
        /// </summary>
        [DisplayName("API ID")]
        [Key, Column(Order = 1)]
        [Index("ApiKey", 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApiId { get; set; }

        /// <summary>
        /// 測定対象名
        /// </summary>
        [DisplayName("測定対象名")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 発行したキーのSHA256ハッシュ値
        /// </summary>
        [MaxLength(256)]
        [Index("ApiHash")]
        public byte[] KeyHash { get; set; }
    }
}