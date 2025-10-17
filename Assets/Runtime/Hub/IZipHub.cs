/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IZipHub.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/21
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.Text;
using MGS.Operate;

namespace MGS.Zip
{
    public interface IZipHub
    {
        IAsyncOperateHub AsyncHub { get; }

        IZipOperate ZipAsync(IEnumerable<string> entries, string destFile, Encoding encoding,
            string directoryPathInArchive = null, bool clearBefor = true);

        IZipOperate UnzipAsync(string filePath, string destDir, bool clearBefor = true);

        void AbortAsync(IZipOperate operate);
    }
}