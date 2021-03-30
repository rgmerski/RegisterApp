using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp.Model
{
    class DoctorWorkHours
    {
        public string Id { get; set; }
        public string IdDoctor { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime StartWorkingHours { get; set; }
        public DateTime EndWorkingHours { get; set; }
        public int RoomNumber { get; set; }
    }
}
