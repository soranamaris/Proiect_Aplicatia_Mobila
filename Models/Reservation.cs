﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLiteNetExtensions.Attributes;

namespace Proiect_Aplicatia_Mobila.Models
{
     public  class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string? Nume { get; set; }
        

        [ForeignKey(typeof(TableList))]
        public int? TableID { get; set; }


        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }


        [DataType(DataType.Time)]
        public DateTime ReservationTime { get; set; }

        public int ReservationDuration { get; set; }
    }
}
