using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;


namespace Proiect_Aplicatia_Mobila.Models
{
    
    public class Zone
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

    
        public string Name { get; set; }
        public string ImagePath { get; set; }

        // Relație cu mesele
        [OneToMany]
        public List<TableList>? Tables { get; set;}
    }
}
