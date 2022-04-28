using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FuncBlob
{
    public class UpdateBlob
    {
        [FunctionName("UpdateBlob")]
        public void Run([BlobTrigger("samples-workitems/{name}", Connection = "STORAGE_CONNECTION")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
