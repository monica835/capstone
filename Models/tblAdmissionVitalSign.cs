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
    
    public partial class tblAdmissionVitalSign
    {
        public int IDVitalSign { get; set; }
        public int IDAdmission { get; set; }
        public System.DateTime Performed { get; set; }
        public string BloodPressure { get; set; }
        public string Temperature { get; set; }
        public string PulseRate { get; set; }
        public string Weight { get; set; }
    }
}
