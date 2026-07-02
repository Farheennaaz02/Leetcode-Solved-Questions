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
    public bool IsSymmetric(TreeNode root) {
        if ( root == null){
            return true ;
        }
        return IsMirror ( root.left , root.right );
        
    }
    private bool IsMirror ( TreeNode left , TreeNode right ){
        if ( left == null&& right == null){
            return true ;
        }
        if (left == null|| right == null){
            return false;
        }
        if ( left.val!= right.val){
            return false ;
        }
        return IsMirror (left.left , right.right)&& IsMirror(left.right , right.left);
    }
}