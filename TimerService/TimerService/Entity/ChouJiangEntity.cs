using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerService.Entity
{
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public float id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string weight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float aId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isValid { get; set; }

    }
    public class ChouJiangEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string service_name { get; set; }

        /// <summary>
        /// 接口调用成功
        /// </summary>
        public string resultdesc { get; set; }
    }
}
