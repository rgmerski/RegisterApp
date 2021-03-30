using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp.Model
{
    class Patient
    {
        public string Id { get; set; }
        public string PESEL { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Registrations { get; set; }
    }
}
