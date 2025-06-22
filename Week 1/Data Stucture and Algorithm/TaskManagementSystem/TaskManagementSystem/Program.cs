using System;

class Task
{
    public int TaskID { get; set; }
    public string TaskName { get; set; }
    public string Status { get; set; }

    public Task(int taskID, string taskName, string status)
    {
        TaskID = taskID;
        TaskName = taskName;
        Status = status;
    }

    public override string ToString()
    {
        return $"ID: {TaskID,-5} ; Name: {TaskName,-15} ; Status: {Status}";
    }
}

class Node
{
    public Task Task { get; set; }
    public Node Next { get; set; }

    public Node(Task task)
    {
        Task = task;
        Next = null;
    }
}

class SinglyLinkedList
{
    public Node Head { get; private set; }

    public SinglyLinkedList()
    {
        Head = null;
    }

    public void Add(Task task)
    {
        Node newnode = new Node(task);

        if (Head == null)
        {
            Head = newnode;
        }
        else
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newnode;
        }

    }

    public Task Search(int id)
    {
        if (Head == null)
        {
            Console.WriteLine("The List is Empty. Cannot search.");
            return null;
        }

        Node current = Head;
        while (current != null)
        {
            if (current.Task.TaskID == id)
            {
                Console.WriteLine($"Task Found: {current.Task}");
                return current.Task;
            }
            current = current.Next;
        }
        Console.WriteLine($"Task with ID {id} not found.");
        return null;
    }

    public void Traverse()
    {
        if (Head == null)
        {
            Console.WriteLine("The List is Empty.");
            return;
        }

        Node current = Head;
        while (current != null)
        {
            Console.WriteLine(current.Task.ToString());
            current = current.Next;
        }
    }

    public bool Delete(int id)
    {
        if (Head == null)
        {
            Console.WriteLine("The List is Empty. Cannot delete.");
            return false;
        }

        if (Head.Task.TaskID == id)
        {
            Head = Head.Next;
            Console.WriteLine($"Task ID {id} deleted (was head).");
            return true;
        }

        Node current = Head.Next;
        Node previous = Head;

        while (current != null)
        {
            if (current.Task.TaskID == id)
            {
                previous.Next = current.Next;
                Console.WriteLine($"Task ID {id} deleted.");
                return true;
            }
            previous = current;
            current = current.Next;
        }

        Console.WriteLine($"Task with ID {id} not found for deletion.");
        return false;
    }
}

class TaskManagementSystem
{
    public static void Main(string[] args)
    {
        SinglyLinkedList list = new SinglyLinkedList();

        list.Add(new Task(1, "Plan Project", "Pending"));
        list.Add(new Task(2, "Develop Module A", "Pending"));
        list.Add(new Task(3, "Test Module A", "Pending"));
        list.Add(new Task(4, "Deploy Module A", "Pending"));
        list.Add(new Task(5, "Develop Module B", "Pending"));

        list.Search(3);
        Console.WriteLine("List Before Deletion");
        list.Traverse();
        list.Delete(2);
        Console.WriteLine("List After Deletion");
        list.Traverse();

       
    }
}

/* Now Let's calculate time complexity of each operation (assuming only worst case)
  for add operation it has only one while loop so the time complexity is O(n)
  for also search,delete,traverse function each contain only one loop so the time complexity of every operation is O(n)
 */
// The Advantage of linked list compared to array is the dynamic size ,efficient deletion and more flexible(even add data at any point) 