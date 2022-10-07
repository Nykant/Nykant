using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using PdfSharp.Pdf;
using PdfSharp;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Rotativa.AspNetCore;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using StackExchange.Redis;
using System.Net;

namespace NykantMVC.Services
{
    // Code from: https://github.com/aspnet/Entropy/blob/dev/samples/Mvc.RenderViewToString/RazorViewToStringRenderer.cs

    public class RazorViewToStringRenderer : IRazorViewToStringRenderer
    {
        private IRazorViewEngine _viewEngine;
        private ITempDataProvider _tempDataProvider;
        private IServiceProvider _serviceProvider;

        public RazorViewToStringRenderer(
            IRazorViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }



        public async Task<byte[]> PdfSharpConvert<TModel>(string viewName, TModel model, string fileName, ControllerContext context)
        {
            var pdf = await new ViewAsPdf(viewName, model).BuildFile(context);
            var path = Path.Combine("Invoices", $"{fileName}.pdf");
            File.WriteAllBytes(path, pdf);
            await UploadFileAsync(path, fileName, "nykant-invoices");
            return pdf;
        }
        public static async Task UploadFileAsync(string filePath, string keyName, string bucketName)
        {



            // input explained :
            // localFilePath = the full local file path e.g. "c:\mydir\mysubdir\myfilename.zip"
            // bucketName : the name of the bucket in S3 ,the bucket should be alreadt created
            // subDirectoryInBucket : if this string is not empty the file will be uploaded to
            // a subdirectory with this name
            // fileNameInS3 = the file name in the S3

            // create an instance of IAmazonS3 class ,in my case i choose RegionEndpoint.EUWest1
            // you can change that to APNortheast1 , APSoutheast1 , APSoutheast2 , CNNorth1
            // SAEast1 , USEast1 , USGovCloudWest1 , USWest1 , USWest2 . this choice will not
            // store your file in a different cloud storage but (i think) it differ in performance
            // depending on your location
            RegionEndpoint bucketRegion = RegionEndpoint.EUNorth1;
            IAmazonS3 s3Client = new AmazonS3Client(bucketRegion);

            try
            {
                var fileTransferUtility =
                    new TransferUtility(s3Client);

                // Option 2. Specify object key name explicitly.
                await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
                Console.WriteLine("Upload completed");

                File.Delete(filePath);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }

        public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
        {
            var actionContext = GetActionContext();
            var view = FindView(actionContext, viewName);

            using (var output = new StringWriter())
            {
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    new ViewDataDictionary<TModel>(
                        metadataProvider: new EmptyModelMetadataProvider(),
                        modelState: new ModelStateDictionary())
                    {
                        Model = model
                    },
                    new TempDataDictionary(
                        actionContext.HttpContext,
                        _tempDataProvider),
                    output,
                    new HtmlHelperOptions());

                await view.RenderAsync(viewContext);

                return output.ToString();
            }
        }

        private IView FindView(ActionContext actionContext, string viewName)
        {
            var getViewResult = _viewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true);
            if (getViewResult.Success)
            {
                return getViewResult.View;
            }

            var findViewResult = _viewEngine.FindView(actionContext, viewName, isMainPage: true);
            if (findViewResult.Success)
            {
                return findViewResult.View;
            }

            var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
            var errorMessage = string.Join(
                Environment.NewLine,
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations)); ;

            throw new InvalidOperationException(errorMessage);
        }

        private ActionContext GetActionContext()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.RequestServices = _serviceProvider;
            return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        }

    }
    public interface IRazorViewToStringRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
        Task<byte[]> PdfSharpConvert<TModel>(string viewName, TModel model, string fileName, ControllerContext context);
    }
}