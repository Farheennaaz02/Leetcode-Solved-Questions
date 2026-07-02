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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        Dictionary <int , int > inordermap= new ();
        for ( int i =0;i<inorder .Length ;i++){
            inordermap[inorder[i]]=i;
        }
        return Split ( preorder, inordermap , 0,0 , inorder.Length-1);

        
    }
    private TreeNode Split ( int [] preorder ,Dictionary<int , int > inordermap , int rootindex, int left , int right){
        TreeNode root = new TreeNode ( preorder[rootindex]);
        int mid = inordermap [preorder[rootindex]];
        if ( left > right){
            return null ;
        }

        if ( mid > left ){
            root.left = Split ( preorder,inordermap , rootindex +1 , left , mid -1);
        }
        if ( mid< right){
            root.right = Split ( preorder , inordermap , rootindex+ ( mid -left )+1 , mid+1 , right );

            
        }
        return root ;
    }
}