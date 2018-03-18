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
    /// APIキーを扱うためのサービス
    /// </summary>
    public class ApiKeyService
    {
        /// <summary>
        /// APIキーのアクセスキーの長さ
        /// </summary>
        public const int KEY_LENGTH = 32;

        private IRepository<ApiKey> apiKeyRepository;

        /// <summary>
        /// コンストラクタ。リポジトリの準備を行う。
        /// </summary>
        /// <param name="db"></param>
        public ApiKeyService(DbContext db)
        {
            apiKeyRepository = new ApiKeyRepository(db);
        }

        /// <summary>
        /// ログインユーザが使用可能なAPIキー情報の一覧を返す
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<ApiKey> GetMyKeys(string userId)
        {
            return apiKeyRepository.GetAll().Where(k => k.UserId == userId);
        }

        /// <summary>
        /// 指定のAPIキー情報を返す
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ApiId"></param>
        /// <returns></returns>
        public ApiKey GetOne(string userId, int ApiId)
        {
            return apiKeyRepository.GetOne(userId, ApiId);
        }

        /// <summary>
        /// APIキーのデータを作成する
        /// </summary>
        /// <param name="loginUserId"></param>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public ApiKey Create(string loginUserId, string name, string key)
        {
            var apiKey = new ApiKey()
            {
                UserId = loginUserId,
                Name = name,
                KeyHash = CipherUtil.GetHash(key)
            };

            return apiKey;
        }

        /// <summary>
        /// APIキーをDBに追加する
        /// </summary>
        /// <param name="apiKey"></param>
        public void Add(ApiKey apiKey)
        {
            apiKeyRepository.Add(apiKey);
        }
    }
}