using System;
using System.Threading.Tasks;

namespace IOExtensions.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //You can use the command 'fsutil file createnew c:\Test1\file1.txt 131457280' to create a file with 125MB (Needs to be executed under administrator privileges).

            var source = @"C:\Test1\";
            var destination = @"C:\Test2\";

            await FileTransferManager.CopyWithProgressAsync(source, destination, Progress, false, true, 500);
        }

        private static void Progress(TransferProgress e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}