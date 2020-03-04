using System;
using System.Collections.Generic;

namespace Assessment6Mock.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int? Age { get; set; }
        public double? Salary { get; set; }
    }
}
