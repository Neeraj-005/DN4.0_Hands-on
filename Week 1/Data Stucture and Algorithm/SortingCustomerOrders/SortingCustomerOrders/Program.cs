using System;

class Order
{
    public int orderID;
    public string cutomerName;
    public double totalPrice;
}

class Quicksort
{
    public static int QuickSortWithSteps(Order[] arr, int low, int high, ref int steps)
    {
        if (low < high)
        {
            int pivotIndex = Partitioner(arr, low, high, ref steps);
            QuickSortWithSteps(arr, low, pivotIndex - 1, ref steps);
            QuickSortWithSteps(arr, pivotIndex + 1, high, ref steps);
        }
        return steps;
    }

    public static int Partitioner(Order[] arr, int low, int high, ref int steps)
    {
        int pivot = arr[high].orderID;
        steps++; // for pivot assignment
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            steps++; // comparison
            if (arr[j].orderID < pivot)
            {
                i++;
                swap(arr, i, j);
                steps += 3; // swap counts as 3 steps
            }
        }

        swap(arr, i + 1, high);
        steps += 3; // final swap
        return i + 1;
    }

    public static void swap(Order[] arr, int i, int j)
    {
        Order temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void QuickSort(Order[] arr, int low, int high)
    {
        int dummy = 0;
        QuickSortWithSteps(arr, low, high, ref dummy);
    }
}
class BubbleSort
{
    public static int Bubblesort(Order[] arr,int n)
    {
        int i, j, temp,count=0;
        Boolean swapped;
        for(i=0; i < n; i++)
        {
            swapped = false;
            for (j = 0; j < n - i - 1; j++)
            {
                count++;
                if (arr[j].orderID > arr[j + 1].orderID)
                {
                    temp = arr[j].orderID;
                    arr[j].orderID = arr[j + 1].orderID;
                    arr[j + 1].orderID = temp;
                    swapped = true;
                }
            }
            if (swapped == false) {
                break;
            }
        }
        return count;
    }
}
class SortingCustomerOrders
{
    public static void Main(string[] args)
    {
        Order[] orders = new Order[5];

        orders[0] = new Order { orderID = 105, cutomerName = "Mike", totalPrice = 280.20 };
        orders[1] = new Order { orderID = 101, cutomerName = "Shake", totalPrice = 250.0 };
        orders[2] = new Order { orderID = 104, cutomerName = "David", totalPrice = 400 };
        orders[3] = new Order { orderID = 102, cutomerName = "Harvey", totalPrice = 452.30 };
        orders[4] = new Order { orderID = 103, cutomerName = "Dani", totalPrice = 300.75 };
        int steps = 0;
        int count = Quicksort.QuickSortWithSteps(orders, 0, 4, ref steps);

        Console.WriteLine("Sorted Orders by OrderID In Quick Sort:");
        Console.WriteLine($"Done it in {count} steps");
        foreach (var order in orders)
        {
            Console.WriteLine($"OrderID: {order.orderID}, Name: {order.cutomerName}, Total: {order.totalPrice}");
        }
        Order[] orders2 = new Order[5];

        orders2[1] = new Order { orderID = 105, cutomerName = "Mike", totalPrice = 280.20 };
        orders2[0] = new Order { orderID = 101, cutomerName = "Shake", totalPrice = 250.0 };
        orders2[4] = new Order { orderID = 104, cutomerName = "David", totalPrice = 400 };
        orders2[3] = new Order { orderID = 102, cutomerName = "Harvey", totalPrice = 452.30 };
        orders2[2] = new Order { orderID = 103, cutomerName = "Dani", totalPrice = 300.75 };
        int count2 = BubbleSort.Bubblesort(orders2, 5);

        Console.WriteLine("Sorted Orders by OrderID In Bubble Sort:");
        Console.WriteLine($"Done it in {count2} steps");
        foreach (var order in orders)
        {
            Console.WriteLine($"OrderID: {order.orderID}, Name: {order.cutomerName}, Total: {order.totalPrice}");
        }
    }
}
/*Here Bubble Sort take only 9 steps but whereas Quick Sort takes 27 steps because
  the bubble sort time complexity is O(n^2) so for 5 elements it takes 9 steps
   but the time complexity of quick sort is O(n log n) so here it takes 27 steps
   but for longer array like 1000 elements bubble sort takes 1million steps to complete the sorting
   whereas in an 1000 element array in quick sort it only takes around 40k - 50k steps 
 */
//Quick sort is preffered because of its performance against larger samples
