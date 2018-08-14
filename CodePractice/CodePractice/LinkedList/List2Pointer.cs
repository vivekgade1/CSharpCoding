using CodePractice.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.LinkedList
{
    /// <summary>
    /// Contains programes related to List 2 pointer section 
    /// @author vgade
    /// </summary>
    public class List2Pointer
    {
        public static void Main(string[] args)
        {
            TLinkedList testList = new TLinkedList(new int[] { 1, 1, 2, 2, 3, 4, 4, 5, 5, 6 });
        }

        /*
         * Check for palindrome linked list
         * @author : vgade
         */
        public int LPalin(ListNode inputList)
        {
            if (inputList == null) return 0; // check for null.

            Stack<int> poppedList = new Stack<int>();
            ListNode head = inputList;
            ListNode headToCheck = inputList;
            // Traverse the list to push the values into this Stack
            while (head != null)
            {
                poppedList.Push(head.val);
                head = head.next;
            }

            // Match the elements for checking the palindrome. 
            while (headToCheck != null)
            {
                int popedElement = poppedList.Pop();
                if (popedElement == headToCheck.val)
                {
                    headToCheck = headToCheck.next;
                }
                else
                {
                    return 0;
                }
            }

            return 1;
        }

        /*
         * Given a sorted list, remove all the duplicates.
         * @author : vgade
         */
        public ListNode deleteDuplicates(ListNode inputListHead)
        {
            ListNode leftNode = null;
            ListNode currentNode = inputListHead;

            while (currentNode != null)
            {
                if (leftNode == null) // this is to check for the duplicates at starting of the list. 
                {
                    leftNode = currentNode;
                    currentNode = currentNode.next;
                    continue;
                }

                if (leftNode != null && currentNode.val != leftNode.val)
                {
                    leftNode.next = currentNode;
                    leftNode = currentNode;
                    currentNode = currentNode.next;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }

            if (leftNode.next != null) // this check is for the tail duplicates. 
            {
                leftNode.next = null;
            }

            return inputListHead;

        }

        /*
         * Given two sorted lists, merger them.
         * @author : vgade
         */
        public ListNode MergeTwoLists(ListNode first, ListNode second)
        {
            ListNode resultHead = null;
            ListNode left = null;
            ListNode current = null;

            while ( first != null || second != null )
            {
                // if first < second
                if (second == null || ( first != null && first.val < second.val))
                {
                    current = new ListNode(first.val);
                    first = first.next;
                }
                // if first > second or first = second
                else if( first == null || ( second != null && (first.val > second.val || first.val == second.val)))
                {
                    current = new ListNode(second.val);
                    second = second.next;
                }
                if (left != null)
                {
                    left.next = current;
                    left = current;

                }
                else
                {
                    resultHead = current;
                    left = current;
                }
            }
            return resultHead;
        }

        /*
         * Remove nth position from end of the list. 
         * @author : vgade
         */
        public ListNode RemoveNthFromEnd(ListNode inputListHead, int position)
        {
            ListNode result = inputListHead;
            ListNode left = null;
            int listSize = this.GetListLength(inputListHead);
            int currentPosition = 0;

            if(listSize < position)
            {
                position = listSize; // this is the check for the list.

            }else if(listSize == 1 && listSize == position) // this check is for the single node list. 
            {
                return null;
            }

            while(inputListHead != null)
            {
                currentPosition++;
                if (listSize - position + 1 == currentPosition)
                {
                    if (listSize == position)
                    {
                        inputListHead = inputListHead.next;
                        result = inputListHead;
                    }
                    else
                    {
                        left.next = inputListHead.next;
                    }
                }
                else
                {
                    left = inputListHead;
                }
                inputListHead = inputListHead.next;
            }
            return result;

        }
        
        /*
         * Given a sorted list withduplicates. Return the list with unique items.
         * Using a stack, pop the list and check for duplicates. 
         * @author : vgade
         */
        public ListNode DeleteDuplicates2(ListNode inputHead) {
            Stack<ListNode> listStack = new Stack<ListNode>();
            ListNode currentNode = inputHead.next;
            listStack.Push(inputHead);
            ListNode popedNode = null;
            
            while (currentNode != null)
            {   
                if (listStack.Peek().val == currentNode.val)
                {
                    popedNode = listStack.Pop();
                    while (currentNode != null && currentNode.val == popedNode.val)
                    {
                        currentNode = currentNode.next;
                    }
                }

                if (listStack.Count != 0)
                {
                    listStack.Peek().next = currentNode;
                }
                else
                {
                    inputHead = currentNode;
                }

                if (currentNode != null)
                {
                    listStack.Push(currentNode);
                    currentNode = currentNode.next;
                }
            }

            return inputHead;

        }
        
        /*
         *  Rotate the list given a position.
         * Find the position the node and set the tail and head of the result link.
         * @author : vgade
         */
        public ListNode RotateRight(ListNode inputListHead, int position)
        {
            int inputSize = this.GetListLength(inputListHead);
            ListNode currentNode = inputListHead;
            int currentLength = 0;
            ListNode prevNode = null;
            ListNode resultNode = null;

            if (position > inputSize) {position = position % inputSize;}
            if (inputSize == position || position == 0 ) return inputListHead; // check for the given position to rotate greater then input length
            
            while (currentNode != null)
            {
                currentLength++;
                if (currentLength == inputSize - position + 1) // check the position in the list to rotate
                {
                    prevNode.next = null; // Set the tail of the new list.
                    resultNode = currentNode; // to set the new head of the rotated list.
                }
                
                prevNode = currentNode;
                currentNode = currentNode.next;
                
                if (currentNode == null)
                {
                    prevNode.next = inputListHead; // join the tails of input to form the new list.  
                }
            }

            return resultNode;

        }
        
        /*
         * Reorder the given list.
         * used a stack to traverese the list from the end and iterate only to the mid of the list. 
         * @author : vgade
         */
        public ListNode ReorderList(ListNode inputListHead)
        {
            Stack<ListNode> listStack = this.GetListStack(inputListHead); // travers teh list to get to the tail of the list.
            int inputSize = listStack.Count; 
            if (inputSize == 0 || inputSize == 1) return inputListHead;  
            ListNode resultHead = inputListHead; // return the head.
            ListNode poppedNode = null, nextNode = inputListHead.next;
            
            int halfSize = (int) (inputSize / 2);
            

            for (int indx = 0; indx < halfSize; indx++)
            {
                poppedNode = listStack.Pop();
                inputListHead.next = poppedNode;
                poppedNode.next = nextNode;
                inputListHead = nextNode;
                nextNode = nextNode.next;
            }

            // This check will ensure that the list in rearranged when the list length is odd. 
            // The mid element will be in the last in this case.  
            if(!listStack.Peek().Equals(nextNode))
            {
                nextNode = nextNode.next;
            
            }
            nextNode.next = null;
            
            return resultHead;
        }
        
        /*
         *  Given a Linked list, reverse thelist in between two end point left and right. 
         *  In place reversal and should be done in a simple pass.
         *  @author : vgade
         */
        public ListNode ReverseBetween(ListNode inputListHead, int left, int right)
        {
            /*    Explanation for the sum.
             *    if left = 2, right = 3
             *    
             *    1 ->  2 -> 3 -> 4 -> 5
             *    |     |         |    |
             *   LN    left     right  RN
             *
             *     current and prev are the pointers to the current and previous nodes while iterating.
             *     refNode comes into picture to capture the currentNode between left and right.
             */
            
            ListNode resultHead = inputListHead;
            ListNode leftNode = null, rightNode = null, currentNode = inputListHead, prevNode = null, refNode = null;;
            int listSize = 1;

            while (listSize != right + 1)
            {
                if (listSize == left)
                {
                    leftNode = prevNode;
                    rightNode = currentNode;
                    refNode = null;
                    while ( listSize != right + 1 ) // ietrating to the right + 1 because we need reference to the node on the right position.
                    {
                        refNode = currentNode;
                        currentNode = currentNode.next;
                        refNode.next = prevNode;
                        prevNode = refNode;
                        listSize++;
                    }

                    if (leftNode != null) 
                        leftNode.next = refNode; 
                    else 
                        resultHead = refNode; // set the head when the left position is 1.
                    
                    if (rightNode != null)
                        rightNode.next = currentNode;
                    
                }
                else
                {
                    prevNode = currentNode;
                    currentNode = currentNode.next;
                    listSize++;
                }

            }

            return resultHead;

        }
        
        
        /*
         *  Helper classes start from here.
         */
        
        // Gets the length of a list.
        private int GetListLength(ListNode head)
        {
            int result = 0;
            while(head != null)
            {
                result++;
                head = head.next;
            }
            return result;
        }
        
        // Convert a list to stack.
        private Stack<ListNode> GetListStack(ListNode head)
        {
            Stack<ListNode> result = new Stack<ListNode>();
            while(head != null)
            {
                result.Push(head);
                head = head.next;
            }
            return result;
        }


    }
}
