using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CodePractice.Commons;

namespace CodePractice.Trees
{
    public class Trees
    {
        public static void Main()
        {
            TreeNode test = new BuildTree().SimpleTreeFromList(new List<int>(){1,2});
            Trees input = new Trees();
            Console.WriteLine(input.RightSideView(test));
        }
        
        /// <summary>
        /// Right side view of the tree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            List<List<int>> levelLists = this.GetLevelOrderNodesAsList(root);
            List<int> result = new List<int>();
            
            levelLists.ForEach(levelList =>
            {
                if (levelList.Any())
                {
                    result.Add(levelList[^1]);                    
                }
            });
            return result;
        }
        
        /// <summary>
        /// Figures the boundary of a binary tree. 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> BoundaryOfBinaryTree(TreeNode root) {
            /*
             *  First do a level oredr traversal of the tree and them push left most and right most nodes according to the buckets.
             *  Put all the nodes in last level which is the leaves list and the concat the buckets for the result.  
             */

            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            List<int> leftSide = this.leftBoundary(root); // left view  of the tree with out leaf
            List<int> rightSide = this.rightBoundary(root); // right view of the tree with out leaf and root 
            List<int> leaves = this.leafNodes(root, new List<int>()); // all the leaves from left to right
            rightSide.Reverse();
            if (leaves.Count > 0)
            {
                if (leftSide[leftSide.Count - 1] == leaves[0])
                {
                    leftSide = leftSide.GetRange(0, leftSide.Count - 1);
                }

                if (rightSide.Count > 0 && rightSide[0] == leaves[leaves.Count - 1])
                {
                    rightSide = rightSide.GetRange(1, rightSide.Count - 1);
                }
                
                if ((leftSide.Count > 0 && rightSide.Count > 0)&& (leftSide[0] == rightSide[rightSide.Count -1]))
                {
                    rightSide = rightSide.GetRange(0, rightSide.Count - 1);
                }
            }

