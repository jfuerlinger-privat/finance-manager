using FinanceManager.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinanceManager.Api.Test
{
  [TestClass]
  public class InvoiceManagementTests
  {
    private const string BaseAddress = "http://localhost:7071";

    private static HttpClient GetHttpClient()
    {
      return new HttpClient()
      {
        BaseAddress = new Uri(BaseAddress)
      };
    }

    [TestMethod]
    public void UploadInvoiceDocument_ValidDocuments_ShouldReturnSuccess()
    {
      var fileNames = new[] {
        "2021-01-25 - Eichberger Kinderarzt - Rechnung.pdf",
        "2021-01-25 - Eichberger Kinderarzt - ÖGK.pdf"
      };

      var response = RequestHelper.CreateMultipartRequest(
        $"{BaseAddress}/api/invoice/upload",
        fileNames.Select(fileName => @$".\Invoices\{fileName}").ToArray(),
        new NameValueCollection() {
          { "tags", "[\"Tag1\", \"Tag2\", \"Tag3\"]" },
          { "name", "Joe" }
        });

      Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
    }

    [TestMethod]
    public async Task UploadInvoiceDocument_PerGet_ShouldReturn404()
    {
      HttpClient httpClient = GetHttpClient();

      var response = await httpClient.GetAsync("/api/invoice/upload");

      Assert.IsFalse(response.IsSuccessStatusCode);
      Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
    }

  }
}
