/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IZipHub.cs
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
    public interface IZipHub
    {
        IAsyncOperateHub AsyncHub { get; }

        IZipOperate ZipAsync(string sourceDir, string destFile,
            Encoding encoding, bool includeBaseDirectory = true, bool clearBefor = true);

        IZipOperate UnzipAsync(string filePath, string destDir, bool clearBefor = true);

        void AbortAsync(IZipOperate operate);
    }
}