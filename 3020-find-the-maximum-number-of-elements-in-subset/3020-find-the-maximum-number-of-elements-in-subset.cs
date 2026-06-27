public class Solution {
    public int MaximumLength(int[] nums) {
        Dictionary <long , int > freq = new ();
        foreach ( int num in nums ){
            if( freq.ContainsKey(num)){
                freq[num]++;
            }
            else {
                freq[num]=1;
            }
        }
        int answer =1;
        foreach ( long start in new List <long > (freq.Keys)){
            long x = start ;
            int count =0;
            while ( freq.ContainsKey(x)&& freq[x]>0){
                if ( x==1){
                count += freq[x];
                break ;

                }
                if ( freq[x]>=2){
                count +=2;
                
                }
                else {
                count +=1;
                break ;
                }
                 if ( x > 1000000){
                break ;
                 }
                 x = x*x;
            }
            
            if ( count%2==0){
                count --;
            }
            answer = Math.Max( answer , count );
        }
        return answer ;
    }
}