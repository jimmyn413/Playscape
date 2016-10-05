using Playscape.Models;
using Playscape.Models.Domain;
using Playscape.Models.Requests;
using Sabio.Data;
using Playscape.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playscape.Services
{
    class EventsService : BaseService
    {
        public static int Post(EventsRequest model)
        {
            int outputId = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Events_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", model.UserId);
                   paramCollection.AddWithValue("@EventType", model.EventType);
                   paramCollection.AddWithValue("@IsPublic", model.IsPublic);
                   paramCollection.AddWithValue("@Title", model.Title);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Start", model.Start);
                   paramCollection.AddWithValue("@Duration", model.Duration);
                   paramCollection.AddWithValue("@MediaId", model.MediaId);
                   paramCollection.AddWithValue("@NumberAttendees", model.NumberAttendees);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out outputId);
               }
               );


            return outputId;
        }




        public static List<Events> Get(Events model)
        {
            List<Events> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Events_SelectAll"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {


               }, map: delegate (IDataReader reader, short set) //executes after stored proc
               {
                   Events p = new Events();
                   int startingIndex = 0; //startingOrdinal

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.UserId = reader.GetSafeString(startingIndex++);
                   p.EventType = reader.GetSafeInt32(startingIndex++);
                   p.IsPublic = reader.GetSafeBool(startingIndex++);
                   p.Title = reader.GetString(startingIndex++);
                   p.Description = reader.GetSafeString(startingIndex++);
                   p.CreateDate = reader.GetSafeDateTime(startingIndex++);
                   p.ModifiedDate = reader.GetSafeDateTime(startingIndex++);
                   p.Start = reader.GetSafeDateTime(startingIndex++);
                   p.Duration = reader.GetSafeInt32(startingIndex++);
                   p.MediaId = reader.GetSafeInt32(startingIndex++);
                   p.NumberAttendees = reader.GetSafeInt32(startingIndex++);


                   if (list == null)
                   {
                       list = new List<Events>();
                   }
                   list.Add(p);
               }
               );
            return list;
        }





        public static void Put(int Id, EventsUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Events_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", model.Id);
                   paramCollection.AddWithValue("@EventType", model.EventType);
                   paramCollection.AddWithValue("@IsPublic", model.IsPublic);
                   paramCollection.AddWithValue("@Title", model.Title);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Start", model.Start);
                   paramCollection.AddWithValue("@Duration", model.Duration);
                   paramCollection.AddWithValue("@MediaId", model.MediaId);
                   paramCollection.AddWithValue("@NumberAttendees", model.NumberAttendees);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
               }
               );
        }




        public static void Delete(int Id)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Events_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", Id);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
               }
               );
        }




    }
}
