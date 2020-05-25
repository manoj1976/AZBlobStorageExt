using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
/*using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
*/
namespace BLOBStorageMgmt
{
    public class BLOBStorageMgmt
    {
        private string StorageAccConnectionString{get;set;}
        public BLOBStorageMgmt()
        {

        }

        public BLOBStorageMgmt(string StorageAccConnectionString)
        {
            this.StorageAccConnectionString = StorageAccConnectionString;
        }

        public void DownloadFile(string FiletoDownload, string DestFileName, string AZ_ContainerName)
        {
            Validate();
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.StorageAccConnectionString);
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(@AZ_ContainerName);
            
            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FiletoDownload);
            //if (!blockBlob.Exists())
            //    throw new Exception("File " + FiletoDownload + " not found.");


            // provide the file download location below  
            if (blockBlob.Exists())
            {
                using (var file = System.IO.File.OpenWrite(@DestFileName))
                {
                    blockBlob.DownloadToStream(file);
                }
            }

            
        }
        public void DownloadAndDeleteFile(string FiletoDownload, string DestFileName, string AZ_ContainerName)
        {
            Validate();
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.StorageAccConnectionString);
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(@AZ_ContainerName);

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FiletoDownload);
            //if (!blockBlob.Exists())
            //    throw new Exception("File " + FiletoDownload + " not found.");


            // provide the file download location below            
            if (blockBlob.Exists())
            {
                using (var file = System.IO.File.OpenWrite(@DestFileName))
                {
                    blockBlob.DownloadToStream(file);
                }
                blockBlob.DeleteIfExists();
            }
        }
        public void UploadFile(string SourceFileName, string DestFileName,string AZ_ContainerName)
        {
            Validate();
            if (!System.IO.File.Exists(SourceFileName))
                throw new Exception("File " + SourceFileName + " not found.");
            // Retrieve storage account from connection string.
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=manojstorageac;AccountKey=oof6WRupsTtJZcYDv7+zsRHGKsP2aMAi2HhD6p5OozGuI/A0JAGB96307nQjRhClc9m0KYj54To3zMjIaEublA==;EndpointSuffix=core.windows.net");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.StorageAccConnectionString);
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(@AZ_ContainerName);

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(DestFileName);

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(@SourceFileName))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        public void DeleteFile(string FiletoDelete,  string AZ_ContainerName)
        {
            Validate();
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.StorageAccConnectionString);
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(@AZ_ContainerName);

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FiletoDelete);
            //if (!blockBlob.Exists())
            //    throw new Exception("File " + FiletoDelete + " not found.");
            blockBlob.DeleteIfExists();
        }

        public void RenameFile(string FiletoRename, string NewFiletoRename, string AZ_ContainerName)
        {
            Validate();
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.StorageAccConnectionString);
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(@AZ_ContainerName);

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FiletoRename);
            CloudBlockBlob NewblockBlob = container.GetBlockBlobReference(NewFiletoRename);

            if (blockBlob.Exists())
            {
                NewblockBlob.StartCopy(blockBlob);
                blockBlob.DeleteIfExists();
            }
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(this.StorageAccConnectionString))
                throw new Exception("Please provide the Storage Connection String ");
        }
    }
}
