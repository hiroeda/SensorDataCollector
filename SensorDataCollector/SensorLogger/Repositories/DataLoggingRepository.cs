using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using SensorTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SensorTest.Repositories
{
    /// <summary>
    /// Azure Table Storageに温湿度データをロギングするリポジトリ
    /// </summary>
    class DataLoggingRepository
    {
        /// <summary>
        /// 保存先テーブル名
        /// </summary>
        private const string TABLE_NAME = "templog";

        /// <summary>
        /// APIの配置先ドメイン名
        /// </summary>
        private string baseUrl;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataLoggingRepository(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// データ追加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true: 成功、false:失敗</returns>
        public async Task<bool> AddEntity(LogData entity)
        {
            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(entity.GetNameValueCollection());
            var response = await httpClient.PostAsync(Path.Combine(baseUrl, "api/SensorDatas/"), content);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
