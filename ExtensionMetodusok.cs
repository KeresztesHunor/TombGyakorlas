namespace TombGyakorlas
{
    internal static class ExtensionMetodusok
    {
        public static string VesszovelKiirat<T>(this IList<T> tomb, bool forditva = false)
        {
            (Func<int, Index> index, Func<Index> utolsoIndex) = !forditva ? ((Func<int, Index>)((int i) => i), (Func<Index>)(() => ^1)) : ((int i) => ^(i + 1), () => 0);
            string s = "";
            int utolsoElotti = tomb.Count - 1;
            for (int i = 0; i < utolsoElotti; i++)
            {
                s += tomb[index(i)] + ", ";
            }
            return s + tomb[utolsoIndex()];
        }
    }
}
