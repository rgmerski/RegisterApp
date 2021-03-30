using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp.Model
{
    class Hours
    {
        public string Id { get; set; }
        public string IdDoctor { get; set; }
        public int RoomNumber { get; set; }
        public DateTime Hour { get; set; }
        public bool IsEmpty { get; set; }
    }
}
