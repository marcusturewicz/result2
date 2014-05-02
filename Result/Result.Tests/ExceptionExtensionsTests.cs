namespace Result.Tests
{
	using System;
	using Jane;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class ExceptionExtensionsTests
	{
		[TestMethod]
		public void Should_return_root_message_when_no_inner_exceptions()
		{
			var ex = new Exception("hello");
			
			var innerMessage = ex.InnerMessage();

			Assert.AreEqual("hello", innerMessage);
		}

		[TestMethod]
		public void Should_return_error_message_when_ex_is_null()
		{
			var ex = null as Exception;
			
			var innerMessage = ex.InnerMessage();

			Assert.AreEqual("Exception.InnerMessage Error: exception was null", innerMessage);
		}

		[TestMethod]
		public void Should_return_innermost_ex_message()
		{
			var ex = new Exception("hello", new Exception("inner 1", new Exception("inner 2")));

			var innerMessage = ex.InnerMessage();

			Assert.AreEqual("inner 2", innerMessage);
		}
	}
}
