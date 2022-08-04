using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace.Models
{
    [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {
        static List<Country> countryList = new List<Country>()
        {
            new Country{ID = 1,Name="India",Capital ="Delhi"},
            new Country{ID =2,Name = "japan",Capital="Tokyo"},
            new Country{ID=3,Name ="America",Capital="washington Dc"},
            new Coutry{ID=4,Name="England",Capital="London" },
        };
        //GET Methods
        [HttpGet]
        public List<Country> Get()
        {
            return countryList;
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetCountryById(int id)
        {
            CountryController countryObj = countryList.Find(item => item.ID == id);
            if (countryObj == null)
            {
                return Request.CreateResponse(HttpStatusCodeResult.NotFound, id);
            }
            return RequestNotification.CreateResponse(HttpStatusCodeResult.OK, countryObj);
        }
        [HttpGet]
        [Route("CountryName/{name}")]
        public HttpResponseMessage GetByCountryName(string name)
        {
            CountryController countryObj = countryList.Find(item => item.Name.equals(name));
            if (countryObj == null)
            {
                return RequestNotification.CreateResponse(HttpStatusCodeResult.NotFound, name);
            }
            return Request.CreateResponse(HttpStatusCodeResult.Ok, countryObj)
        }
        [HttpGet]
        [Route("NameById/{id}")]
        public IHttpActionResult GetCountryNameById(int id)
        {
            Country countryObj = countryList.Find(item => item.Capital.Equals(capital));
            if (countryObj == null)
            {
                return Request.CreateResponse(HttpStatusCodeResult.NotFound, capital);
            }
            return Request.CreateResponse(HttpStatusCodeResult.OK, countryObj);
        }
        [HttpGet]
        [Route("NAmeById/{id}")]
        public IHttpActionResult GetCountryNameById(int id)
        {
            Country obj = countryList.Find(item => item.ID == id);
            if (obj != null)
            {
                return Ok(obj.Name);
            }
            retuen NotFound();
        }
        [HttpPost]
        public List<Country> Post([FromBody]) Country obj)
             {

            CountryList.Add(obj);
            return countryList;
        }
    [HttpPut]
    [Route("{id}")]
    public IHttpActionResult Put([FromBody] CountryController newObj)
    {
        CountryController oldObj = countryList.Find(Item => Item.ID == newObj.Id);
        if(oldObj!=null)
        {
            int index = countryList.IndexOf(oldObj);
            countryList.Remove(oldObj);
            countryList = Insert(index, newObj);
            return OK();
        }
        return DllNotFound();


    }
    [HttpDelete]
    [Route"(id)"]
    public IHttpActionResult Delete(int id)
    {
        CountryController Obj = countryList.Find(Item => Item.id == id);
        if(Obj!=null)
        {
            bool isRemoved = countryList.Remove(Obj);
            if(isRemoved)
            {
                return Ok(Obj)
            }
            return NotFound();
        }
    }

}





