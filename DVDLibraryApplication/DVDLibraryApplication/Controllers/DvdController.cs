using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDLibraryApplication.Models;
using System.Web.Http.Cors;
using System.Configuration;


namespace DVDLibraryApplication.Controllers
{


    //public class DvdLibraryEntities : DbContext
    //{
    //    public DvdLibraryEntities()
    //        : base("DvdLibrary")
    //    {
    //    }

    //    public DbSet<dvd> Dvds { get; set; }
    //    public DbSet<Director> Directors { get; set; }
    //    public DbSet<Rating> Ratings { get; set; }
    //}


    public class DvdController : ApiController

    {

        private static IDvdRepository _dvdRepository = DvdControllerFactory.GetRepo();
        //// protected static string dbProvider = ConfigurationManager.AppSettings["Mode"].ToString();


        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvds/{select}/{search}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(string search, string select)
        {
            if (select == "Title")
            {
                return Ok(_dvdRepository.GetName(search));
            }
            if (select == "Director") {
                return Ok(_dvdRepository.GetDirector(search));
            }
            if (select == "year")
            {
                return Ok(_dvdRepository.GetYear(search));
            }
            if (select == "Rating")
            {
                return Ok(_dvdRepository.GetRating(search));
            }
            else { return NotFound(); }
        }
        // return Ok(DvdRepoMock.GetAll());
     


        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_dvdRepository.GetAll());
           // return Ok(DvdRepoMock.GetAll());
        }
        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int dvdId)
        {
             dvd movie = _dvdRepository.Get(dvdId);
            //dvd movie = DvdRepoMock.Get(dvdId);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {

           _dvdRepository.Delete(dvdId);
            return Ok(_dvdRepository.GetAll());

           // DvdRepoMock.Delete(dvdId);
           // return Ok(DvdRepoMock.GetAll());


        }
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(EditViewModel model)
        {
            dvd movie = _dvdRepository.Get(model.dvdId);
            if (ModelState.IsValid)
            {

                movie.dvdId = model.dvdId;
                movie.title = model.title;
                movie.rating = model.rating;
                movie.director = model.director;
                movie.realeaseYear = model.realeaseYear;

                _dvdRepository.Edit(movie);
                // DvdRepoMock.Edit(movie);
                
                return Ok(movie);
            }
            else { return NotFound(); }

           // return Ok(DvdRepoMock.GetAll());


        }



        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult New(AddDvdRequest model)
        {
            dvd movie = new dvd();
                
               
           // if (ModelState.IsValid)
           // {

              
                movie.title = model.title;
                movie.rating = model.rating;
                movie.director = model.director;
                movie.realeaseYear = model.realeaseYear;
                movie.notes = model.notes;
                _dvdRepository.Add(movie);

             

                // DvdRepoMock.Edit(movie);

                return Ok(movie);
           // }
           // else { return NotFound(); }

            // return Ok(DvdRepoMock.GetAll());


        }



        //[Route("dvd/{dvdId}")]
        //[AcceptVerbs("POST")]
        //public IHttpActionResult Add(AddDvdRequest request)
        //{


        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    dvd movie = new dvd()
        //    {
        //        title = request.title

        //    };
        //    DvdRepoMock.Add(movie);
        //    return Ok(DvdRepoMock.GetAll());
        //}

    }


}
