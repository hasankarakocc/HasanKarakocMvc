//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HkSampleProject.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SampleContext : DbContext
    {
        public SampleContext()
            : base("name=SampleContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abouts> Abouts { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ContactSets> ContactSets { get; set; }
        public virtual DbSet<OtherContacts> OtherContacts { get; set; }
        public virtual DbSet<PortfolioCategories> PortfolioCategories { get; set; }
        public virtual DbSet<PortfolioDetails> PortfolioDetails { get; set; }
        public virtual DbSet<Portfolios> Portfolios { get; set; }
        public virtual DbSet<Pricings> Pricings { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
