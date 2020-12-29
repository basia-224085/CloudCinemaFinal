using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS.DataRepository
{
    public class Repository
    {
        CloudBDDataContext db = new CloudBDDataContext();
        public List<Movies> getMoviesOfTheDay(int movie_date)
        {
            var list = (from s in db.Schedule where (s.movie_date == movie_date) select s.movie_id).Distinct();
            List<Movies> returnList = new List<Movies>();
            foreach(var s in list)
            {
                returnList.Add(db.Movies.Where(p => p.movie_id == s).First());
            }
            return returnList;
        }
    }
}