using System;

namespace RoboticsLibrary.Net.Exceptions
{
    public enum ErrorNo : Int32
    {
        Unknown = -1,
        Success = 0,
        Nullptr,
        NotImplemented,
        StdBadAlloc
    };

    public static class ExceptionHelper
    {
        public static void ThrowOnError(this ErrorNo errorNo)
        {
            switch (errorNo)
            {
                case ErrorNo.Success:
                    return;

                case ErrorNo.Unknown:
                    throw new System.Exception();
                case ErrorNo.Nullptr:
                    throw new NullReferenceException();
                case ErrorNo.NotImplemented:
                    throw new NotImplementedException();
                case ErrorNo.StdBadAlloc:
                    throw new OutOfMemoryException();
                default:
                    throw new System.Exception(errorNo.ToString());
            }
        }
    }
}