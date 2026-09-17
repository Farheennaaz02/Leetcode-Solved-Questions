class Solution {
    public int minSumOfLengths(int[] arr, int target) {
        int n= arr.length ;
        int [] dp = new int[n+1];
        int inf= 1000000;
        for ( int i =0;i<=n;i++){
            dp[i]=inf;
        }
        int left =0;
        int sum = 0;
        int ans = inf ;
        for ( int right = 0;right <n;right++){
            sum+=arr[right];
            while (sum >target ){
                sum-=arr[left];
                left++;
            }
            dp[right+1]= dp[right];
            if (sum == target ){
                int len = right-left+1;
                if (dp[left]!=inf){
                    ans = Math.min (ans , len+dp[left]);
                }
                dp[right+1]=Math.min (dp[right+1], len);
            }
        }
        return ans==inf?-1:ans;
    
        
    }
}