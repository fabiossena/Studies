using FDS.StandardsDev.Tools.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace FDS.StandardsDev.Tools.AngularMVC5.Controller
{
    [RoutePrefix("")]
    public class ConfigurationController : ApiController
    {
        static readonly IConfigurationRepository repository = new ConfigurationRepository();

        // GET api/configuration/getall
        [HttpGet]
        public IEnumerable<Configuration> GetAll()
        {
            return repository.GetAll();
        }

        [HttpPost]
        public Configuration Insert(Configuration configuration) // public ActionResult PostConfiguration(Configuration item) //
        {
            return repository.Add(configuration);
        }

        [HttpPut]
        public Configuration Update(Configuration configuration) // public ActionResult PutProduct(int configurationid, Configuration configuration)
        {
            return repository.Update(configuration);
        }


        [HttpGet]
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        //// POST: Default1/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        var test = (Configuration)collection;
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}
