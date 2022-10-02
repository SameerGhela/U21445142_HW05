﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Students
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public float Class { get; set; }
        public int Point { get; set; }
    }
}