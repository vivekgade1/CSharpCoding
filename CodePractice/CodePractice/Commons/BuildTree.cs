using System.Collections.Generic;
using CodePractice.Commons;

namespace CodePractice.Commons
{
    public class BuildTree
    {
        public TreeNode SimpleTreeFromList(List<int> inputList)
        {
            TreeNode result = new TreeNode(inputList[0]);
            inputList.GetRange(1, inputList.Count - 1).ForEach(item => { _ = this.InsertSimpleTree( null, result, item); });
            return result;
        }

        private TreeNode InsertSimpleTree(TreeNode parentNode, TreeNode root, int item)
        {
            if (root == null)
            {
                TreeNode ele = new TreeNode(item);
                if (item < parentNode.val)
                {
                    parentNode.left = ele;
                }
                else
                {
                    parentNode.right = ele;
                }

                return ele;
            }
            
            if (item < root.val)
            {
                return this.InsertSimpleTree(root, root.left, item);
            }else
            {
                return this.InsertSimpleTree(root, root.right, item);
            }
        }
    }
}