public class Solution {
    public int MaxArea(int[] height) {
        int left =0;
        int ans = 0;
        int right = height.Length -1;
        while (left <right){
            int width = right -left ;
            int h = Math.Min(height[left],height[right]);
            int area = h* width;
            if ( area > ans ){
                ans =  area ;
            }
            if (height[left]<height[right]){
                left++;
            }
            else{
                right--;
            }

        }
        return ans ;
        
    }
}