class Solution {
    public List<List<Integer>> subsets(int[] nums) {
        List<List<Integer>> ans = new ArrayList<>();
        solve (nums,  0 , new ArrayList <>() , ans );
        return ans;
        
    }
    void solve (int []nums,int index , List<Integer> current  ,List<List<Integer>> ans){
        ans.add(new ArrayList<>(current));
        for ( int i =index ;i<nums.length;i++){
            current.add(nums[i]);
            solve (nums , i+1,current, ans );
            current.remove (current.size()-1);

        }
    }
}