class Solution {
    public List<String> summaryRanges(int[] nums) {
        List<String > ans = new ArrayList <>();
       for ( int left =0;left <nums.length ;left++){
        int right = left ;
        while (right <nums.length-1 && nums[right]+1 ==  nums[right+1]){
            right ++;

        }
        if (left == right ){
            ans.add(String.valueOf(nums[left]));

        }
        else{
             ans.add(nums[left]+"->"+nums[right]);
        }
        left = right ;
       }
       return ans ;
        
    }
}