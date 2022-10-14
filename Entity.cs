using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spider
{

    public class Entity
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data")]
        public Data Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// 查询成功
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 2022-09-03 13时
        /// </summary>
        [JsonPropertyName("end_update_time")]
        public string EndUpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("hcount")]
        public int Hcount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("mcount")]
        public int Mcount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lcount")]
        public int Lcount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("highlist")]
        public List<ListItem> Highlist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lowlist")]
        public List<ListItem> Lowlist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("middlelist")]
        public List<ListItem> MiddleList { get; set; }
    }

    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 北京市
        /// </summary>
        [JsonPropertyName("province")]
        public string Province { get; set; }

        /// <summary>
        /// 朝阳区
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// 高碑店（地区）乡
        /// </summary>
        [JsonPropertyName("county")]
        public string County { get; set; }

        /// <summary>
        /// 北京市 朝阳区 高碑店（地区）乡
        /// </summary>
        [JsonPropertyName("area_name")]
        public string AreaName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("communitys")]
        public List<string> Communitys { get; set; }
    }


}
