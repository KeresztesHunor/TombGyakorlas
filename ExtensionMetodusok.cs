namespace TombGyakorlas
{
    internal static class ExtensionMetodusok
    {
        public static string ElvalasztovalOsszekot<T>(this IEnumerable<T> collection, string elvalaszto = ", ", bool forditva = false) => collection.ToArray().ElvalasztovalOsszekot(elvalaszto, forditva);

        public static string ElvalasztovalOsszekot<T>(this IList<T> tomb, string elvalaszto = ", ", bool forditva = false)
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