            leftSide.AddRange(leaves);
            leftSide.AddRange(rightSide);
            return leftSide;
        }

        private List<int> leafNodes(TreeNode root, List<int> result)
        {
            
            if (root.left != null)
            {
                _ = this.leafNodes(root.left, result);
            }

            if (root.right != null)
            {
                _ = this.leafNodes(root.right, result);
            }
            
            if (root.left == null && root.right == null)
            {
                result.Add(root.val);                
            }
            
            return result;
        }

        private List<int> rightBoundary(TreeNode root)
        {
            TreeNode ele = root;
            List<int> result = new List<int>();
            if (ele == null)
            {
                return result;
            }
            if (ele.right == null)
            {
                result.Add(ele.val);
                return result;
            }
            
            while (ele != null)
            {
                result.Add(ele.val);
                if (ele.right != null)
                {
                    ele = ele.right;
                }
                else
                {
                    ele = ele.left;
                }
            }
            return result;
        }

        private List<int> leftBoundary(TreeNode root)
        {
            TreeNode ele = root;
            List<int> result = new List<int>();
            if (ele.left == null)
            {
                result.Add(ele.val);
                return result;
            }

            while (ele != null)
            {
                result.Add(ele.val);
                if (ele.left != null)
                {
                    ele = ele.left;
                }
                else
                {
                    ele = ele.right;
                }
            }

            return result;
        }


        /// <summary>
        /// Path sum.
        /// </summary>
        /// <param name="head">Head of the tree.</param>
        /// <param name="sum">sum to check</param>
        /// <returns></returns>
        public int hasPathSum(TreeNode head, int sum)
        {
            sum = sum - head.val;
            if (head.left == null && head.right == null)
            {
                if (sum == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (head.left != null && head.right == null)
            {
                return this.hasPathSum(head.left, sum);
            }
            else if (head.left == null && head.right != null)
            {
                return this.hasPathSum(head.right, sum);
                
            }
            else
            {
                int leftVal = this.hasPathSum(head.left, sum);
                int rightVal = this.hasPathSum(head.right, sum);

                if (leftVal == 1 || rightVal == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        /*/// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node ConnectDfs(Node root)
        {
            var head = root;
            if (head == null)
            {
                return head;
            }
            Dictionary<int,Stack<Node>> map = new Dictionary<int, Stack<Node>>();
            LevelTraverse(head,map, 0);
            return root;

        }

        private void LevelTraverse(Node currentNode, Dictionary<int, Stack<Node>> map, int level)
        {
            currentNode.next = null;
            if (map.ContainsKey(level))
            {
                map[level].Peek().next = currentNode;
                map[level].Push(currentNode);
            }
            else
            {
                map.Add(level,new Stack<Node>());
                map[level].Push(currentNode);
            }

            if (currentNode.left != null)
            {
                this.LevelTraverse(currentNode.left,map,level + 1);
            }

            if (currentNode.right != null)
            {
                this.LevelTraverse(currentNode.right, map, level + 1);
            }
        }

        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            var head = root;
            if (head == null)
            {
                return head;
            }
            Queue<Node> levelQueue = new Queue<Node>();
            levelQueue.Enqueue(head);
            int levelCount = 0;
            Node dequeueNode = null, peekNode = null;
            while (levelQueue.Count != 0)
            {
                levelCount = levelQueue.Count;
                while (levelCount != 0)
                {
                    dequeueNode = levelQueue.Dequeue();
                    if (dequeueNode.left != null)
                    {
                        levelQueue.Enqueue(dequeueNode.left);
                    }

                    if (dequeueNode.right != null)
                    {
                        levelQueue.Enqueue(dequeueNode.right);
                    }
                    
                    dequeueNode.next = levelQueue.TryPeek(out peekNode) && levelCount > 1 ? peekNode : null;
                    levelCount--;

                }
            }
            return root;
        }*/

        /// <summary>
        /// Check the tree is balanced by dong level order traversal and checking the length at each level.
        /// </summary>
        /// <param name="head">root of the tree.</param>
        /// <returns>1 / 0 </returns>
        public int IsBalanced(TreeNode head) {
            if (head == null)
                return 0;
            Queue<TreeNode> levelList = new Queue<TreeNode>();
            levelList.Enqueue(head);
            TreeNode dequeNode = null;
            int level = 0, levelCapacity = 0;

            while (levelList.Count != 0)
            {
                if ((int) Math.Pow(2,level) != levelList.Count) // 2^ level nodes in a balanced tree. 
                {
                    return 0;
                }

                levelCapacity = levelList.Count;

                while (levelCapacity != 0)
                {
                    dequeNode = levelList.Dequeue();
                    if (dequeNode.left != null && dequeNode.right != null)
                    {
                        levelList.Enqueue(dequeNode.left);
                        levelList.Enqueue(dequeNode.right);
    
                    }
                    else
                    {
                        return 0;
                    }
                    levelCapacity--;
                }

            }

            return 1;
        }
        
        
        /// <summary>
        /// Invert a tree. Mirror image of the tree.
        /// </summary>
        /// <param name="head">root of the tree.</param>
        /// <returns>tree root</returns>
        public TreeNode InvertTree(TreeNode head)
        {
            if (head == null)
                return null;
            
            Queue<TreeNode> order = new Queue<TreeNode>();
            order.Enqueue(head);
            TreeNode dequeNode = null, temp = null;
            
            while (order.Count != 0)
            {
                dequeNode = order.Dequeue();

                if (dequeNode.left != null && dequeNode.right != null)
                {
                    temp = dequeNode.right;
                    dequeNode.right = dequeNode.left;
                    dequeNode.left = temp;

                }
                else if (dequeNode.left != null)
                {
                    order.Enqueue(dequeNode.left);
                    dequeNode.right = dequeNode.left;
                    dequeNode.left = null;
                }
                else if (dequeNode.right != null)
                {
                    order.Enqueue(dequeNode.right);
                    dequeNode.left = dequeNode.right;
                    dequeNode.right = null;
                }
            }

            return head;
        }
        
        /// <summary>
        /// Zig zag tree traversal BFS.
        /// </summary>
        /// <param name="head">root of the tree.</param>
        /// <returns>List of list in zig zag order.</returns>
        public List<List<int>> ZigzagLevelOrder(TreeNode head) {
            List<List<int>> result= new List<List<int>>();
            if (head == null) return result;
            int level = 0;
            Queue<TreeNode> order = new Queue<TreeNode>();
            order.Enqueue(head);
            List<int> listToPush;
            int depth = order.Count;
            TreeNode dequeNode = null;
            while (order.Count != 0)
            {
                listToPush = new List<int>();
                if (level % 2 != 0)
                {
                    order = new Queue<TreeNode>(order.Reverse());
                }
            
                while (depth != 0)
                {
                    dequeNode = order.Dequeue();
                
                    if (dequeNode.left != null)
                    {
                        order.Enqueue(dequeNode.left);
                    }

                    if (dequeNode.right != null)
                    {
                        order.Enqueue(dequeNode.right);
                    }
                    listToPush.Add(dequeNode.val);
                    depth--;
                }
                result.Add(listToPush);
                level++;
                depth = order.Count;
            }
        
            return result;
        }
        
        /// <summary>
        /// Vertical traversal of a tree. 
        /// </summary>
        /// <param name="head">root of the tree.</param>
        /// <returns>List of list of tree node values which are matching the vertical order sequence.</returns>
        public List<List<int>> VerticalOrderTraversal(TreeNode head) 
        {
            List<List<int>> result = new List<List<int>>();
            Dictionary<int,List<int>> map = new Dictionary<int, List<int>>();
            Queue<TreeNode> levelQ = new Queue<TreeNode>();
            Queue<int> vDepthQ = new Queue<int>();
            if(head == null){
                return result;
            }
            levelQ.Enqueue(head);
            vDepthQ.Enqueue(0);
            int depth = levelQ.Count;

            while (levelQ.Count != 0)
            {
                while (depth != 0)
                {
                    var dequeNode = levelQ.Dequeue();
                    var dequeVd = vDepthQ.Dequeue();
                    if (!map.ContainsKey(dequeVd))
                    {
                        map[dequeVd] = new List<int>();
                    }
            
                    map[dequeVd].Add(dequeNode.val);
                    
                    if (dequeNode.left != null)
                    {
                        levelQ.Enqueue(dequeNode.left);
                        vDepthQ.Enqueue(dequeVd + 1);
                    }

                    if (dequeNode.right != null)
                    {
                        levelQ.Enqueue(dequeNode.right);
                        vDepthQ.Enqueue(dequeVd - 1);
                    }
                    depth--;
                }

                depth = levelQ.Count;
            }
            
            int maxKey = map.Keys.Max();
            int minKey = map.Keys.Min();
            while (maxKey >= minKey)
            {
                result.Add(map[maxKey]);
                maxKey--;
            }
            return result;

        }
        private List<List<int>> GetLevelOrderNodesAsList(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();

            if (root == null) return result;
            Queue<TreeNode> intermList = new Queue<TreeNode>();
            intermList.Enqueue(root);

            while (intermList.Any())
            {
                List<int> levelValuesList = new List<int>();
                int levelNodesCount = intermList.Count;
                while (levelNodesCount != 0)
                {
                    TreeNode currNode = intermList.Dequeue();
                    if (currNode.left != null)
                    {
                        intermList.Enqueue(currNode.left);
                    }
                    if (currNode.right != null)
                    {
                        intermList.Enqueue(currNode.right);
                    }
                    levelValuesList.Add(currNode.val);
                    levelNodesCount--;
                }

                if (levelValuesList.Any())
                {
                    result.Add(levelValuesList);
                }
            }
            return result;
        }
    }
}