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
            var filePath = Path.Combine(currentDirectory, _resourceName);
            await File.WriteAllBytesAsync(filePath, resource);

            ZipFile.ExtractToDirectory(filePath, currentDirectory);
            File.Delete(filePath);
        }
    }
}
