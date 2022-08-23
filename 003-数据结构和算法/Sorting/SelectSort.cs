namespace Sorting
{
    //选择排序 O（n²）
    class SelectSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            //外层循环控制每一轮循环中要交换的位置i
            //第一轮循环 i=0 执行循环体内逻辑 找到最小值然后和arr[i]交换 将第一个元素排好序
            //第二轮循环 i=1 执行循环体内逻辑 找到最小值然后和arr[i]交换 将第二个元素排好序
            //....
            //第n轮循环 i=n-1 执行循环体内逻辑 找到最小值然后和arr[i]交换 将最后一个元素排好序
            //跳出外层循环 完成整个数组的选择排序
            for (int i = 0; i < n; i++)
            {
                //最小元素的索引min 从未排序的第一个位置i开始寻找
                int min = i;

                //内层循环在[i+1...n)寻找最小值对应的索引min
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }

                //内层循环结束，找到最小值arr[min]，和未排序的边界元素arr[i]交换位置
                Swap(arr, i, min);
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
