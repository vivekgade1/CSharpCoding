using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CodePractice.Commons
{

    /// <summary>
    /// Linked List Node.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        
        public ListNode(int x)
        {
                this.val = x;
                this.next = null;
        }
    }
    
    public class TLinkedList
    {
        public ListNode Head { get; set; }
        public TLinkedList(int[] input)
        {
            this.Head = new ListNode(input[0]);
            this.init(input);
        }

        private void init(int[] input)
        {
            try
            {
                ListNode ele = this.Head;
                for (int indx = 1; indx < input.Length; indx++)
                {
                    ele.next = new ListNode(input[indx]);
                    ele = ele.next;
                }
            }
            catch (SyntaxErrorException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
