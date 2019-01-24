using BaiduCang;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TimerService.Service;

namespace TimerService
{
    public class Myjob1 : IJob
    {

      

     
      
        void IJob.Execute()
        {
            try
            {
                for (int i = 0; i < Program.ListUser.Count; i++)
                {
                    SignClass.GetQianDao(Program.ListUser[i].UserName.Trim(), Program.ListUser[i].UserPwd.Trim());
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务异常-----------------------------------");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
