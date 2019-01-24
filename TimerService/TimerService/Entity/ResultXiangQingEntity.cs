using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerService
{
  public   class ResultXiangQingEntity
    {  /// <summary>
       /// 
       /// </summary>
        public double collectInterest { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public double availableAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }

 

        /// <summary>
        /// 接口调用成功
        /// </summary>
        public string resultdesc { get; set; }

        /// <summary>
        /// 总资产
        /// </summary>
        public double amount { get; set; }



  

   

        /// <summary>
        /// 累计到账收益
        /// </summary>
        public double alreadyInterest { get; set; }

  

        /// <summary>
        /// 积分数量
        /// </summary>
        public float userjfAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double alreadyWithdrawalAmount { get; set; }


     
    }
}
