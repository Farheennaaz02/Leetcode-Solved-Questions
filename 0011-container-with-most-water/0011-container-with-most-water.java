class Solution {
    public int maxArea(int[] height) {
        int left =0;
        int maxarea =Integer.MIN_VALUE;
        int right = height.length -1;
        while (left <right ){
            int w= right - left ;
            int h = Math.min (height[left], height[right]);
            int area = w*h;
            if (area > maxarea ){
                maxarea = area ;
            }
            if (height [left]>height [right]){
                right --;
            }
            else {
                left ++;
            }
        }
        return maxarea ;
    }
}