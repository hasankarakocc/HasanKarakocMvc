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
    using System.Collections.Generic;
    
    public partial class PortfolioDetails
    {
        public int PortfolioId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string ProjectUrl { get; set; }
    
        public virtual Portfolios Portfolios { get; set; }
    }
}
