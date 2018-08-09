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
    class List2Pointer
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LPalin(new ListNode(1)));
        }
        private static int LPalin(ListNode inputList)
        {
            if (inputList == null) return 0; // check for null.
            
            Stack<int> poppedList = new Stack<int>();
            ListNode head = inputList;
            ListNode headToCheck = inputList;
            // Traverse the list to push the values into this Stack
            while (head.next != null)
            {
                poppedList.Push(head.val);
                head = head.next;
            }

            // Match the elements for checking the palindrome. 
            while(headToCheck.next != null)
            {
                int popedElement = poppedList.Pop();
                if(popedElement == headToCheck.val)
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
    }
}
