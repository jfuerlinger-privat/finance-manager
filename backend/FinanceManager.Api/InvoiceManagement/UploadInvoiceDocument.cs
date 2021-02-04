using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FinanceManager.Api.InvoiceManagement
{
  /// <summary>
  /// Idea from https://blog.rasmustc.com/multipart-data-with-azure-functions-httptriggers/
  /// </summary>
  public static class UploadInvoiceDocument
  {
    [FunctionName("UploadInvoiceDocument")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "invoice/upload")] HttpRequest req,
        ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");

      if(!req.ContentType.StartsWith("multipart/form-data"))
      {
        return new BadRequestObjectResult("Content type has to be 'multipart/form-data'!");
      }

      var formdata = await req.ReadFormAsync();

      string name = formdata["name"];
      if (string.IsNullOrEmpty(name))
      {
        return new BadRequestObjectResult("No Name provided!");
      } 

      string[] tags = JsonConvert.DeserializeObject<string[]>(formdata["tags"]);

      if(tags == null)
      {
        return new BadRequestObjectResult("No Tags provided!");
      }

      //var invoice = req.Form.Files["file"];

      // do stuff with data.....

      log.LogInformation($"Name = {name}");
      log.LogInformation($"Tags = {tags.Length}");
      log.LogInformation($"Files = {req.Form.Files.Count}");

      return name != null
          ? (ActionResult)new OkObjectResult($"Thank you (got {req.Form.Files.Count} files).")
          : new BadRequestObjectResult("Sorry didn't get it all....");

    }
  }
}
