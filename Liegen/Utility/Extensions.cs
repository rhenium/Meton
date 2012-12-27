using System;

namespace Meton.Liegen.Utility
{
    public static class Extensions
    {
        public static TResult Using<T, TResult>(this T disposable, Func<T, TResult> func)
            where T : IDisposable
        {
            using (disposable) return func(disposable);
        }
    }
}
