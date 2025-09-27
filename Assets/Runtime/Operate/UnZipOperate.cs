/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UnZipOperate.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System.IO;
using System.IO.Compression;

namespace MGS.Zip
{
    public class UnZipOperate : ZipOperate
    {
        protected string filePath;
        protected string destDir;
        protected bool clearBefor;

        public UnZipOperate(string filePath, string destDir, bool clearBefor = true)
        {
            this.filePath = filePath;
            this.destDir = destDir;
            this.clearBefor = clearBefor;
        }

        protected override string OnExecute()
        {
            if (clearBefor)
            {
                if (Directory.Exists(destDir))
                {
                    Directory.Delete(destDir, true);
                }
            }

            ZipFile.ExtractToDirectory(filePath, destDir);
            return destDir;
        }
    }
}