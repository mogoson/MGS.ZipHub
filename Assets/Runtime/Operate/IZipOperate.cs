/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IZipOperate.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;

namespace MGS.Zip
{
    public interface IZipOperate<T>
    {
        bool IsDone { get; }

        T Result { get; }

        Exception Error { get; }

        event Action<float> OnProgress;

        event Action<T, Exception> OnComplete;

        IEnumerator ExecuteAsync();

        void AbortAsync();
    }
}