using HkSampleProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HkSampleProject.Models.ViewModels
{
    public class IndexViewModel
    {
        public Abouts Abouts { get; set; }
        public List<Clients> Clients { get; set; }
        public List<Portfolios> Portfolios { get; set; }
        public List<PortfolioCategories> PortfolioCategories { get; set; }
        public List<Pricings> Pricings { get; set; }
        public ContactSets ContactSets { get; set; }
        public List<OtherContacts> OtherContacts { get; set; }
    }
}