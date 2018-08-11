using CodePractice.Commons;
using System;
using System.Collections.Generic;
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


    }
}
