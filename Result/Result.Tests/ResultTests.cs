namespace Result.Tests
{
	using System;
	using Jane;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class ResultTests
	{
		[TestMethod]
		public void Ok_should_be_true_when_using_success_helper()
		{
			var result = Result.Success();
			Assert.IsTrue(result.Ok);
		}

		[TestMethod]
		public void Ok_should_be_true_when_using_success_helper_with_value()
		{
			var obj = new { };
			var result = Result.Success(obj);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(Object.ReferenceEquals(obj, result.Value));
		}

		[TestMethod]
		public void Ok_should_be_false_and_have_reason_when_using_failure_helper()
		{
			var result = Result.Failure("error");
			Assert.IsFalse(result.Ok);
			Assert.AreEqual("error", result.Reason);
		}

		[TestMethod]
		public void Ok_should_be_false_and_have_reason_when_using_failure_helper_with_exception()
		{
			var result = Result.Failure(new Exception("error"));
			Assert.IsFalse(result.Ok);
			Assert.AreEqual("error", result.Reason);
		}

		[TestMethod]
		public void Ok_should_use_innermost_exception()
		{
			var result = Result.Failure(new Exception("error", new Exception("inner 1")));
			Assert.IsFalse(result.Ok);
			Assert.AreEqual("inner 1", result.Reason);
		}
	}
}
