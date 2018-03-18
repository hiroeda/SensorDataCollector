using SensorDataCollector.Models;
using SensorDataCollector.Repositories;
using SensorDataCollector.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SensorDataCollector.Services
{
    /// <summary>
    /// センサー情報を扱うためのサービス
    /// </summary>
    public class SensorDataService
    {
        /// <summary>
        /// APIキーのアクセスキーの長さ(Web.configに書くべき)
        /// </summary>
        public const int KEY_LENGTH = 32;

        private IRepository<ApiKey> apiKeyRepository;

        private IRepository<SensorData> sensorDataRepository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="db"></param>
        public SensorDataService(DbContext db)
        {
            apiKeyRepository = new ApiKeyRepository(db);
            sensorDataRepository = new SensorDataRepository(db);
        }

        /// <summary>
        /// 指定のセンサーの情報を返す
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<SensorData> GetMyDatas(string userId, int ApiId, int takeNum = 60)
        {
            return sensorDataRepository.GetAll()
                .Where(k => k.UserId == userId)
                .Where(k => k.ApiKeyId == ApiId)
                .OrderByDescending(k => k.Date)
                .Take(takeNum);
        }

        /// <summary>
        /// 指定のAPIキー情報を返す
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ApiId"></param>
        /// <returns></returns>
        public SensorData GetOne(string userId, int ApiId)
        {
            return sensorDataRepository.GetOne(userId, ApiId);
        }

        /// <summary>
        /// キーに対応するAPIキーを探し、見つかったらセンサー情報を生成する。無い場合はnull。
        /// </summary>
        /// <param name="loginUserId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public SensorData Create(SensorDataViewModel data)
        {
            // キーに対応するAPIキーが存在するか確認する
            var keyHash = CipherUtil.GetHash(data.Key);
            var apiKey = apiKeyRepository.GetAll().SingleOrDefault(k => k.KeyHash.SequenceEqual(keyHash));
            if (apiKey == null)
            {
                // 不正なリクエスト
                return null;
            }

            // APIキーが存在したら、その内容を使用してセンサー情報を作成
            var sensorData = new SensorData()
            {
                UserId = apiKey.UserId,
                ApiKeyId = apiKey.ApiId,
                Date = data.Date,
                Temp = data.Temp,
                Humid = data.Humid
            };

            return sensorData;
        }

        /// <summary>
        /// センサー情報をDBに追加
        /// </summary>
        /// <param name="sensorData"></param>
        public void Add(SensorData sensorData)
        {
            sensorDataRepository.Add(sensorData);
        }
    }
}