/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    int ans =0;
    public int AverageOfSubtree(TreeNode root) {
        DFS( root );
        return ans ;        
    }
    ( int sum  , int count ) DFS ( TreeNode node){// return type ( int ,int)
        if ( node == null){
            return (0,0);
        }
        var left = DFS ( node.left);
        var right = DFS ( node.right);
        int sum= left.sum + right.sum +node.val;
        int count = left.count + right.count+1;
        int avg = sum / count ;
        if ( node.val == avg){
            ans ++;
        }
        return ( sum , count);
    }
}