public class Solution {
    public long SumAndMultiply(int n) {
        long sum =0;
        long p=1;
        long x=0;
        while (n>0){
            int digit = n%10;
            sum +=digit;
            if (digit!=0){
                x+=digit*p;
                p*=10;
            }
            n/=10;
        }
        return x*sum;
    }
}