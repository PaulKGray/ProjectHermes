using System.Web;
using System.Web.Optimization;
using dotless.Core;
using ProjectHermes.App_Start;

namespace ProjectHermes
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
           




        }


        /// <summary>
        /// .Less Tranformer.
        /// </summary>
        class CssTransformer : IBundleTransform
        {
          public void Process(BundleContext context, BundleResponse response)
          {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
          }
        }
    }
}