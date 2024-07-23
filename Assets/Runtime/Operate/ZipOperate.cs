/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ZipWork.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using System.Threading;

namespace MGS.Zip
{
    public abstract class ZipOperate<T> : IZipOperate<T>
    {
        public bool IsDone { protected set; get; }

        public T Result { protected set; get; }

        public Exception Error { protected set; get; }

        public event Action<T, Exception> OnComplete;

        protected Thread thread;
        protected float progress;

        public IEnumerator ExecuteAsync()
        {
            if (thread == null)
            {
                IsDone = false;
                thread = new Thread(Execute) { IsBackground = true };
                thread.Start();

                while (!IsDone)
                {
                    yield return null;
                }
                OnComplete?.Invoke(Result, Error);
            }
        }

        protected void Execute()
        {
            try
            {
                Result = OnExecute();
            }
            catch (Exception ex)
            {
                Error = ex;
            }
            finally
            {
                IsDone = true;
                thread = null;
            }
        }

        protected abstract T OnExecute();

        public void AbortAsync()
        {
            thread?.Abort();
            thread = null;
        }
    }
}