using System.Diagnostics.CodeAnalysis;

namespace Domain.Helpers
{
    public class CompareByProperties<T> : IEqualityComparer<T>
    {
        public bool Equals(T? x, T? y)
        {
            var type = typeof(T);
            var props = type.GetProperties();

            return props.All(p => p.GetValue(x)?.Equals(p.GetValue(y)) ?? false);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            var result = 0;
            foreach (var prop in typeof(T).GetProperties())
            {
                result ^= prop?.GetValue(obj)?.GetHashCode() ?? 0;
            }

            return result;
        }
    }
}
