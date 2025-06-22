using System.Diagnostics.Metrics;

class book
{
    public int bookID;
    public String bookName;
    public String author;
    public book(int bookID, String bookName, String author)
    {
        this.bookID = bookID;   
        this.bookName = bookName;
        this.author = author;
    }
}
class LinearSearch
{
    public void linearSearch(book[] arr,int id)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i].bookID == id) {
                Console.WriteLine("Match Found in Linear Search");
                Console.WriteLine($"Book ID : {arr[i].bookID}  Book Name : {arr[i].bookName}  Author : {arr[i].author} in {count} steps");
            }
            count++;

        }
    }
}
class BinarySearch
{
    public void binarySearch(book[] arr,int id)
    {
        int low = 0;
        int high = arr.Length - 1;
        int count2 = 0;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid].bookID == id)
            {
                Console.WriteLine("Match Found in Binary Search");
                Console.WriteLine($"Book ID : {arr[mid].bookID}  Book Name : {arr[mid].bookName}  Author : {arr[mid].author} in {count2} steps");
                break;
            }
            else if (arr[mid].bookID < id)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
            count2++;
        }
    }
}
class LibraryManagementSystem
{
    public static void Main(string[] args)
    {
        book[] arr1 = new book[6];
        arr1[0] = new book(4, "Harry Potter", "J.K Rowling");
        arr1[1] = new book(6, "1984", "George Orwell");
        arr1[2] = new book(2, "To Kill a Mockingbird", "Harper Lee");
        arr1[3] = new book(17, "Pride and Prejudice", "Jane Austen");
        arr1[4] = new book(8, "Sapiens: A Brief History of Humankind", "Yuval Noah Harari");
        arr1[5] = new book(3, "The Hitchhiker's Guide to the Galaxy", "Douglas Adams");
        LinearSearch linear = new LinearSearch();
        linear.linearSearch(arr1, 17);

        book[] arr2 = new book[6];
        arr2[0] = new book(2, "To Kill a Mockingbird", "Harper Lee");
        arr2[1] = new book(3, "The Hitchhiker's Guide to the Galaxy", "Douglas Adams");
        arr2[2] = new book(4, "Harry Potter", "J.K Rowling");
        arr2[3] = new book(6, "1984", "George Orwell");
        arr2[4] = new book(8, "Sapiens: A Brief History of Humankind", "Yuval Noah Harari");
        arr2[5] = new book(17, "Pride and Prejudice", "Jane Austen");
        BinarySearch binary = new BinarySearch();
        binary.binarySearch(arr2, 17);
    }
}
        /*In Linear Search it took 3 Steps to find a element in a array that has 6 elements 
         for eg we take an array of 1000 elements to calculate Time or Space Complexity we take 3 cases
         case 1- Best Case that is the required element is at 1st position so the it requires only one check O(n) = O(1)
         case 2- Average Case that is the element is in the 500th position now it requires 500 checks O(n) = O(500)
         case 3- Worst Case that is the element is in the last position now it takes 1000 checks O(n) = O(1000)
         */

        /*In Binary Search it took 2 Steps to find a element in an array that has 6 elements 
         for eg we take an array of 1000 elements (sorted) to calculate Time or Space Complexity we take 3 cases
         case 1- Best Case that is the required element is at the middle position, so it requires only one check O(log n) = O(1)
         case 2- Average Case that is the element is in any random position, now it takes around log₂(1000) = 10 checks O(log n) = O(10)
         case 3- Worst Case that is the element is at the last possible split, still it takes around log₂(1000) = 10 checks O(log n) = O(10)
        */
        //For smaller data sample and for less complexity use linear search if the data is huge just  use binary search
