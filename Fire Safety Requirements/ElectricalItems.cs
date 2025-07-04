using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Safety_Requirements
{
    public class ElectricalItems
    {
        double _from_kva, _to_kva, _amount, _per_kva;
        double amnt_per_kg, max_amnt;
        string adminfinecode;
        public double from_kva
        {
            get { return _from_kva; }
            set { _from_kva = value; }
        }
        public double to_kva
        {
            get { return _to_kva; }
            set { _to_kva = value; }
        }
        public double amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public double per_kva
        {
            get { return _per_kva; }
            set { _per_kva = value; }
        }
        public double GetElectricalAmount(double n)
        {
            List<ElectricalItems> electrical = new List<ElectricalItems>()
            {
                new ElectricalItems() { from_kva = 1, to_kva = 5, amount = 100, per_kva = 0 },
                new ElectricalItems() { from_kva = 5, to_kva = 50, amount = 100, per_kva = 10 },
                new ElectricalItems() { from_kva = 50, to_kva = 300, amount = 550, per_kva = 5 },
                new ElectricalItems() { from_kva = 300, to_kva = 1500, amount = 1800, per_kva = 5 },
                new ElectricalItems() { from_kva = 1500, to_kva = 6000, amount = 4800, per_kva = 2.5 },
                new ElectricalItems() { from_kva = 6000, to_kva = double.MaxValue, amount = 8425, per_kva = 1.25 }
            };

            int lastIndex = electrical.Count - 1;

            if (n < electrical[0].from_kva)
                return Math.Round(electrical[0].amount, 2);

            if (n >= electrical[lastIndex].from_kva)
            {
                var item = electrical[lastIndex];
                double result = ((n - item.from_kva) * item.per_kva) + item.amount;
                return Math.Round(result, 2);
            }

            foreach (var item in electrical)
            {
                if (n >= item.from_kva && n <= item.to_kva)
                {
                    double result = ((n - item.from_kva) * item.per_kva) + item.amount;
                    return Math.Round(result, 2);
                }
            }

            // fallback (should not be reached)
            return 0;
        }

    }
}
