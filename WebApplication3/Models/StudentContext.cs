using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;


namespace WebApplication3.Models
{
    public partial class StudentContext : DbContext
    {
        public StudentContext() { }
        public virtual DbSet<Student> Students { get; set; }
    }
}