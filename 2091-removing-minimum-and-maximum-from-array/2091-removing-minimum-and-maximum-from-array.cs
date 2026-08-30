public class Solution {
    public int MinimumDeletions(int[] nums) {
        // konsa index per aarhe h dono back se and frint sse yeh ddekho 
        int n = nums.Length;
        if ( n==1){
            return 1;
        }
        int min = int.MaxValue;
        int max = int.MinValue;
        int minindex =0;
        int maxindex=0;
        int sum =1;
        // we got the min index and max index 
        for ( int i =0;i<n;i++){
            if (nums[i]> max){
                max = nums[i];
                maxindex = i;
            }
            if ( nums [i]<min){
                min= nums[i];
                minindex=i;
            }
        }
        //nums = [2,10,7,5,4,1,8,6]
        //           S       F
        int second =  Math.Max( maxindex , minindex );
        int first = Math.Min ( maxindex , minindex );
        int front = second+1;
        int back = n-first ;
        int mix = (first+1)+(n-second);
        return Math.Min ( front , Math.Min ( back , mix));


        

       
    }
}