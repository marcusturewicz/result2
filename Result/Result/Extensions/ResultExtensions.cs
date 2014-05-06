namespace Jane
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using Jane;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultExtensions
	{
		public static IResult Reduce(this IEnumerable<IResult> results, string failureReasonPrefix)
		{
			var errors = results.Where(result => !result.Ok);
			if (errors.Any())
			{
				return Result.Failure(string.Concat(failureReasonPrefix, ": ", string.Join(", ", errors.Select(error => error.Reason))));
			}
			return Result.Success();
		}

		public static IResult<T> Reduce<T>(this IEnumerable<IResult<T>> results, string failureReasonPrefix)
		{
			var errors = results.Where(result => !result.Ok);
			if (errors.Any())
			{
				return Result.Failure<T>(string.Concat(failureReasonPrefix, ": ", string.Join(", ", errors.Select(error => error.Reason))));
			}
			return Result.Success<T>(default(T));
		}
	}
}
