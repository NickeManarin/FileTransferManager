using System;
using System.Threading.Tasks;

namespace IOExtensions.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //You can use the command 'fsutil file createnew c:\Test1\file1.txt 131457280' to create a file with 125MB (Needs to be executed under administrator privileges).
            //Or this script to create multiple files:
            //For ($i=0; $i -lt 200; $i++) { cmd.exe / c("C:\WINDOWS\system32\fsutil file createnew c:\Test1\file" + $i + ".txt 1457280") }

            var source = @"C:\Test1\";
            var destination = @"C:\Test2\";

            await FileTransferManager.CopyWithProgressAsync(source, destination, Progress, false, true, 500);
        }

        private static void Progress(TransferProgress e)
        {
            try
            {
                Console.WriteLine(e.GetDataPerSecondFormatted(SuffixStyle.Windows, "{0:###,##0.0}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}