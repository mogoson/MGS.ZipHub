/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Zipper.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MGS.Zip
{
    public class Zipper : MonoBehaviour, IZipper
    {
        public static IZipper Handler { get; }

        protected IDictionary<IZipOperate, Coroutine> operates = new Dictionary<IZipOperate, Coroutine>();

        static Zipper()
        {
            var handlerGo = new GameObject("Zipper");
            DontDestroyOnLoad(handlerGo);
            Handler = handlerGo.AddComponent<Zipper>();
        }

        public IZipOperate<string> ZipAsync(string sourceDir, string destFile,
            Encoding encoding, bool includeBaseDirectory = true, bool clearBefor = true)
        {
            var operate = new DoZipOperate(sourceDir, destFile, encoding, includeBaseDirectory, clearBefor);
            operate.OnComplete += (r, e) => operates.Remove(operate);

            var routine = StartCoroutine(operate.ExecuteAsync());
            operates.Add(operate, routine);
            return operate;
        }

        public IZipOperate<string> UnzipAsync(string filePath, string destDir, bool clearBefor = true)
        {
            var operate = new UnZipOperate(filePath, destDir, clearBefor);
            operate.OnComplete += (r, e) => operates.Remove(operate);

            var routine = StartCoroutine(operate.ExecuteAsync());
            operates.Add(operate, routine);
            return operate;
        }

        public void AbortAsync(IZipOperate operate)
        {
            operate.AbortAsync();
            var routine = operates[operate];
            if (routine != null)
            {
                StopCoroutine(routine);
            }
            operates.Remove(operate);
        }

        public void AbortAll()
        {
            foreach (var requester in operates.Keys)
            {
                AbortAsync(requester);
            }
        }
    }
}