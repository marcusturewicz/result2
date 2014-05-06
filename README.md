## What's a Result?
Result is a contract, usually in the form of `IResult`.

An `IResult` has two properties:
* `Ok`: Was the call a success?
* `Reason`: Usually ignored when `Ok`, contains the reason for the failure when not `Ok`

There's also an `IResult<T>`, which gets an extra property.
* `Value`: Values should only be trusted when the result is `Ok` (think `TryParse`)!


## Returning Results
`IResult`s are constructed using the following helper methods:
* `Result.Success()`: Returns an `IResult` where `Ok` is `true`
* `Result.Success(T value)`: Same as above, but returns `IResult<T>` with `Value` set
* `Result.Failure(string reason, [string.Format params])`: Don't be lazy and pass `null`.  No one likes empty errors!
* `Result.Failure(Exception ex)`: Uses the innermost `InnerException`'s `Message` (useful in catch blocks of course!)

## Why not return a bool and use 'out' for the other values?
`out` isn't always an option.  Asynchronous code doesn't play well with `out` parameters.  You can't even use an `await` on a method with an `out` parameter!

So how do you associate success or failure with `Task`s?  A `Task<X>` can't return a `Task<Y>` when it fails.  The only way you communicate failure is to throw an exception, which [Microsoft says you shouldn't do](http://msdn.microsoft.com/en-us/library/dd264997.aspx) (tl;dr exceptions are _slow_!), and check the task's `TaskStatus` (or `IsFaulted` or `IsCanceled`, depends on what type of exception stopped the task).

So what do you use when `out` isn't allowed and exceptions are slow?  This is the hole `Result` fills.  As a result, methods returning `IResult` should **never** throw an exception.  You can prefix any `IResult` method names with `Try` to emphasize this.


## NuGet?
Of course!
```
PM> Install-Package Result
```

That's all there is to it.  Happy (now faster, more success/failure aware) async coding!
