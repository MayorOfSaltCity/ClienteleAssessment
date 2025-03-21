﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Factorial
{
    public static class FactorialExtensions
    {
        // declare a semaphore with a maximum count of 5
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(10);

        public static async Task<int[]> FactorAsync(this int[] numbers)
        {
            try
            {
                await semaphore.WaitAsync();
                var tasks = numbers.Select(FactorialOfAsync).ToArray();
                return await Task.WhenAll(tasks);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public static async Task<int> FactorialOfAsync(int number)
        {

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than or equal to 0");
            }

            if (number == 0)
            {
                return 1;
            }

            return number * await FactorialOfAsync(number - 1);
        }
    }
}
