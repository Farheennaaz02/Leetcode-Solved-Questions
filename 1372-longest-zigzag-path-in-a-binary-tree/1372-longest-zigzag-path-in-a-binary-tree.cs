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
    int maxpath =0;
    public int LongestZigZag(TreeNode root) {
        solve ( root , 0 , true);
        solve ( root, 0 , false);
        return maxpath;
    }
    void solve (TreeNode root , int steps , bool goleft){
        if ( root ==  null){
            return ;
        }
        maxpath = Math.Max ( maxpath , steps);
        if ( goleft){
            solve (root.left , steps+1 , false);// acha baach baat maane vala 
            solve ( root.right , 1 , true );// batameez
        }
        else {// go right 
            solve (root.right , steps+1 , true );
            solve ( root.left , 1 , false );

        }
    }
}