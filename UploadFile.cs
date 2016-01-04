using System;
using Amazon.Glacier;
using Amazon.Glacier.Transfer;
using Amazon.Runtime;

namespace AwsBackup2
{
    class UploadFile
    {
        static string vaultName = "TestVault";
        //static string archiveToUpload = "f:\\pics\\copyMe.txt";
        //static string archiveToUpload = "c:\\temp\\copyme.txt";
        static string archiveToUpload = "c:\\temp\\dongpaddle.txt";

        /*
         * this appends a filename and file key pair to location specified in 'CopyArchiveKeys'
         */
        public void runUpload(){
            CopyArchiveKeys cak = new CopyArchiveKeys(@"C:\Code\VisualStudio\Projects\AwsBackup2\KeyCopy\");
            try{
                var manager = new ArchiveTransferManager(Amazon.RegionEndpoint.USEast1);
                string archiveID = manager.Upload(vaultName, "getting started test", archiveToUpload).ArchiveId;
                Console.WriteLine("Archive ID (copy and save for next step): {0}", archiveID);
                cak.copyThis(archiveToUpload+" "+"-"+" "+archiveID);
                //cak.copyThis("test");
                //Console.ReadKey();
            }
            catch (AmazonGlacierException e) { Console.WriteLine(e.Message);}
            catch (AmazonServiceException e) { Console.WriteLine(e.Message);}
            catch (Exception e) { Console.WriteLine(e.Message);}
            Console.WriteLine("To continue, press Enter");
            Console.ReadKey();
        }



    }

}
