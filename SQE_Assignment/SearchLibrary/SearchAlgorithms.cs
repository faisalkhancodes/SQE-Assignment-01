using System;

namespace SearchLibrary
{
    public static class SearchAlgorithms
    {
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                    return mid;

                if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }
            return -1;
        }

        public static int JumpSearch(int[] arr, int target)
        {
            int n = arr.Length;
            if (n == 0) return -1;

            int step = (int)Math.Floor(Math.Sqrt(n));
            int prev = 0;

            while (arr[Math.Min(step, n) - 1] < target)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n)
                    return -1;
            }

            while (arr[prev] < target)
            {
                prev++;
                if (prev == Math.Min(step, n))
                    return -1;
            }

            if (arr[prev] == target)
                return prev;

            return -1;
        }
    }
}
