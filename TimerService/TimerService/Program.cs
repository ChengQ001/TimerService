using BaiduCang;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TimerService.Entity;
using TimerService.Service;

namespace TimerService
{
    class Program
    {
        public static List<UserModel> ListUser;
        static void Main(string[] args)
        {
            ListUser = new List<UserModel>();
            cc: Console.WriteLine("请输入万家账号密码逗号隔开（如：17620330155,123456#17620330155,123456）：");
            string UserName = Console.ReadLine() + "#";
            UserName += "15827162014,cheng1993#18124081752,cheng1993#17620330155,cheng1993#18379233133,lin123123";
            string[] arrStr = UserName.Split('#');
            if (arrStr.Length <= 0)
            {
                Console.WriteLine("参数填写错误");
                goto cc;
            }

            foreach (var item in arrStr)
            {
                var arrStrItem = item.Split(',');
                if (arrStrItem.Length != 2)
                {
                    continue;
                }
                LoginEntity resultModel = SignClass.GetLoginModel(arrStrItem[0], arrStrItem[1]);
                if (resultModel == null)
                {
                    continue;
                }
                if (resultModel.result != "000000")
                {
                    continue;
                }
                ListUser.Add(new UserModel() { UserName = arrStrItem[0], UserPwd = arrStrItem[1], UserFullName = resultModel.god.fullName });
            }

            if (ListUser.Count <= 0)
            {
                Console.WriteLine("账号密码 都没有添加成功");
                goto cc;
            }
            var tishiStr = "";
            foreach (var item in ListUser)
            {
                tishiStr += item.UserName + ",";
            }
            Console.WriteLine("添加成功的账号为：" + tishiStr);
            Console.WriteLine("是否启动服务：1是 2否");
            if (Console.ReadLine() == "1")
            {
                Console.Clear();
                Console.WriteLine("服务启动成功,账号为：" + tishiStr);
                //先执行在启动
                for (int i = 0; i < Program.ListUser.Count; i++)
                {
                    SignClass.GetQianDao(Program.ListUser[i].UserName.Trim(), Program.ListUser[i].UserPwd.Trim());
                }

                JobManager.Initialize(new Task());

            }
            else
            {
                Environment.Exit(0);
            }


            Console.ReadKey();
        }
    }
}
