public class Solution {
    public int LargestRectangleArea(int[] heights) {
        Stack <int> stack = new ();
        int maxarea =0;

        int  n = heights.Length ;
        for ( int  i=0;i<=n;i++){
            int currentheight = i==n ?0:heights[i];
            while ( stack.Count >0&& heights[stack.Peek ()]>currentheight){
                int height = heights[stack.Pop()];
                int width = stack.Count==0?i:i-stack.Peek()-1;
                maxarea = Math.Max (maxarea , height* width );
            }
            stack.Push (i);

        }
        return maxarea ;
        
    }
}