using System;
using Amazon.Glacier;
using Amazon.Glacier.Transfer;
using Amazon.Runtime;

namespace AwsBackup2
{
    class DownloadFile
    {
        static string vaultName = "TestVault";
        static string archiveToDownload = "DvcG_Q5zSqRPk8OXo0tt5jxUZ0hd_adjilyDW4-dxnb-MKrOeeCrOT0eC_nqfIaqezrl69W-wjKYGZmcsTQ2uodxhViPjJjFGig52K4kr2Jia7PzhPtB7qG0sf9nNYwZeP4y2cq5XA";
        //static string downloadFilePath = @"C:\temp\backupTest\";
        static string downloadFilePath = "C:\\temp\\downloadTest\\copyme.txt";
        //---------------------------------
        static string archiveToDownload2 = "UaIAykhaDbO-tsQEp3OQu5a3IdX9TvtJdaBOBlmBwbGNbdDNK-sMCSx9nZUBvbFGxikuZfAqgalNxvHbePcsW1_h1z172DFw88mPyahOhQliL_YUet5eOv_jGTKudqQqFRqrk_JGXQ";
        static string downloadFilePath2 = "C:\\temp\\downloadTest\\dongpaddle.txt";


        public void runDownload()
        {

            try
            {

                //var manager = new ArchiveTransferManager(Amazon.RegionEndpoint.USWest2);

                //var options = new DownloadOptions();
                //options.StreamTransferProgress += ArchiveDownloadHighLevel.progress;
                //// Download an archive.
                //Console.WriteLine("Intiating the archive retrieval job and then polling SQS queue for the archive to be available.");
                //Console.WriteLine("This polling takes about 4 hours. Once the archive is available, downloading will begin.");
                //manager.Download(vaultName, archiveId, downloadFilePath, options);
                //Console.WriteLine("To continue, press Enter");
                //Console.ReadKey();

                var manager = new ArchiveTransferManager(Amazon.RegionEndpoint.USEast1);
                var options = new DownloadOptions();
                options.StreamTransferProgress += DownloadFile.progress;
                Console.WriteLine("Intiating the archive retrieval job and then polling SQS queue for the archive to be available.");
                Console.WriteLine("This polling takes about 4 hours. Once the archive is available, downloading will begin.");
                manager.Download(vaultName, archiveToDownload, downloadFilePath, options);
                manager.Download(vaultName, archiveToDownload2, downloadFilePath2, options);
                
                Console.WriteLine("To continue, press Enter");
                Console.ReadKey();
            }
            catch (AmazonGlacierException e) { Console.WriteLine(e.Message); }
            catch (AmazonServiceException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("To continue, press Enter");
            Console.ReadKey();

        }

        static int currentPercentage = -1;

        static void progress(object sender, StreamTransferProgressArgs args)
        {
            if (args.PercentDone != currentPercentage)
            {
                currentPercentage = args.PercentDone;
                Console.WriteLine("Downloaded {0}%", args.PercentDone);
            }
        }
    }
}
