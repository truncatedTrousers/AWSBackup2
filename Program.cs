using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Glacier;
using Amazon.Glacier.Transfer;
using Amazon.Runtime;

// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;

namespace AwsBackup2
{
    class Program
    {
        public static void Main(string[] args)
        {
            IAmazonS3 s3Client = AWSClientFactory.CreateAmazonS3Client();

            //Console.Read();
            
            //VVV__temp disabled__VVV
            //UploadFile uf = new UploadFile();
            //uf.runUpload();

            DownloadFile df = new DownloadFile();
            df.runDownload();

//            Connect 
        
        }
    }
}