﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDatabase
{
    public class Course_ProjectEntities : DbContext
    {
        public Course_ProjectEntities()
           : base("workstation id=PMI31CourseProjectDB.mssql.somee.com;packet size=4096;user id=likerrr777_SQLLogin_1;pwd=6fbgpqou9w;data source=PMI31CourseProjectDB.mssql.somee.com;persist security info=False;initial catalog=PMI31CourseProjectDB")
        {
        }

        public DbSet<User> UserContext { get; set; }
        public DbSet<UserInfo> UserInfoContext { get; set; }
        public DbSet<Photo> PhotoContext { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ComplexType<ContactInfo>();
            modelBuilder.ComplexType<GraduateInfo>();
            modelBuilder.ComplexType<Teacher>();

            modelBuilder.Entity<User>().Property(p => p.IsRegistered).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.FullName).IsRequired();

            modelBuilder.Entity<Photo>().Property(p => p.Data).HasColumnType("image");

            modelBuilder.Entity<UserInfo>().HasRequired(p => p.User).WithRequiredDependent(p => p.UserInfo);
            modelBuilder.Entity<Photo>().HasRequired(p => p.UserInfo).WithRequiredDependent(p => p.Photo);
        }
    }
}
