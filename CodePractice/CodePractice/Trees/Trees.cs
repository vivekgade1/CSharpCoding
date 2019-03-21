using System;
using System.Collections.Generic;
using System.Linq;
using CodePractice.Commons;

namespace CodePractice.Trees
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node()
        {
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class Trees
    {
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
        
        /// <summary>
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
        }

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
    }
}