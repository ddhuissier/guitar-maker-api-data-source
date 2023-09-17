using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace StarterKitAPI.Controllers
{
    public class MetaController : BaseApiController
    {
        // Health check
        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Program).Assembly;

            var lastUpdate = System.IO.File.GetLastWriteTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {lastUpdate}");
        }
    }
}
