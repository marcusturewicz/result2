namespace System.Threading.Tasks
{
	using System.ComponentModel;
	using Jane;
	
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultExtensions
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
