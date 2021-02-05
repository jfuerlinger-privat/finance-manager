using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FinanceManager.Api.TagManagement
{
  public static class GetAllTags
  {
    private static readonly string[] _tags = new[] { "Lea", "Joe", "Dani", "Hautarzt", "Zahnarzt", "Kinderarzt" };

    [FunctionName("GetAllTags")]
    public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tags")] HttpRequest req,
            ILogger log)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");
      return new OkObjectResult(_tags);
    }
  }
}
