using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Jane
{
	/// <summary>
	/// Represents a completed Result
	/// </summary>
	public interface IResult
	{
		bool Ok { get; }
		string Reason { get; }
	}

	/// <summary>
	/// Represents a completed Result with a Value
	/// </summary>
	public interface IResult<T> : IResult
	{
		T Value { get; }
	}

	/// <summary>
	/// Represents a completed Result
	/// </summary>
	public class Result : IResult
	{
		public bool Ok { get; protected set; }
		public string Reason { get; protected set; }

		/// <summary>
		/// Use the static helper methods to create a <see cref="Result"/>
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Result(bool ok, string reason)
		{
			Ok = ok;
			Reason = reason;
		}

		public static IResult Success()
		{
			return new Result(true, null);
		}

		public static IResult<T> Success<T>(T value)
		{
			return new Result<T>(true, null, value);
		}

		public static IResult Failure(string reason)
		{
			return new Result(false, reason);
		}

		public static IResult Failure(string reason, params object[] args)
		{
			return Failure(string.Format(reason, args));
		}

		public static IResult<T> Failure<T>(string reason)
		{
			return new Result<T>(false, reason, default(T));
		}

		public static IResult<T> Failure<T>(string reason, params object[] args)
		{
			return Failure<T>(string.Format(reason, args));
		}

		public static IResult Failure(Exception ex)
		{
			return new Result(false, ex.InnerMessage());
		}

		public static IResult<T> Failure<T>(Exception ex)
		{
			return new Result<T>(false, ex.InnerMessage(), default(T));
		}

		public static IEnumerable<IResult> Group(params IResult[] results)
		{
			return results;
		}

		public static IEnumerable<IResult<T>> Group<T>(params IResult<T>[] results)
		{
			return results;
		}
	}

	/// <summary>
	/// Represents a completed Result with a Value
	/// </summary>
	public class Result<T> : Result, IResult<T>
	{
		public T Value { get; protected set; }

		/// <summary>
		/// Use the static helper methods to create a <see cref="Result{T}"/>
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Result(bool ok, string reason, T value)
			: base(ok, reason)
		{
			Value = value;
		}
	}

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
