using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebbserviceFilm
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFilmService
    {

        [OperationContract]
        List<FilmData> GetFilmList();
        
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public  class FilmData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Titel { get; set; }

        [DataMember]
        public string Regissör { get; set; }

        [DataMember]
        public int År { get; set; }
    }

}
