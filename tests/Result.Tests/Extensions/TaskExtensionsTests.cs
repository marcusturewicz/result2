namespace Result2.Tests
{
    using System;
    using System.Threading.Tasks;
    using Result2;
    using Xunit;

    public class TaskExtensionsTests
    {
        [Fact]
        public void AsTask_should_return_completed_task_with_result_set()
        {
            var result = Result.Success();
            var task = result.AsTask();
            Assert.True(task.IsCompleted);
            Assert.True(Object.ReferenceEquals(result, task.Result));
        }

        [Fact]
        public void AsTask_T_should_return_completed_task_with_result_set()
        {
            var val = new { };
            var result = Result.Success(val);
            var task = result.AsTask();
            Assert.True(task.IsCompleted);
            Assert.True(Object.ReferenceEquals(result, task.Result));
            Assert.True(Object.ReferenceEquals(result.Value, task.Result.Value));
        }
    }
}
