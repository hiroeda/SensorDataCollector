using Microsoft.AspNet.Identity;
using SensorDataCollector.Models;
using SensorDataCollector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensorDataCollector.Controllers
{
    /// <summary>
    /// センサー情報収集API
    /// </summary>
    public class SensorDatasController : ApiController
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        protected ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// DB解放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// センサー情報の受信
        /// </summary>
        /// <param name="data">APIキーとセンサー情報</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]SensorDataViewModel data)
        {
            // データの妥当性チェック
            var service = new SensorDataService(db);
            var sensorData = service.Create(data);
            if (sensorData == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            // データの追加
            service.Add(sensorData);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
