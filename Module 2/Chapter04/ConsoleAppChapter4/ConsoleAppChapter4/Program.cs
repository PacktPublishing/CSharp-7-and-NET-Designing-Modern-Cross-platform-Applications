using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleAppChapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNode node = new TreeNode("Root", null);
            //node.Nodes.Add(new TreeNode("Child 1", null));
            //node.Nodes[0].Nodes.Add(new TreeNode("Grand Child 1", null));
            //node.Nodes.Add(new TreeNode("Child 1 (Sibling)", null));
            //PopulateTreeView(node, "");
            //Console.Read();

            //int[] nums = new int[] { 1, 5, 6, 10, 15, 17, 20, 42, 55, 60, 67, 80, 100 };
            //int i = binarySearch(nums, 0, nums.Length, 55);
            //Console.WriteLine(" " + i);
            //Dictionary<string, string> a = new Dictionary<string, string>();
            //a.Add("1", "1");
            //a.Add("1", "1");
            //a.Add("1", "1");

            //a.Add("1", "1");

            //SelectionSort(new int[]{2,3,4,2,1,1,2,3 });
            //AvoidBoxingUnboxing();
            //BoxingUnboxing();
            //AddValuesInArrayList();
            //AddValuesInGenericList();


            //Log logDelegate = LogToConsole;
            //Log logToDatabase = LogToDatabase;
            //logDelegate("This is a simple delegate call");
            //LogToDatabase("This is a simple delegate call");

            //Log logDelegate = LogToConsole;
            //logDelegate += LogToDatabase;
            //logDelegate("This is a simple delegate call");


            
            Console.Read();
        }
   
        private static void AvoidBoxingUnboxing()
        {
    
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //Boxing 
            int counter = 0;
            for (int i = 0; i < 1000000; i++)
            {
                //Unboxing
                counter = i + 1;
            }
            watch.Stop();
            Console.WriteLine($"AvoidBoxingUnboxing: Time taken {watch.ElapsedMilliseconds}");
        }


        private static void AddValuesInArrayList()
        {

            Stopwatch watch = new Stopwatch();
            watch.Start();
            ArrayList arr = new ArrayList();
            for (int i = 0; i < 1000000; i++)
            {
                arr.Add(i);
            }
            watch.Stop();

            
            Console.WriteLine($"Total time taken with ArrayList is {watch.ElapsedMilliseconds}");
        }

        static int LogToConsole(string a) { Console.WriteLine(a);
            return 1;
        }
        static int LogToDatabase(string a)
        {
            Console.WriteLine(a);
            //Log to database
            return 1;
        }

        delegate int Log(string n);

        private static void AddValuesInGenericList()
        {
            

            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<int> lst = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                lst.Add(i);
            }
            watch.Stop();
            Console.WriteLine($"Total time taken with List<int> is {watch.ElapsedMilliseconds}");
        }

            private static void BoxingUnboxing()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("ad");


                Stopwatch watch = new Stopwatch();
                watch.Start();
                //Boxing 
                object counter = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    //Unboxing
                    counter = (int)i + 1;
                }
                watch.Stop();
                Console.WriteLine($"BoxingUnboxing: Time taken {watch.ElapsedMilliseconds}");
            }

            static void SelectionSort(int[] nums)
            {
                int i, j, min;

                // One by one move boundary of unsorted subarray
                for (i = 0; i < nums.Length - 1; i++)
                {
                    min = i;
                    for (j = i + 1; j < nums.Length; j++)
                        if (nums[j] < nums[min])
                            min = j;

                    // Swap the found minimum element with the first element
                    int temp = nums[min];
                    nums[min] = nums[i];
                    nums[i] = temp;
                }
            }


            static int binarySearch(int[] nums, int startingIndex, int length, int itemToSearch)
            {
                if (length >= startingIndex)
                {
                    int mid = startingIndex + (length - startingIndex) / 2;

                    // If the element found at the middle itself
                    if (nums[mid] == itemToSearch)
                        return mid;

                    // If the element is smaller than mid then it is present in left set of array
                    if (nums[mid] > itemToSearch)
                        return binarySearch(nums, startingIndex, mid - 1, itemToSearch);

                    // Else the element is present in right set of array
                    return binarySearch(nums, mid + 1, length, itemToSearch);
                }

                // If item not found return 1
                return -1;
            }


            static bool FindItem(List<string> items, string value)
            {
                foreach (var item in items)
                {
                    if (item == value)
                    {
                        return true;
                    }
                }
                return false;
            }

            static int SumNumbers(int a, int b)
            {
                return a + b;
            }

            //Populates a Tree View on Console
            static void PopulateTreeView(TreeNode node, string space)
            {
                Console.WriteLine(space + node.NodeText);
                space = space + " ";
                foreach (var treenode in node.Nodes)
                {
                    //Recurive call
                    PopulateTreeView(treenode, space);
                }
            }
        }
    

    

   
    class TreeNode
    {

        public TreeNode(string text, object Tag)
        {
            this.NodeText = text;
            this.Tag = Tag;
            Nodes = new List<TreeNode>();
        }
        public string NodeText { get; set; }
        public Object Tag { get; set; }
        public List<TreeNode> Nodes { get; set; }

    }



   


    //class TreeView 
    //{

    //    public TreeNode _node;
    //    //private readonly Dictionary<string, TreeNode> _nodes = new Dictionary<string, TreeNode>();

    //    public TreeView(TreeNode node)
    //    {
    //        this._node = node;
    //    }
        
    //    public void Add(TreeNode node)
    //    {
    //        if (node.Parent != null)
    //        {
    //            node.Parent._nodes.Remove(node);
    //        }

    //        node.Parent = this;
    //        this._nodes.Add(node);
    //    }
    //}
}
