using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _03HW1Controller : Controller
    {
        //第一題,判斷質數
        public string No1(int n)
        {
            if (n == 0 || n == 1)
                return n + "不是質數";

            for (int i = 2; i < n; i++)  //這裡的i值,會由2跑到n-1
            {
                if (n % i == 0)
                    return n + "不是質數";
            }

            return n + "是質數";
            //寫一個程式判斷n是不是質數
            // if (n == 0 || n == 1)
            //     return n + "非質數";

            // for(int i = 2; i < n; i++)
            // {
            //     if (n % i == 0)

            //         return n + "非質數";



            // }
            //return n+ "是質數";
            //做法參考
            //用迴圈,對n進行除法運算,看看他能不能被除了1或n以外的某個數整除
            //若可以,則n就不是質數
        }

        //第二題,找任意兩數之最大公因數
        public string No2(int n, int m)
        {
            //寫一個程式找出n與m的最大公因數

            //做法參考
            //不能使用短除法,要使用輾轉相除法
            //除到餘數為零時,當次的除數即為兩數的最大公因數

            int M = m, N = n;  //永遠把M當被除數,永遠把N當除數
            int z = 0; //這個變數來放餘數

            while (M % N != 0)
            {
                z = M % N;
                M = N;  //除數變被除數
                N = z;  //餘數變除數
                
            }
            
            return  m + "與" + n + "的最大公因數為" + N;

        }




        

       
        //第三題,迴文判斷

        public void No3(int n)
        {
            //n=12321
            //n=12333321
            //寫一個程式判斷n是不是迴文
            int N = n, result = 0;
            int q, r = 0;

            do
            {
                r = N % 10; //餘數,數得N的個位數
                q = N / 10; //商數,數得N的個位數以外的數字
                N = q; //把商數變成下一次的被除數
                result = result * 10 + r;  //把數字倒過來排的結果
            } while (q != 0);

            if (n == result)
            {
                Response.Write(n + "是迴文");
            }
            else
            {
                Response.Write(n + "不是迴文");
            }
        }


        //做法參考
        //將n倒過來排列,再與原來的n比較,若相等即是迴文




        //第四題,發牌程式
        public void No4()
        {

            //for(int i = 1; i <= 52; i++)
            //{
            //    Response.Write("<img src='../poker_img/"+i+".gif' />");
            //}
            string[] poker = new string[52];
            for (int i = 1; i <= poker.Length; i++)
            {
                poker[i - 1] = i.ToString();
            }
            int t = 0;
            string tmp = "";
            Random r = new Random();
            for (int i = 0; i < poker.Length; i++)
            {
                t = r.Next(0, 52);
                tmp = poker[i];
                poker[i] = poker[t];
                poker[t] = tmp;
            }
            //發牌
            string p1 = "", p2 = "", p3 = "", p4 = "";
            for (int i = 0; i < poker.Length; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        p1 += "<img src='../poker_img/" + poker[i] + ".gif' />";
                        break;
                    case 1:
                        p2 += "<img src='../poker_img/" + poker[i] + ".gif' />";
                        break;
                    case 2:
                        p3 += "<img src='../poker_img/" + poker[i] + ".gif' />";
                        break;
                    case 3:
                        p4 += "<img src='../poker_img/" + poker[i] + ".gif' />";
                        break;
                }
            }
            Response.Write("玩家1:" + p1 + "<br>玩家2:" + p2 + "<br>玩家3:" + p3 + "<br>玩家4:" + p4);
            //鑄造亂數物件
            //Random r = new Random();
            //Response.Write(r.Next(1,100));

            //1.用迴圈依序將牌擺入陣列中
            //2.用迴圈及亂數將陣列中的牌順序打亂(洗牌)
            //3.用迴圈依序讀出陣列中的牌,分成四份,並顯示於網頁上(發牌)
           
        }

        public void No5(int n)

        {
            int N = n ,result=0;
            int q, r = 0;
            
            r = N % 10; //餘數,數得N的個位數
            q = N / 10; //商數,數得N的個位數以外的數字
            N = q;
            result = result * 10 + r;
            Response.Write(N);
        }

        public static void Main(string[] args)
        {
            int n, r, sum = 0, temp;
            Console.Write("Enter the Number: ");
            n = int.Parse(Console.ReadLine());
            temp = n;
            while (n > 0)
            {
                r = n % 10;
                sum = (sum * 10) + r;
                n = n / 10;
            }
            if (temp == sum)
                Console.Write("Number is Palindrome.");
            else
                Console.Write("Number is not Palindrome");
        }
        
    }
}