//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblINECVotersRegister
    {
        public Nullable<int> StateId { get; set; }
        public Nullable<int> LGAId { get; set; }
        public Nullable<int> WardId { get; set; }
        public Nullable<int> PollingBoothId { get; set; }
        public string Delim { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string VIN { get; set; }
        public string PassportPhoto { get; set; }
        public string YearOfBirth { get; set; }
        public string Gender { get; set; }
        public int VotersRegisterID { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Occupation { get; set; }
    }
}
