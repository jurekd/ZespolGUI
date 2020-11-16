using Microsoft.EntityFrameworkCore;
using Projekt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class  MyContext: DbContext
    {
        public virtual DbSet<Zespół> zespolBaza { get; set; }
        public virtual DbSet<CzłonekZespołu> czlonkowieZespolu { get; set; }
        public virtual DbSet<KierownikZespołu> kierownikZespolu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=ZespolNowy;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Server=amber.zarz.agh.edu.pl;Database=cwiczenia;User Id=po;Password=po2020;");
        }
    }
}
