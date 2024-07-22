/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
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
using Ionic.Zip;

namespace MGS.Zip
{
    public class UnZipOperate : ZipOperate<string>
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

            using (var zipFile = new ZipFile(filePath))
            {
                zipFile.ExtractProgress += (s, e) =>
                {
                    if (e == null || e.EntriesTotal == 0)
                    {
                        return;
                    }

                    progress = (float)e.EntriesExtracted / e.EntriesTotal;
                };
                zipFile.ExtractAll(destDir, ExtractExistingFileAction.OverwriteSilently);
            }
            return destDir;
        }
    }
}