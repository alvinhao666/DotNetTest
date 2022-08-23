namespace Sorting
{
    //快速排序 O（nlogn）
    class QuickSort1
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            Sort(arr, 0, n - 1);
        }

        private static void Sort(int[] arr, int l, int r)
        {
            if (r - l + 1 <= 15)
            {
                InsertSort.Sort1(arr, l, r);
                return;
            }

            int v = arr[l];

            int j = l; // arr[l+1...j] < v  arr[j+1...i-1] > v

            for (int i = l + 1; i <= r; i++)
            {
                if (arr[i] < v)
                {
                    j++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, l, j);
            Sort(arr, l, j - 1);
            Sort(arr, j + 1, r);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int e = arr[i];
            arr[i] = arr[j];
            arr[j] = e;
        }
    }
}
