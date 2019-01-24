using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerService
{
    public class ResultEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float userscore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float signnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ok { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float signscore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string service_name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string signdate { get; set; }

        /// <summary>
        /// 接口调用成功
        /// </summary>
        public string resultdesc { get; set; }

        /// <summary>
        /// 今天已签到
        /// </summary>
        public string msg { get; set; }
    }
}
