using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SensorDataCollector.Util
{
    public class CipherUtil
    {
        /// <summary>
        /// 乱数ジェネレータ
        /// </summary>
        private static System.Security.Cryptography.RNGCryptoServiceProvider rng = 
            new System.Security.Cryptography.RNGCryptoServiceProvider();

        private static readonly string CHARS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static char NextChar()
        {
            // Int32と同じサイズのバイト配列にランダムな値を設定する
            byte[] bs = new byte[4];
            rng.GetBytes(bs);

            // Int32に変換する
            int i = System.BitConverter.ToInt32(bs, 0);

            // 対応する文字に変換
            return CHARS.ElementAt(Math.Abs(i % CHARS.Length));
        }

        public static string CreateApiKey(int length)
        {
            var key = new StringBuilder();

            while (length-- > 0)
            {
                key.Append(NextChar());
            }
            return key.ToString();
        }

        // 文字列のハッシュ値（SHA256）を計算・取得する
        public static byte[] GetHash(string passwd)
        {
            // パスワードをUTF-8エンコードでバイト配列として取り出す
            byte[] byteValues = Encoding.UTF8.GetBytes(passwd);

            // SHA256のハッシュ値を計算する
            SHA256 crypto256 = new SHA256CryptoServiceProvider();
            return crypto256.ComputeHash(byteValues);
        }
    }
}