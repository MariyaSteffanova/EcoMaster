namespace Econom.Services.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class EnumerableExtensions
    {
        public static async Task ForEachAsync<T>(this IEnumerable<T> collection, Action<T> action)
        {
            var tasks = collection
                .Select(item => Task.Run(() => action(item)))
                .ToList();

            await Task.WhenAll(tasks);
        }
    }
}
