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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        List<int > path =  new ();
        List<IList<int >> ans = new ();
         DFS ( root, targetSum , path , ans , 0);
         return ans;
        
    }
    void DFS ( TreeNode root , int targetsum , List<int >path , List<IList<int >> ans , int sumsofar){
        if ( root ==  null){
            return ;
        }
        path.Add(root.val);
        sumsofar+= root.val;
        if ( root.left == null && root.right == null){
            if (sumsofar== targetsum){
                ans.Add(new List<int > (path) );
            }
        }
        DFS ( root.left , targetsum , path , ans , sumsofar );
        DFS ( root.right , targetsum , path , ans , sumsofar );
        path.RemoveAt (path.Count-1);


    }
}