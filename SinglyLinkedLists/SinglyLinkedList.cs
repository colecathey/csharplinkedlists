using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {        
        private SinglyLinkedListNode first_node;
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }
        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {            
            if(values.Count() == 0)
            {
                throw new NotImplementedException();
            }
            for (var i = 0; i < values.Count(); i++)
            {
                this.AddLast(values[i].ToString());
            }            
        }
        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx        
        public string this[int index]
        {            
            get
            {
                return this.ElementAt(index); 
            }               
            set
            {
                var placeholder = new SinglyLinkedList();
                for(var j = 0; j < this.Count(); j++)
                {
                    if (j == index)
                    {
                        placeholder.AddLast(value);                    
                    } else
                    {
                        placeholder.AddLast(this.ElementAt(j));
                    } 
                }
                first_node = new SinglyLinkedListNode(placeholder.First());

                for(var k = 1; k < placeholder.Count(); k++ )
                {
                    this.AddLast(placeholder.ElementAt(k));
                }
               }       
        }
        public void AddAfter(string existingValue, string value)
        {
            var new_node = new SinglyLinkedListNode(value);
            var node = first_node;
            while (node != null)
            {
                if(node.Value == existingValue)
                {
                    if (node.IsLast())
                    {
                        node.Next = new_node;
                        return;
                    }
                    var orignext = node.Next;
                node.Next = new_node;
                new_node.Next = orignext;                    
                    return;
                } 
                node = node.Next;
            }             
            throw new ArgumentException();            
        }
        public void AddFirst(string value)
        {            
            if (this.first_node == null)
            {
                first_node = new SinglyLinkedListNode(value);
            } else
            {
                var new_node = new SinglyLinkedListNode(value);
                new_node.Next = first_node;
                this.first_node = new_node;                
            }            
        }
        public void AddLast(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                var node = this.first_node;
                if (!node.IsLast()) // what's another way to do this????
                {
                    node = node.Next;
                }                
                node.Next = new SinglyLinkedListNode(value);
            }
        }
        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            //*if the list is empty
            //*this.Count() == 0
            if (this.First() == null)
            {
                return 0;
            }
            else
            {
                int length = 1;
                var node = this.first_node;
                // Complrxity is O(n)
                while (node.Next != null)
                {
                    length++;
                    node = node.Next;
                }               
                return length;
            }         
        }
        public string ElementAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var node = this.first_node;
                for (var i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        break;
                    }
                    node = node.Next;
                }
                return node.Value;
            }
        }
        public string First()
        {
            if (this.first_node == null)
            {
                return null;
            }
            else
            {
                return this.first_node.Value;
            }
        }
        //return this.first_node ? null : this.first_node.Value;
        public int IndexOf(string value)
        {
            var indexValue = -1;
            for(var i = 0; i < this.Count(); i++)
            {
                if(this.ElementAt(i) == value)
                {
                    indexValue = i;
                    break;
                }
            }
            return indexValue;            
        }
        public bool IsSorted()
        {
            throw new NotImplementedException();
        }
        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            var node = this.first_node;
            if (node == null)
            {
                return null;
            }
            else
            {
                while (!node.IsLast())
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }
        public void Remove(string value)
        {
            int indexValue = this.IndexOf(value);
            var placeholder = new SinglyLinkedList();
            for(var i = 0; i < this.Count(); i++)
            {
                if(i != indexValue )
                {                    
                    placeholder.AddLast(this.ElementAt(i));
                }
            }
            first_node = new SinglyLinkedListNode(placeholder.First());
            for (var j = 1; j < placeholder.Count(); ++j)
            {
                this.AddLast(placeholder.ElementAt(j));
            }
        }        
        public void Sort()
        {
            throw new NotImplementedException();
        }
        public string[] ToArray()
        {
            string[] array = new string[this.Count()];
            for(var i =0; i < this.Count(); i++)
            {
                array[i] = this.ElementAt(i);
            }
            return array;
        }
        public override string ToString()
        {
            var opening = "{";
            var ending = "}";            
            var space = " ";
            var output = "";
            var quote = "\"";
            var comma = "," + space;
            output += opening;
            var node = this.first_node;
            if (this.Count() >= 1)
            {
                output += space;                
                while (!node.IsLast())
                {
                    output += quote + node.Value + quote + comma;
                    node = node.Next;
                }
                output += quote + this.Last() + quote;
            }            
            output += space;
            output += ending;
            return output;
        }
    }
}