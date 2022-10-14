using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spider
{
    public class SpiderClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<T?> RunAsync<T>() where T : new()
        {
            client.DefaultRequestHeaders.Clear();

            //时间戳
            long timestamp = GenerateTimestamp();
            string url = "http://bmfw.www.gov.cn/bjww/interface/interfaceJson";
            //常量
            string appId = "NcApplication";
            string key = "3C502C97ABDA40D0A60FBEE50FAAD1DA";
            string nonceHeader = "123456789abcdefg";
            string passHeader = "zdww";
            string token = "23y0ufFl5YxIyGrI8hWRUZmKkvtSjLQA";
            string signatureKey = "fTN2pfuisxTavbTuYVSsNJHetwq5bJvCQkjjtiLM2dCratiA";
            string x_wif_paasid = "smt-application";
            string x_wif_nonce = "QkjjtiLM2dCratiA";


            //计算签名要用的字符串
            String signatureStr = String.Format("{0}{1}{2}", timestamp, signatureKey, timestamp);
            //计算签名
            String signature = GetSHA256String(signatureStr).ToUpper();

            //请求头
            client.DefaultRequestHeaders.Add("x-wif-nonce", x_wif_nonce);
            client.DefaultRequestHeaders.Add("x-wif-paasid", x_wif_paasid);
            client.DefaultRequestHeaders.Add("x-wif-signature", signature);
            client.DefaultRequestHeaders.Add("x-wif-timestamp", timestamp.ToString());

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("appId", appId);
            dic.Add("key", key);
            dic.Add("nonceHeader", nonceHeader);
            dic.Add("paasHeader", passHeader);
            signatureStr = String.Format("{0}{1}{2}{3}", timestamp, token, nonceHeader, timestamp);
            signature = GetSHA256String(signatureStr).ToUpper();
            dic.Add("signatureHeader", signature);
            dic.Add("timestampHeader", timestamp);
            try
            {

                JsonContent content = JsonContent.Create(dic);
                var response = await client.PostAsync(url, content);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<T>(responseContent);
                }
                else
                {
                    Console.WriteLine($"GetAsync End, url:{url}, HttpStatusCode:{response.StatusCode}, result:{responseContent}");
                    return new T();
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    string responseContent = await new StreamReader(ex.Response.GetResponseStream()).ReadToEndAsync();
                    throw new System.Exception($"response :{responseContent}", ex);
                }
                return new T();
            }
        }

        private static long GenerateTimestamp()
        {
            return new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        }

        public static string GetSHA256String(string str)
        {
            using SHA256 sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(str);
            var hash = sha256.ComputeHash(bytes);
            var builder = new StringBuilder();
            foreach (var t in hash)
            {
                builder.Append($"{t:X2}");
            }
            return builder.ToString();
        }


    }
}
