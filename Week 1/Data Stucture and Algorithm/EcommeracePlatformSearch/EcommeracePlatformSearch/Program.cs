class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
}

class EcommeracePlatformSearch
{
    public static void Main(string[] args)
    {
        //Linear Search
        Product[] arr= new Product[4] ;
        arr[0]= new Product { Id = 1, Name = "Brush", Category = "Essential" };
        arr[1] = new Product { Id = 3, Name = "Paste", Category = "Essential" };
        arr[2] = new Product { Id = 2, Name = "Comb", Category = "Essential" };
        arr[3] = new Product { Id = 4, Name = "Soap", Category = "Essential" };
        int requiredID = 2;
        int count = 1;
        for(int i =0;i<=3;i++)
        {
            if(arr[i].Id == requiredID)
            {
                Console.WriteLine($"Found at {i+1} place in the array and took {count} steps");
            }
            count++;
        }

        //Binary Search
        Product[] arr2 = new Product[4];
        arr2[0] = new Product { Id = 1, Name = "Brush", Category = "Essential" };
        arr2[1] = new Product { Id = 2, Name = "Comb", Category = "Essential" };
        arr2[2] = new Product { Id = 3, Name = "Paste", Category = "Essential" };
        arr2[3] = new Product { Id = 4, Name = "Soap", Category = "Essential" };

        int requiredID2 = 2;
        int count2 = 1;

        int low = 0;
        int high = arr2.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr2[mid].Id == requiredID2)
            {
                Console.WriteLine($"Found at position {mid + 1} in the array and took {count2} steps");
                break;
            }
            else if (arr2[mid].Id < requiredID2)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
            count2++;
        }

        /*In Linear Search it took 3 Steps to find a element in a array that has 4 elements 
         for eg we take an array of 1000 elements to calculate Time or Space Complexity we take 3 cases
         case 1- Best Case that is the required element is at 1st position so the it requires only one check O(n) = O(1)
         case 2- Average Case that is the element is in the 500th position now it requires 500 checks O(n) = O(500)
         case 3- Worst Case that is the element is in the last position now it takes 1000 checks O(n) = O(1000)
         */

        /*In Binary Search it took 1 Steps to find a element in an array that has 4 elements 
          for eg we take an array of 1000 elements (sorted) to calculate Time or Space Complexity we take 3 cases
          case 1- Best Case that is the required element is at the middle position, so it requires only one check O(log n) = O(1)
          case 2- Average Case that is the element is in any random position, now it takes around log₂(1000) = 10 checks O(log n) = O(10)
          case 3- Worst Case that is the element is at the last possible split, still it takes around log₂(1000) = 10 checks O(log n) = O(10)
        */
        //My Conclusion is to use Binary Search for Larger data and Better performance
    }
}