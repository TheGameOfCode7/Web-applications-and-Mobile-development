using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class DatabaseLogModel
    {
        public int DatabaseLogID { get; set; }
        public string DatabaseUser { get; set; }
        public string Event { get; set; }
        public string Schema { get; set; }
        public DateTime PostTime { get; set; }
    }
}
