using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsBackup2
{
    class CopyArchiveKeys 
    {
        protected string archiveLocation;

        public CopyArchiveKeys(string archiveLocation){
            this.archiveLocation = archiveLocation;
        }
        
        //static string storeArchiveKeys = "C:\\code\\visualstudio\\projects\\awsbackup2\\KeyCopy";


        public void copyThis(string storeThis)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(archiveLocation + "keyArchive.txt", true))
            {
                try
                {
                    file.WriteLine(storeThis);
                }
                catch (FileNotFoundException e) 
                {
                    Console.WriteLine("[Data File Mission] {0}", e);
                    throw new FileNotFoundException(@"keyArchive.txt not in " + archiveLocation, e);
                }

                
            }
        }


    }
}
