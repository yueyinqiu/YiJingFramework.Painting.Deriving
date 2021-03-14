﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving.Comparers
{
    /// <summary>
    /// 变爻比较。
    /// Represents a paintings' comparer that will return the indexes of changed lines.
    /// </summary>
    public sealed class ChangingComparer : IComparer<int[]>
    {
        /// <summary>
        /// 比较卦画。
        /// Compare the paintings.
        /// </summary>
        /// <param name="basis">
        /// 作为比较标准的卦画。
        /// The painting to be the comparing basis.
        /// </param>
        /// <param name="obj">
        /// 要比较的卦画。
        /// The painting to be compared.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c>.
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public int[] Compare(Core.Painting basis, Core.Painting obj)
        {
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            var min = Math.Min(basis.Count, obj.Count);
            var max = Math.Max(basis.Count, obj.Count);
            List<int> result = new List<int>(max);
            for (int i = 0; i < min; i++)
                if (basis[i] != obj[i])
                    result.Add(i);
            for (int n = min; n < max; n++)
                result.Add(n);
            return result.ToArray();
        }
    }
}
