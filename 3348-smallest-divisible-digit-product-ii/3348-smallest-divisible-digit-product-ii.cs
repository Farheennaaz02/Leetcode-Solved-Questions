using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public string SmallestNumber(string num, long t)
    {
        var primeResult = GetPrimeCount(t);

        Dictionary<int, int> primeCount = primeResult.Item1;

        if (!primeResult.Item2)
            return "-1";


        var minFactors = GetFactorCount(primeCount);


        if (SumValues(minFactors) > num.Length)
            return Construct(minFactors);



        Dictionary<int, int> current = GetPrimeCount(num);

        int firstZero = num.IndexOf('0');


        // already valid
        if (firstZero == -1)
        {
            firstZero = num.Length;

            if (IsSubset(primeCount, current))
                return num;
        }



        // Try increasing from right side
        for (int i = num.Length - 1; i >= 0; i--)
        {
            int digit = num[i] - '0';


            RemoveFactors(digit, current);


            int remainingSpace = num.Length - i - 1;


            if (i > firstZero)
                continue;



            for (int bigger = digit + 1; bigger <= 9; bigger++)
            {
                var remaining =
                    Subtract(
                        primeCount,
                        current
                    );


                RemoveFactors(bigger, remaining);


                var factors =
                    GetFactorCount(remaining);



                if (SumValues(factors) <= remainingSpace)
                {
                    int ones =
                        remainingSpace - SumValues(factors);


                    return num.Substring(0, i)
                        + bigger
                        + new string('1', ones)
                        + Construct(factors);
                }
            }
        }



        // Increase length
        var extend =
            GetFactorCount(primeCount);


        return new string(
                '1',
                num.Length + 1 - SumValues(extend)
            )
            + Construct(extend);
    }





    private Tuple<Dictionary<int,int>,bool> GetPrimeCount(long t)
    {
        var count = new Dictionary<int,int>()
        {
            {2,0},
            {3,0},
            {5,0},
            {7,0}
        };


        foreach(int p in new int[]{2,3,5,7})
        {
            while(t % p == 0)
            {
                count[p]++;
                t/=p;
            }
        }


        return Tuple.Create(count,t==1);
    }





    private Dictionary<int,int> GetPrimeCount(string num)
    {
        var count = new Dictionary<int,int>()
        {
            {2,0},
            {3,0},
            {5,0},
            {7,0}
        };


        foreach(char c in num)
        {
            AddDigitFactors(
                c-'0',
                count
            );
        }


        return count;
    }





    private void AddDigitFactors(
        int d,
        Dictionary<int,int> count)
    {
        if(d==2)
            count[2]++;

        else if(d==3)
            count[3]++;

        else if(d==4)
            count[2]+=2;

        else if(d==5)
            count[5]++;

        else if(d==6)
        {
            count[2]++;
            count[3]++;
        }

        else if(d==7)
            count[7]++;

        else if(d==8)
            count[2]+=3;

        else if(d==9)
            count[3]+=2;
    }





    private void RemoveFactors(
        int d,
        Dictionary<int,int> count)
    {
        if(d==2)
            count[2]=Math.Max(0,count[2]-1);

        else if(d==3)
            count[3]=Math.Max(0,count[3]-1);

        else if(d==4)
            count[2]=Math.Max(0,count[2]-2);

        else if(d==5)
            count[5]=Math.Max(0,count[5]-1);

        else if(d==6)
        {
            count[2]=Math.Max(0,count[2]-1);
            count[3]=Math.Max(0,count[3]-1);
        }

        else if(d==7)
            count[7]=Math.Max(0,count[7]-1);

        else if(d==8)
            count[2]=Math.Max(0,count[2]-3);

        else if(d==9)
            count[3]=Math.Max(0,count[3]-2);
    }





    private Dictionary<int,int> GetFactorCount(
        Dictionary<int,int> c)
    {
        int two = c[2];
        int three = c[3];


        int eight = two/3;
        two%=3;


        int nine = three/2;
        three%=2;


        int four = two/2;
        two%=2;


        int six = 0;


        if(two==1 && three==1)
        {
            two=0;
            three=0;
            six=1;
        }


        if(three==1 && four==1)
        {
            two=1;
            six=1;
            three=0;
            four=0;
        }



        return new Dictionary<int,int>()
        {
            {2,two},
            {3,three},
            {4,four},
            {5,c[5]},
            {6,six},
            {7,c[7]},
            {8,eight},
            {9,nine}
        };
    }





    private string Construct(
        Dictionary<int,int> factors)
    {
        StringBuilder sb=new StringBuilder();


        for(int d=2;d<=9;d++)
        {
            int cnt=Math.Max(0,factors[d]);


            sb.Append(
                new string(
                    (char)('0'+d),
                    cnt
                )
            );
        }


        return sb.ToString();
    }





    private Dictionary<int,int> Subtract(
        Dictionary<int,int> a,
        Dictionary<int,int> b)
    {
        var res=new Dictionary<int,int>(a);


        foreach(var x in b)
        {
            res[x.Key]=Math.Max(
                0,
                res[x.Key]-x.Value
            );
        }


        return res;
    }





    private bool IsSubset(
        Dictionary<int,int> a,
        Dictionary<int,int> b)
    {
        foreach(var x in a)
        {
            if(b[x.Key] < x.Value)
                return false;
        }

        return true;
    }





    private int SumValues(
        Dictionary<int,int> map)
    {
        int sum=0;

        foreach(var x in map.Values)
            sum+=x;

        return sum;
    }
}