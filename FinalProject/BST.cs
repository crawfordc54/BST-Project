using System;

namespace FinalProject
{
    class BST
    {
        public Node Root { get; set; }

        public bool Add(Employee newEmp)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (String.Compare(newEmp.name, after.Data.name) < 0) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (String.Compare(newEmp.name, after.Data.name) > 0) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = newEmp;

            if (this.Root == null) //Tree ise empty
                this.Root = newNode;
            else
            {
                if (String.Compare(newEmp.name, before.Data.name) < 0)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public Node Find(string emp)
        {
            return this.Find(emp, this.Root);
        }

        public void Remove(Employee emp)
        {
            this.Root = Remove(this.Root, emp);
        }

        private Node Remove(Node parent, Employee newEmp)
        {
            if (parent == null) return parent;

            if (String.Compare(newEmp.email, parent.Data.email) < 0) parent.LeftNode = Remove(parent.LeftNode, newEmp);
            else if (String.Compare(newEmp.email, parent.Data.email) > 0)
                parent.RightNode = Remove(parent.RightNode, newEmp);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private Employee MinValue(Node node)
        {
            Employee minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node Find(string emp, Node parent)
        {
            if (parent != null)
            {
                if (emp.Equals(parent.Data.email)) return parent;
                if (String.Compare(emp, parent.Data.email) < 0)
                    return Find(emp, parent.LeftNode);
                else
                    return Find(emp, parent.RightNode);
            }

            return null;
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.WriteLine(parent.Data.name.PadRight(20) + "                            " + parent.Data.email.PadRight(32) + "                   " + parent.Data.position.PadRight(16));
                TraverseInOrder(parent.RightNode);
            }
        }
    }
}
