namespace SolidPrinciplesExamples.Misc
{
    public static class StaticKernel
    {
        public static T Get<T>()
        {
            return default(T);
        }
    }
}
