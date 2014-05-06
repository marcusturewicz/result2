namespace Result.Tests
{
	using System;
	using Jane;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class ResultExtensionsTests
	{
		[TestMethod]
		public void Reduce_should_be_ok_when_all_ok()
		{
			Assert.IsTrue(new[] { Result.Success(), Result.Success() }.Reduce("uh oh").Ok);
		}

		[TestMethod]
		public void Reduce_should_not_be_ok_when_any_not_ok()
		{
			Assert.IsFalse(new[] { Result.Success(), Result.Failure("errrr") }.Reduce("uh oh").Ok);
		}

		[TestMethod]
		public void Reduce_should_join_errors_with_prefix()
		{
			var result = new[] { Result.Failure("err1"), Result.Failure("err2") }.Reduce("uh oh");
			Assert.AreEqual("uh oh: err1, err2", result.Reason);
		}
	}
}
