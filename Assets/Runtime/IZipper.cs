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

using System.Collections.Generic;
using System.Text;

namespace MGS.Zip
{
    public interface IZipper
    {
        IZipOperate<string> Zip(IEnumerable<string> entries, string destFile, Encoding encoding,
            string directoryPathInArchive = null, bool clearBefor = true);

        IZipOperate<string> Unzip(string filePath, string destDir, bool clearBefor = true);
    }
}