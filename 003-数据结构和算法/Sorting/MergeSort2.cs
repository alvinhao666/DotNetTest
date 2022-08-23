namespace Sorting
{
    //时间复杂度O(nlogn)
    //空间复杂度O（n）需要借助一个同样长度的辅助数组进行排序
    class MergeSort2
    {
        //用户调用的排序方法传进数组即可排序
        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];
            Sort(arr, temp, 0, n - 1);
        }

        //递归使用归并排序，对arr[l...r]的范围进行排序
        private static void Sort(int[] arr, int[] temp, int l, int r)
        {

            if (r - l + 1 <= 15)
            {
                InsertSort.Sort1(arr, l, r);
                return;
            }

            int mid = l + (r - l) / 2;
            Sort(arr, temp, l, mid);        //将左半边排序
            Sort(arr, temp, mid + 1, r);    //将右半边排序

            if (arr[mid] > arr[mid + 1])
                Merge(arr, temp, l, mid, r);    //归并结果
        }

        // 将arr[l...mid]和arr[mid+1...r]两部分有序排列进行归并
        private static void Merge(int[] arr, int[] temp, int l, int mid, int r)
        {
            int i = l;
            int j = mid + 1;
            int k = l;

            //左右半边都有元素(将小的放到temp数组中)
            while (i <= mid && j <= r)
            {
                if (arr[i] < arr[j])
                    temp[k++] = arr[i++];
                else //arr[i] >= arr[j]
                    temp[k++] = arr[j++];
            }

            //左半边还有元素，右半边用尽（取左半边的元素）
            while (i <= mid)
                temp[k++] = arr[i++];

            //右半边还有元素，左半边用尽（取右半边的元素）
            while (j <= r)
                temp[k++] = arr[j++];

            //将temp数组拷贝回给arr数组，完成arr排序
            for (int z = l; z <= r; z++)
                arr[z] = temp[z];
        }
    }
}
