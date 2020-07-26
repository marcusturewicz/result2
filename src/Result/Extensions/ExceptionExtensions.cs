namespace Result2
{
    using System;
    using System.ComponentModel;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ExceptionExtensions
    {
        public static string InnerMessage(this Exception ex)
        {
            if (ex == null)
            {
                return "Exception.InnerMessage Error: exception was null";
            }
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }
    }
}
