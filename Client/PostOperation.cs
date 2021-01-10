using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class PostOperation
    {
        private static readonly string _resourceName = "CR400BF_C.zip";

        public static async Task ExtractResourceAsync()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var resource = Properties.Resources.CR400BF_C;
            var extractPath = Path.Combine(currentDirectory, _resourceName);
            await File.WriteAllBytesAsync(extractPath, resource);

            ZipFile.ExtractToDirectory(extractPath, Path.Combine(currentDirectory, _resourceName.Replace(".zip", "")));
            File.Delete(extractPath);
        }
    }
}
