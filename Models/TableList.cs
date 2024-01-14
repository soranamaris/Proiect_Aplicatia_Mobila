
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;
using SQLiteNetExtensions.Attributes;


namespace Proiect_Aplicatia_Mobila.Models
{
    public class TableList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

     
        public string Seats { get; set; }

        

        [MaxLength(250), Unique]
        public string Description { get; set; }


        [ForeignKey(typeof(Zone))]
        public int? ZoneID { get; set; }
        public string Zone { get; set; }

        public bool IsSelected { get; set; }


        [ForeignKey(typeof(Reservation))]
        public int? ReservationID { get; set; }
       
        




    }
}
