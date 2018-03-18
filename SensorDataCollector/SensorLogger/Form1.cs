using SensorTest.Models;
using SensorTest.Repositories;
using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace SensorTest
{
    public partial class Form1 : Form
    {

        private const int INTERVAL = 60000;

        UsbMeterRepository meterRepository;
        DataLoggingRepository loggingRepository;

        /// <summary>
        /// 収集アプリに登録したAPIキー
        /// </summary>
        private string ApiKey { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ApiKey = ConfigurationManager.AppSettings["ApiKey"];
                var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
                txtApiBaseUrl.Text = baseUrl;
                meterRepository = new UsbMeterRepository();
                loggingRepository = new DataLoggingRepository(baseUrl);

                timer1.Interval = INTERVAL;
            }
            catch (Exception ex)
            {
                label1.Text = ex.ToString();
            }
        }

        /// <summary>
        /// 収集タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            // センサー情報を取得
            var data = meterRepository.GetSensorData();

            // 温湿度を画面に表示
            lblTemp.Text = string.Format("{0:0.0}", data.temp);
            pbTemp.Value = (int)data.temp;

            lblHumid.Text = string.Format("{0:0.0}", data.humid);
            pbHumid.Value = (int)data.humid;

            // 温湿度を収集アプリに登録
            var result = await loggingRepository.AddEntity(new LogData(ApiKey)
            {
                Date = DateTime.Now,
                Temp = data.temp,
                Humid = data.humid
            });

            // 収集状況表示
            if (result)
            {
                txtStatus.Text = "正常";
                txtStatus.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                txtStatus.Text = "異常";
                txtStatus.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}
