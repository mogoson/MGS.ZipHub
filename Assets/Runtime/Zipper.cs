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

        static Zipper()
        {
            var handlerGo = new GameObject("Zipper");
            DontDestroyOnLoad(handlerGo);
            Handler = handlerGo.AddComponent<Zipper>();
        }

        public IZipOperate<string> Zip(IEnumerable<string> entries, string destFile,
            Encoding encoding, string directoryPathInArchive = null, bool clearBefor = true)
        {
            var requester = new DoZipOperate(entries, destFile, encoding, directoryPathInArchive, clearBefor);
            StartCoroutine(requester.ExecuteAsync());
            return requester;
        }

        public IZipOperate<string> Unzip(string filePath, string destDir, bool clearBefor = true)
        {
            var requester = new UnZipOperate(filePath, destDir, clearBefor);
            StartCoroutine(requester.ExecuteAsync());
            return requester;
        }
    }
}