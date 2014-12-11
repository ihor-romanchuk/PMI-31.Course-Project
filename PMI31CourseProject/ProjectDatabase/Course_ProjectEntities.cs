using System;
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
        /// <summary>
        /// Initialize a new instance of the <see cref="Course_ProjectEntities"/> class.
        /// </summary>
        public Course_ProjectEntities()
           : base("workstation id=PMI31CourseProjectDB.mssql.somee.com;packet size=4096;user id=likerrr777_SQLLogin_1;pwd=6fbgpqou9w;data source=PMI31CourseProjectDB.mssql.somee.com;persist security info=False;initial catalog=PMI31CourseProjectDB")
        {
        }

        /// <summary>
        /// Gets or sets UserContext of Course_ProjectEntities.
        /// </summary>
        public DbSet<User> UserContext { get; set; }

        /// <summary>
        /// Gets or sets UserInfoContext of Course_ProjectEntities.
        /// </summary>
        public DbSet<UserInfo> UserInfoContext { get; set; }

        /// <summary>
        /// Gets or sets PhotoContext of Course_ProjectEntities.
        /// </summary>
        public DbSet<Photo> PhotoContext { get; set; }

        /// <summary>
        /// Creates new instance of DbModelBuilder.
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder value.</param>
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
