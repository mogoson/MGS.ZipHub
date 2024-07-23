/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IZipper.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Text;

namespace MGS.Zip
{
    public interface IZipper
    {
        IZipOperate<string> ZipAsync(string sourceDir, string destFile,
            Encoding encoding, bool includeBaseDirectory = true, bool clearBefor = true);

        IZipOperate<string> UnzipAsync(string filePath, string destDir, bool clearBefor = true);
    }
}