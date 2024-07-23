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

using System.Text;
using UnityEngine;

namespace MGS.Zip
{
    public class Zipper : MonoBehaviour, IZipper
    {
        public static IZipper Handler { get; }

        static Zipper()
        {
            var handlerGo = new GameObject("Zipper");
            DontDestroyOnLoad(handlerGo);
            Handler = handlerGo.AddComponent<Zipper>();
        }

        public IZipOperate<string> ZipAsync(string sourceDir, string destFile,
            Encoding encoding, bool includeBaseDirectory = true, bool clearBefor = true)
        {
            var requester = new DoZipOperate(sourceDir, destFile, encoding, includeBaseDirectory, clearBefor);
            StartCoroutine(requester.ExecuteAsync());
            return requester;
        }

        public IZipOperate<string> UnzipAsync(string filePath, string destDir, bool clearBefor = true)
        {
            var requester = new UnZipOperate(filePath, destDir, clearBefor);
            StartCoroutine(requester.ExecuteAsync());
            return requester;
        }
    }
}