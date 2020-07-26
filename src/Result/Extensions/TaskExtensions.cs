namespace Result2
{
    using System.ComponentModel;
    using System.Threading.Tasks;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TaskExtensions
    {
        public static Task<IResult> AsTask(this IResult result)
        {
            return Task.FromResult(result);
        }

        public static Task<IResult<T>> AsTask<T>(this IResult<T> result)
        {
            return Task.FromResult(result);
        }
    }
}
