﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectionICR.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CMSDBEntities : DbContext
    {
        public CMSDBEntities()
            : base("name=CMSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserTbl> UserTbls { get; set; }
        public virtual DbSet<tblLGA> tblLGAs { get; set; }
        public virtual DbSet<tblState> tblStates { get; set; }
        public virtual DbSet<tblWard> tblWards { get; set; }
        public virtual DbSet<tblINECVotersRegister> tblINECVotersRegisters { get; set; }
        public virtual DbSet<tblElectionResult> tblElectionResults { get; set; }
        public virtual DbSet<tblPoliticalParty> tblPoliticalParties { get; set; }
        public virtual DbSet<tblPollingBooth> tblPollingBooths { get; set; }
    }
}