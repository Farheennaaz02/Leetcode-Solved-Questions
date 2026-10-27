class Solution {
    public int maxArea(int[] height) {
        int n = height.length;
        int left = 0;
        int right = n-1;
        int maxarea = Integer.MIN_VALUE;
        while (left <right ){
            int w = right - left ;
            int h= Math.min (height[left],height[right]);
            int area = w*h;
            if ( area> maxarea){
                maxarea= area;
            }
            if (height[left]>height[right]){
                right --;
            }
            else{
                left ++;
            }
        }
        return maxarea;

        
    }
}