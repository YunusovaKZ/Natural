﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Natural
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NaturelEntities : DbContext
    {
        public NaturelEntities()
            : base("name=NaturelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Cosmetic> Cosmetic { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}