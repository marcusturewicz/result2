namespace Result.Tests
{
	using System;
	using System.Threading.Tasks;
	using Jane;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class TaskExtensionsTests
	{
		[TestMethod]
		public void AsTask_should_return_completed_task_with_result_set()
		{
			var result = Result.Success();
			var task = result.AsTask();
			Assert.IsTrue(task.IsCompleted);
			Assert.IsTrue(Object.ReferenceEquals(result, task.Result));
		}

		[TestMethod]
		public void AsTask_T_should_return_completed_task_with_result_set()
		{
			var val = new { };
			var result = Result.Success(val);
			var task = result.AsTask();
			Assert.IsTrue(task.IsCompleted);
			Assert.IsTrue(Object.ReferenceEquals(result, task.Result));
			Assert.IsTrue(Object.ReferenceEquals(result.Value, task.Result.Value));
		}
	}
}
