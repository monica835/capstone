//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Icarus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblResidentActivity
    {
        public int IDResidentActivityLog { get; set; }
        public System.DateTime LogDate { get; set; }
        public int IDAdmission { get; set; }
        public string Position { get; set; }
        public string Activity { get; set; }
        public string PostedBy { get; set; }
    }
}