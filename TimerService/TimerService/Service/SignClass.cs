using BaiduCang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TimerService.Entity;

namespace TimerService.Service
{
    public class SignClass
    {
        public static LoginEntity GetLoginModel(string zhanghao,string mima)
        {
            string pass = CaozuoClass.GetMD5(mima.Trim());
            string aa = "huaxiawanjia_" + CaozuoClass.ConvertDateTimeToInt(DateTime.Now) + "_e6416ce85cf0e";
            string url = "https://weixin.wanjiajinfu.com/webAPI/uc/api";
            Encoding encoding = Encoding.GetEncoding("utf-8");
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("service_name", "god.login");
            parameters.Add("phone", zhanghao.Trim());
            parameters.Add("loginKey", pass);
            parameters.Add("fraudTokenId", aa);
            string json = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters, null, null, encoding, null);
            var model = new JavaScriptSerializer().Deserialize<LoginEntity>(json);
            return model;
        }

        public static ResultXiangQingEntity GetXiangQing(string tokenID,int id)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("service_name", "mbm_mbminfo_req");
            parameters.Add("godId", id.ToString());
            parameters.Add("tokenId", tokenID);
            var json = new CaozuoClass().getGetHttpResult("https://weixin.wanjiajinfu.com/webAPI/api", parameters);
            var model = new JavaScriptSerializer().Deserialize<ResultXiangQingEntity>(json);
            return model;
        }

        /// <summary>
        /// 账号密码
        /// </summary>
        /// <param name="zhanghao"></param>
        /// <param name="mima"></param>
        public static  void GetQianDao(string zhanghao,string mima)
        {
            LoginEntity loginModel = GetLoginModel(zhanghao,mima);
            if (loginModel == null)
            {
                Console.WriteLine(zhanghao+"   登录接口授权异常" + "   " + DateTime.Now);
                return;
            }

            if (loginModel.result != "000000")
            {
                Console.WriteLine(zhanghao + "   登录接口授权异常" + "   " + DateTime.Now + "   " + loginModel.resultdesc);
                return;
            }
            #region 签到
            CaozuoClass post = new CaozuoClass();
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("service_name", "mbm_signdetail_req");
            parameters.Add("godId", loginModel.god.id.ToString());
            parameters.Add("tokenId", loginModel.tokenId);
            var json = post.getPostHttpResult("https://weixin.wanjiajinfu.com/webAPI/api", parameters);
            var model = new JavaScriptSerializer().Deserialize<ResultEntity>(json);
            var xiangqingModel = GetXiangQing(loginModel.tokenId,Convert.ToInt32( loginModel.god.id));
            if (model == null)
            {
                Console.WriteLine(zhanghao + "   签到接口异常，无返回数据");
                return;
            }
            else if (model.result == "000000")
            {
                Console.WriteLine(zhanghao + "   签到成功：" + DateTime.Now + "      " + model.msg + "   " + "此账号一共有" + (xiangqingModel == null ? 0 : xiangqingModel.userjfAmount) + "积分");
            }
            else
            {
                Console.WriteLine(zhanghao + "   签到  " + DateTime.Now + "   " + model.msg + "    " + model.resultdesc);
            }
            #endregion

            #region 转盘
            string pass = CaozuoClass.GetMD5(mima.Trim());
            string aa = "huaxiawanjia_" + CaozuoClass.ConvertDateTimeToInt(DateTime.Now) + "_e6416ce85cf0e";
            string url = "https://weixin.wanjiajinfu.com/webAPI/uc/api";
            Encoding encoding = Encoding.GetEncoding("utf-8");
            IDictionary<string, string> parameters1= new Dictionary<string, string>();
            parameters1.Add("service_name", "lottery.roll");
            parameters1.Add("godId", "703958");
            parameters1.Add("tokenId", loginModel.tokenId);
            parameters1.Add("aId", "1");
            string json1 = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters1, null, null, encoding, null);
            var chouJiangEntity = new JavaScriptSerializer().Deserialize<ChouJiangEntity>(json1);
            if (chouJiangEntity == null)
            {
                Console.WriteLine(zhanghao + "   抽奖接口异常，无返回数据");
                return;
            }
            else if (chouJiangEntity.result == "000000")
            {
                Console.WriteLine(zhanghao + "   抽奖成功：" + DateTime.Now + "      " + chouJiangEntity.data.name + "   "+chouJiangEntity.data.value+"       " + chouJiangEntity.resultdesc);
            }
            else
            {
                Console.WriteLine(zhanghao + "   抽奖  " + DateTime.Now + "   "  + chouJiangEntity.resultdesc);
            }
            #endregion
        }

      
      
     
    }
}
