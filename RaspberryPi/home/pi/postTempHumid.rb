require 'net/https'
require 'date'

# USB温湿度センサーから温湿度情報を取得
temp_humid = `/usr/local/bin/usbrh`.split(" ")

# 温湿度情報をPOST
uri = URI.parse("https://edasensordatacollector.azurewebsites.net/api/SensorDatas/")
http = Net::HTTP.new(uri.host, uri.port)

http.use_ssl = true
http.verify_mode = OpenSSL::SSL::VERIFY_NONE

req = Net::HTTP::Post.new(uri.path)
req.set_form_data({
  'Date' => Time.now.strftime("%Y/%m/%d %H:%M:%S"),
  'Key' => 'MDR3fTbtgjEMjvR0KUGfRbNgGxU5vuiJ',
  'Temp' => temp_humid[0],
  'Humid' => temp_humid[1]
  })

res = http.request(req)
#puts res

