namespace Result2.Tests
{
    using System;
    using Result2;
    using Xunit;

    public class Result2Tests
    {
        [Fact]
        public void Ok_should_be_true_when_using_success_helper()
        {
            var result = Result.Success();
            Assert.True(result.Ok);
        }

        [Fact]
        public void Ok_should_be_true_when_using_success_helper_with_value()
        {
            var obj = new { };
            var result = Result.Success(obj);
            Assert.True(result.Ok);
            Assert.True(ReferenceEquals(obj, result.Value));
        }

        [Fact]
        public void Ok_should_be_false_and_have_reason_when_using_failure_helper()
        {
            var result = Result.Failure("error");
            Assert.False(result.Ok);
            Assert.Equal("error", result.Reason);
        }

        [Fact]
        public void Ok_should_be_false_and_have_reason_when_using_failure_helper_with_exception()
        {
            var result = Result.Failure(new Exception("error"));
            Assert.False(result.Ok);
            Assert.Equal("error", result.Reason);
            Assert.NotNull(result.Exception);
        }

        [Fact]
        public void Ok_should_use_innermost_exception()
        {
            var result = Result.Failure(new Exception("error", new Exception("inner 1")));
            Assert.False(result.Ok);
            Assert.Equal("inner 1", result.Reason);
            Assert.NotNull(result.Exception);
        }

        [Fact]
        public void From_should_be_ok_when_no_exception()
        {
            var result = Result.From(() => { });
            Assert.True(result.Ok);
        }

        [Fact]
        public void From_should_not_be_ok_when_exception_is_thrown()
        {
            var result = Result.From(() => { throw new Exception("err"); });
            Assert.False(result.Ok);
            Assert.Equal("err", result.Reason);
            Assert.NotNull(result.Exception);
        }

        [Fact]
        public void From_T_should_be_ok_when_no_exception()
        {
            var val = new { };
            var result = Result.From(() => val);
            Assert.True(result.Ok);
            Assert.True(ReferenceEquals(val, result.Value));
        }

        [Fact]
        public void From_T_should_not_be_ok_when_exception_is_thrown()
        {
            var result = Result.From<object>(() => { throw new Exception("err"); });
            Assert.False(result.Ok);
            Assert.Equal("err", result.Reason);
            Assert.NotNull(result.Exception);
        }
    }
}
