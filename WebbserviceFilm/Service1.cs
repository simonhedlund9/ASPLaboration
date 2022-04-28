using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebbserviceFilm
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FilmService : IFilmService
    {
        public List<FilmData> GetFilmList()
        {
            try  
            {   
                List<FilmData> returData = new List<FilmData>();
                using (FilmModel db = new FilmModel())
                {
                    var dbFilmLista = db.Films.ToList();
                    foreach (var dbFilm in dbFilmLista)
                    {
                        FilmData returFilm = new FilmData();
                        returFilm.Id = dbFilm.Id;
                        returFilm.Titel = dbFilm.Titel;
                        returFilm.Regissör = dbFilm.Regissör;
                        returFilm.År = dbFilm.År;
                        returData.Add(returFilm);
                    }

                     return returData;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
