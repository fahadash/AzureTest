using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace TestMvcService.Controllers
{
    [RoutePrefix("api/v1/amzi")]
    public class AmziController : ApiController
    {
        [HttpGet]
        [Route("version")]
        public IHttpActionResult Version()
        {
            return Ok("Version 1.0");
        }
        [HttpGet]
        [Route("dir")]
        public IHttpActionResult dir()
        {
            return Ok(Directory.GetCurrentDirectory());
        }

        [HttpGet]
        [Route("assemblydir")]
        public IHttpActionResult asmdir()
        {
            var dir = Path.GetDirectoryName((Assembly.GetExecutingAssembly().Location));
            var contents = Directory.GetFiles(dir).Concat(Directory.GetDirectories(dir));

            return Ok(new { Directory = dir, Contents = contents });
        }

        [HttpGet]
        [Route("bitness")]
        public IHttpActionResult bitness()
        {

            return Ok(IntPtr.Size.ToString());
        }

        [HttpGet]
        [Route("appdomaindir")]
        public IHttpActionResult appdomaindir()
        {
            string binDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin");
            var contents = Directory.GetFiles(binDir).Concat(Directory.GetDirectories(binDir));

            return Ok(new { Directory = binDir, Contents = contents });
        }

        [HttpGet]
        [Route("path")]
        public IHttpActionResult path()
        {
            string path = Environment.GetEnvironmentVariable("PATH");

            return Ok(path);
        }

        [HttpGet]
        [Route("test")]

        public IHttpActionResult Test()
        {
            var test = new PrologTest.Test();

            return Ok(test.TestSimple());

            //return Ok();
        }

    }
}