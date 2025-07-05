using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Safety_Requirements
{
    public class ElectricalItems
    {
        public double FromKva { get; set; }
        public double ToKva { get; set; }
        public double BaseAmount { get; set; }
        public double RatePerKva { get; set; }


        public double GetElectricalAmount(double kva)
        {
            var pricingTiers = new List<ElectricalItems>
    {
        new() { FromKva = 1, ToKva = 5, BaseAmount = 100, RatePerKva = 0 },
        new() { FromKva = 5, ToKva = 50, BaseAmount = 100, RatePerKva = 10 },
        new() { FromKva = 50, ToKva = 300, BaseAmount = 550, RatePerKva = 5 },
        new() { FromKva = 300, ToKva = 1500, BaseAmount = 1800, RatePerKva = 5 },
        new() { FromKva = 1500, ToKva = 6000, BaseAmount = 4800, RatePerKva = 2.5 },
        new() { FromKva = 6000, ToKva = double.MaxValue, BaseAmount = 8425, RatePerKva = 1.25 }
    };

            var tier = pricingTiers.FirstOrDefault(t => kva > t.FromKva && kva <= t.ToKva);

            if (tier is null)
                return Math.Round(pricingTiers[0].BaseAmount, 2); // fallback for < 1 KVA

            double total = tier.BaseAmount + (tier.RatePerKva * kva);
            return Math.Round(total, 2);
        }

    }
}
