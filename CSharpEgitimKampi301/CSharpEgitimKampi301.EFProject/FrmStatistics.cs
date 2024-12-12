using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
           
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapasity.Text=db.Location.Average(x=>x.Capacity).ToString();
            lblAvgLocationPrice.Text= db.Location.Average(x => (decimal?)x.Price)?.ToString("0.00") + "₺";
            
            int lastCountryId=db.Location.Max(x=>x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappadociaLocationCapacity.Text= db.Location.Where(x=>x.City=="Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text=db.Location.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();
        
            var romeGuideId=db.Location.Where(x=>x.City=="Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text=db.Guide.Where(x=>x.GuideId==romeGuideId)
            .Select(y=>y.GuideName).FirstOrDefault().ToString();
            lblSurName.Text=db.Guide.Where(x => x.GuideId == romeGuideId)
            .Select(y => y.GuideSurname).FirstOrDefault().ToString();

            var maxCapasity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text= db.Location.Where(x=>x.Capacity==maxCapasity).Select(y=>y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text= db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();

            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar")
                .Select(y => y.GuideId).FirstOrDefault();
            lblAysegulLocationCount.Text=db.Location.Where(x=>x.GuideId==guideIdByNameAysegulCinar).Count().ToString(); 
        }

        private void lblSumCapacity_Click(object sender, EventArgs e)
        {

        }

        
    }
}
