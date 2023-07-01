using System;

namespace _1._2_ExtensionMethods_Exceptions {
    public static class Extensions {
        // TODO: GetInnerstException
        public static Exception GetInnerstException(this Exception e)
        {
            Exception ex = e;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            throw ex;
        }
        // TODO: ForEachException
        public static void ForEachException(this Exception e, Action<Exception> action)
        {
            Exception ex = e;
            while (ex.InnerException != null)
            {
                action(ex);
                ex = ex.InnerException;
            }
        } 
    }
}
