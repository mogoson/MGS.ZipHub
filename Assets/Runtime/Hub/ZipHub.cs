/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ZipHub.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Text;
using MGS.Operate;

namespace MGS.Zip
{
    public class ZipHub : IZipHub
    {
        public IAsyncOperateHub AsyncHub { protected set; get; }

        public ZipHub(IAsyncOperateHub asyncHub)
        {
            AsyncHub = asyncHub;
        }

        public IZipOperate ZipAsync(string sourceDir, string destFile,
            Encoding encoding, bool includeBaseDirectory = true, bool clearBefor = true)
        {
            var operate = new DoZipOperate(sourceDir, destFile, encoding, includeBaseDirectory, clearBefor);
            AsyncHub.Enqueue(operate);
            return operate;
        }

        public IZipOperate UnzipAsync(string filePath, string destDir, bool clearBefor = true)
        {
            var operate = new UnZipOperate(filePath, destDir, clearBefor);
            AsyncHub.Enqueue(operate);
            return operate;
        }

        public void AbortAsync(IZipOperate operate)
        {
            AsyncHub.Dequeue(operate);
        }
    }
}