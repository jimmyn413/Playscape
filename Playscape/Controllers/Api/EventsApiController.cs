using Playscape.Models;
using Playscape.Models.Domain;
using Playscape.Models.Requests;
using Playscape.Services;
using Sabio.Web.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Playscape.Controllers.Api
{
    [RoutePrefix("api/events")]
    public class EventsApiController : ApiController
    {

        [Route, HttpPost]
        public HttpResponseMessage Post(EventsRequest model)
        {

            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request payload was null");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //model.UserId = UserService.GetCurrentUserId();

            //post new event basic info
            int Id = EventsService.Post(model);

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = Id;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }




        [Route, HttpGet]
        public HttpResponseMessage Get(Events model)
        {
            List<Events> eventsData = EventsService.Get(model);

            ItemsResponse<Events> response = new ItemsResponse<Events>();

            response.Items = eventsData;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }




        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Put(int Id, EventsUpdateRequest model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request payload was null");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //model.UserId = UserService.GetCurrentUserId();

            EventsService.Put(Id, model);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }




        [Route("{id:int}"), HttpDelete]
        public void Delete(int Id)
        {
            EventsService.Delete(Id);
        }





    }
}
