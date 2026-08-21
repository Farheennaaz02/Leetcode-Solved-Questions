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
    
    public int GoodNodes(TreeNode root) {
        //  count nikalna h 
        // dfs lagela 
        return DFS (root , root.val);
        
    }
    int DFS ( TreeNode root , int maxsofar){
        if ( root == null){
            return 0 ;
        }
        int count=0;

        if (root.val>= maxsofar){
            count =1;
        }
        maxsofar = Math.Max(maxsofar , root.val);
       count += DFS ( root.left , maxsofar);
        count+=DFS(root.right, maxsofar);

        return count ;
        
    }
}