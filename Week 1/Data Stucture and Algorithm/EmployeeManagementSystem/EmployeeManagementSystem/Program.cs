using System.Runtime.CompilerServices;

class Employee
{
    public int employeeID;
    public string name;
    public string position;
    public double salary;
}
class Array
{
    public static void Add(Employee[] arr, Employee emp,ref int count)
    {
        if (count < arr.Length) { 
        arr[count] = emp;
        count++;
        }
        else
        {
            Console.WriteLine("Array is full");
        }
    }
    public static void Search(Employee[] arr, int emp,ref int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (arr[i].employeeID == emp)
            {
                Console.WriteLine($"EmployeeID : {arr[i].employeeID}   ; Name : {arr[i].name}   ; Position : {arr[i].position}   ; Salary : {arr[i].salary}");
            }
        }
    }
    public static void Traverse(Employee[] arr,ref int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"EmployeeID : {arr[i].employeeID}   ; Name : {arr[i].name}   ; Position : {arr[i].position}   ; Salary : {arr[i].salary}");
        }
    }

    public static void Delete(Employee[] arr,int emp,ref int count)
    {
        Boolean deleted = false;
        for (int i = 0; i < count; i++)
        {
            if (arr[i].employeeID == emp)
            {
                for (int j = i; j < count; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[count - 1] = null;
                count--;
                deleted = true;
            }
            
        }
        if(deleted==false)
        {
            Console.WriteLine("Employee Not Found");
        }
    }
}
class EmployeeManagementSystem
{
    static Employee[] employees = new Employee[10];
    static int count = 0;
    public static void Main(string[] args)
    {
        Array.Add(employees,new Employee { employeeID = 4, name = "Shake", position = "Head of Development", salary = 300000 },ref count);
        Array.Add(employees, new Employee { employeeID = 5, name = "David", position = "Developer", salary = 30000 }, ref count);
        Array.Add(employees, new Employee { employeeID = 2, name = "Dani", position = "Junior Developer", salary = 50000 }, ref count);
        Array.Add(employees, new Employee { employeeID = 7, name = "Ross", position = "Associate", salary = 40000 }, ref count);
        Array.Add(employees, new Employee { employeeID = 1, name = "Mike", position = "CEO", salary = 3000000 }, ref count);
        Console.WriteLine("Searching For a Employee");
        Array.Search(employees, 7,ref count);
        Console.WriteLine("Employee List:");
        Array.Traverse(employees,ref count);
        Array.Delete(employees, 5, ref count);
        Console.WriteLine("Employee List after Update:");
        Array.Traverse(employees, ref count);
    }
}
/*Let's Calculate the Time Complexity of each function
  for add function there is no loops so the time complexity is O(1)
  for search function there is a single for loop so the time compelxity is O(n)
  for traverse function also there is single for loop so the time complexity is O(n)
  for delete function there is a for loop which will run one time and a for loop inside if condtion so atmost it will also execute once 
  so the time complexity is O(n) + O(n) = O(n)
 */
// The Limitation of the arrray is the fixed size,deletion of a specific sample is time consuming due to shifting,need a manual pointer
// When to use array is when we know the size is fixed and easier access through index 