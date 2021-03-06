﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodePractice.Commons;
using CodePractice.LinkedList;

namespace Tests.LinkedList
{
    [TestClass]
    public class List2PointerTests
    {
        public List2Pointer TestInstance;

        [TestInitialize]
        public void Setup()
        {
            TestInstance = new List2Pointer();
        }

        [TestMethod]
        public void LPalin_ReturnInt()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1, 2, 1 });
            ListNode response = TestInstance.deleteDuplicates(testInput.Head);
            ListNode result = testInput.Head;

            // Assert
            Assert.IsTrue(this.compareLinkedLists(result, response));
        }

        [TestMethod]
        public void deleteDuplicates_ReturnsList()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1, 1, 2, 2, 3, 4, 4, 5, 5, 6 });
            ListNode result = new TLinkedList(new int[] {1,2,3,4,5,6 }).Head;

            ListNode response = TestInstance.deleteDuplicates(testInput.Head);

            // Assert the test.
            Assert.IsTrue(this.compareLinkedLists(result, response));
        }

        [TestMethod]
        public void mergeTwoLists_returnListHead()
        {
            TLinkedList testInput_1 = new TLinkedList(new int[] { 1, 2, 3 });
            TLinkedList testInput_2 = new TLinkedList(new int[] { 4, 5, 6 });
            ListNode result = new TLinkedList(new int[] { 1, 2, 3, 4, 5, 6 }).Head;

            ListNode response = TestInstance.MergeTwoLists(testInput_1.Head,testInput_2.Head);

            // Assert the test.
            Assert.IsTrue(this.compareLinkedLists(result, response));
        }

        [TestMethod]
        public void RemoveNthFromEnd_ReturnHead()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1, 1, 2, 2, 3, 4, 4, 5, 5, 6 });
            ListNode result = new TLinkedList(new int[] { 1, 2, 2, 3, 4, 4, 5, 5, 6 }).Head;


            ListNode response = TestInstance.RemoveNthFromEnd(testInput.Head,15);

            // Assert the test.
            Assert.IsTrue(this.compareLinkedLists(result, response));
        }

        [TestMethod]
        public void DeleteDuplicates2_ReturnInputHead()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1, 1, 2, 2, 3, 3, 6 });
            ListNode result = new TLinkedList(new int[] { 6 }).Head;


            ListNode response = TestInstance.DeleteDuplicates2(testInput.Head);

            // Assert the test.
            Assert.IsTrue(this.compareLinkedLists(result, response));
            
        }

        [TestMethod]
        public void RotateRight_ReturnsRotatedList()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1, 1, 2, 2, 3, 3, 6 });
            ListNode result = new TLinkedList(new int[] { 1, 1, 2, 2, 3, 3, 6}).Head;
            this.executeFunctionInputTypeListNodeInt(result, testInput, TestInstance.RotateRight, 70);
        }

        [TestMethod]
        public void ReorderList_ReturnsList()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1,1 });
            ListNode result = new TLinkedList(new int[] {1,1}).Head;

            this.executeFunctionInputTypeListNode(result, testInput, TestInstance.ReorderList);
        }

        [TestMethod]
        public void ReverseBetween_ReturnReversedList()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1,2,3,4,5 });
            ListNode result = new TLinkedList(new int[] {5,4,3,2,1}).Head;
            ListNode response = TestInstance.ReverseBetween(testInput.Head,1,5);

            // Assert the test.
            Assert.IsTrue(this.compareLinkedLists(result, response));
        }

        [TestMethod]
        public void SwapPairs_RetunsList()
        {
            TLinkedList testInput = new TLinkedList(new int[] { 1,2});
            ListNode result = new TLinkedList(new int[] {2,1}).Head;
            
            this.executeFunctionInputTypeListNode(result, testInput, TestInstance.SwapPairs);
            
        }

        [TestMethod]
        public void AddTwoNumbers_ReturnSumAsList()
        {
            TLinkedList testInput1 = new TLinkedList(new int[] { 9,9});
            TLinkedList testInput2 = new TLinkedList(new int[] { 9,9});
            ListNode result = new TLinkedList(new int[] {8,9,1}).Head;
            ListNode response = TestInstance.addTwoNumbers(testInput1.Head,testInput2.Head);

            // Assert the test.
            Assert.IsTrue(this.compareLinkedLists(result, response));
            
            
            
        }
        private void executeFunctionInputTypeListNode(ListNode result, TLinkedList testInput, Func<ListNode, ListNode> f)
        {
            ListNode response = f(testInput.Head);
            Assert.IsTrue(this.compareLinkedLists(result, response));
        }
        
        private void executeFunctionInputTypeListNodeInt(ListNode result, TLinkedList testInput, Func<ListNode,int, ListNode> f,int pos)
        {
            ListNode response = f(testInput.Head, pos);
            Assert.IsTrue(this.compareLinkedLists(result, response));
        }
        
        private bool compareLinkedLists(ListNode first, ListNode second)
        {
            while (first != null)
            {
                if (first.val == second.val)
                {
                    first = first.next;
                    second = second.next;
                }
                else
                {
                    return false;
                }
            }

            if(first == second)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
