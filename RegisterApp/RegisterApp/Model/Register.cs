using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp.Model
{
    class Register
    {
        public string Id { get; set; }
        public string IdDoctor { get; set; }
        public string IdPatient { get; set; }
        public object Doctor { get; set; }
        public int RoomNumber { get; set; }
        public object Patient { get; set; }
        public DateTime Hour { get; set; }
    }
}
