using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTest.Models
{
    class LogData
    {
        public LogData(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

        public DateTime Date { get; set; }

        public double Temp { get; set; }

        public double Humid { get; set; }

        internal IEnumerable<KeyValuePair<string, string>> GetNameValueCollection()
        {
            var ret = new List<KeyValuePair<string, string>>();

            ret.Add(new KeyValuePair<string, string>("Key", Key));
            ret.Add(new KeyValuePair<string, string>("Date", Date.ToString()));
            ret.Add(new KeyValuePair<string, string>("Temp", Temp.ToString()));
            ret.Add(new KeyValuePair<string, string>("Humid", Humid.ToString()));

            return ret;
        }
    }
}
