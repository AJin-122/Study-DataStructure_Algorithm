using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class Fib
    {
        public Fib()
        {
        }

        //하향식 동적 프로그래밍
        public int cal_re(int n)
        {
            if (n <= 2) return 1;

            return cal_re(n-1) + cal_re(n-2);
        }
        public ulong cal_Memoization(ulong n, Dictionary<ulong, ulong> memo)
        {
            if(memo.ContainsKey(n) == true) return memo[n];
            if(n <= 2) return 1;
            var res = cal_Memoization(n-1,memo) + cal_Memoization(n-2,memo);
            memo.Add(n, res);
            return res;
        }

        //상향식 호출 스택을 사용하지 않기 때문에 호출 스택 오류가 나지 않는다.
        public int cal_tabulated(int n)
        {
            if (n <= 2) return 1;
            var fibNums = new List<int>() { 0, 1, 1 };
            for(int i = 3; i <= n; i++)
            {
                fibNums.Add(fibNums[i - 1] + fibNums[i - 2]);
            }
            return fibNums[n];
        }
    }
}
