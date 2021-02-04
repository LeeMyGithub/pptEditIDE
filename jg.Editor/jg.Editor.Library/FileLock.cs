using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace jg.Editor.Library
{
    public class FileLock
    {
        private string _Key;
        /// <summary>
        /// 锁秘钥
        /// </summary>
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        /// <summary>
        /// 创建钥匙
        /// </summary>
        /// <param name="Garble">需要密码</param>
        /// <returns> 加密后的密码 </returns>
        public string CreateKey(string pwd)
        {

            Key = Getkey(pwd);
            return Key;
        }

        
        private string Getkey(string key)
        {

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] s = md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(key));
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Key = s;
            return Convert.ToBase64String(aes.Key);
        }
        /// <summary>
        /// 比较俩个值是否相同
        /// </summary>
        /// <param name="password">比较值</param>
        /// <param name="key">源值</param>
        /// <returns>是否是相同</returns>
        public bool Compare(string password, string key)
        {
            string pwd = CreateKey(password);
            if (key == pwd)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 比较俩个值是否相同
        /// </summary>
        /// <param name="password">比较值</param>
        /// <returns>是否是相同</returns>
        public bool Compare(string password)
        {
            string pwd = Getkey(password);
            if (_Key == pwd)
            {
                return true;
            }
            return false;
        }

    }
}
