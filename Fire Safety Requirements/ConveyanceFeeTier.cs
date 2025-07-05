using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Safety_Requirements
{
    public class ConveyanceFeeTier
    {
        public double MaxLimit { get; set; }            // Upper limit for base fee
        public double BaseFee { get; set; }             // Fee up to MaxLimit
        public double? MidLimit { get; set; } = null;   // Optional: second threshold (used in C & D)
        public double? MidChunkSize { get; set; } = null;
        public double? MidChunkFee { get; set; } = null;
        public double? HighChunkSize { get; set; } = null;
        public double? HighChunkFee { get; set; } = null;
        public double? ExcessChunkSize { get; set; } = null; // For A, B, E
        public double? ExcessChunkFee { get; set; } = null;
    }
    public class ConveyanceFeeCalculator
    {
        // Case A – Flammable Liquids in Vehicles (liters)
        public double ComputeFee_CaseA(double liters)
        {
            var tier = new ConveyanceFeeTier
            {
                MaxLimit = 2000,
                BaseFee = 1748,
                ExcessChunkSize = 400,
                ExcessChunkFee = 70
            };

            if (liters <= 0) return 0;
            if (liters <= tier.MaxLimit) return tier.BaseFee;

            double excess = liters - tier.MaxLimit;
            int chunks = (int)Math.Ceiling(excess / tier.ExcessChunkSize.Value);
            return tier.BaseFee + chunks * tier.ExcessChunkFee.Value;
        }

        // Case B – Explosives & Hazardous (kg)
        public double ComputeFee_CaseB(double kilograms)
        {
            var tier = new ConveyanceFeeTier
            {
                MaxLimit = 500,
                BaseFee = 1049,
                ExcessChunkSize = 100,
                ExcessChunkFee = 70
            };

            if (kilograms <= 0) return 0;
            if (kilograms <= tier.MaxLimit) return tier.BaseFee;

            double excess = kilograms - tier.MaxLimit;
            int chunks = (int)Math.Ceiling(excess / tier.ExcessChunkSize.Value);
            return tier.BaseFee + chunks * tier.ExcessChunkFee.Value;
        }

        // Case C – Loading/Unloading (liters or kg)
        public double ComputeFee_CaseC(double qty)
        {
            var tier = new ConveyanceFeeTier
            {
                MaxLimit = 2000,
                BaseFee = 700,
                MidLimit = 40000,
                MidChunkSize = 400,  // or 100 kg
                MidChunkFee = 350,
                HighChunkSize = 4000, // or 1000 kg
                HighChunkFee = 35
            };

            if (qty <= 0) return 0;
            if (qty <= tier.MaxLimit) return tier.BaseFee;

            if (qty <= tier.MidLimit)
            {
                double excess = qty - tier.MaxLimit;
                int chunks = (int)Math.Ceiling(excess / tier.MidChunkSize.Value);
                return tier.BaseFee + chunks * tier.MidChunkFee.Value;
            }
            else
            {
                // Calculate mid excess up to MidLimit
                double midExcess = tier.MidLimit.Value - tier.MaxLimit;
                int midChunks = (int)Math.Ceiling(midExcess / tier.MidChunkSize.Value);

                // High excess beyond MidLimit
                double highExcess = qty - tier.MidLimit.Value;
                int highChunks = (int)Math.Ceiling(highExcess / tier.HighChunkSize.Value);

                return tier.BaseFee + midChunks * tier.MidChunkFee.Value + highChunks * tier.HighChunkFee.Value;
            }
        }

        // Case D – Transfer to Shore Tanks (liters)
        public double ComputeFee_CaseD(double liters)
        {
            var tier = new ConveyanceFeeTier
            {
                MaxLimit = 2000,
                BaseFee = 700,
                MidLimit = 400000,
                MidChunkSize = 400,
                MidChunkFee = 175,
                HighChunkSize = 4000,
                HighChunkFee = 70
            };

            if (liters <= 0) return 0;
            if (liters <= tier.MaxLimit) return tier.BaseFee;

            if (liters <= tier.MidLimit)
            {
                double midExcess = liters - tier.MaxLimit;
                int midChunks = (int)Math.Ceiling(midExcess / tier.MidChunkSize.Value);
                return tier.BaseFee + midChunks * tier.MidChunkFee.Value;
            }
            else
            {
                double midExcess = tier.MidLimit.Value - tier.MaxLimit;
                int midChunks = (int)Math.Ceiling(midExcess / tier.MidChunkSize.Value);

                double highExcess = liters - tier.MidLimit.Value;
                int highChunks = (int)Math.Ceiling(highExcess / tier.HighChunkSize.Value);

                return tier.BaseFee + midChunks * tier.MidChunkFee.Value + highChunks * tier.HighChunkFee.Value;
            }
        }

        // Case E – Bulk Transfer via Lighters/Pipelines (liters)
        public double ComputeFee_CaseE(double liters)
        {
            var tier = new ConveyanceFeeTier
            {
                MaxLimit = 2000,
                BaseFee = 700,
                ExcessChunkSize = 400,
                ExcessChunkFee = 70
            };

            if (liters <= 0) return 0;
            if (liters <= tier.MaxLimit) return tier.BaseFee;

            double excess = liters - tier.MaxLimit;
            int chunks = (int)Math.Ceiling(excess / tier.ExcessChunkSize.Value);
            return tier.BaseFee + chunks * tier.ExcessChunkFee.Value;
        }
    }
    public class InstallationFeeCalculator
    {
        // Case A: Compressed gases (LPG, CNG) > 454L
        public double ComputeFee_CaseA_Gases(double liters)
        {
            const double baseLimit = 454;
            const double baseFee = 280;
            const double excessChunk = 100;
            const double excessFee = 70;

            if (liters <= 0) return 0;
            if (liters <= baseLimit) return baseFee;

            double excess = liters - baseLimit;
            int chunks = (int)Math.Ceiling(excess / excessChunk);

            return baseFee + (chunks * excessFee);
        }

        // Case B: Flammable/combustible liquids in tanks (flat rate)
        public double ComputeFee_CaseB_Tanks()
        {
            return 1049.00;
        }

        // Case C: Equipment/utilities/facilities/fire protection (percentage)
        public double ComputeFee_CaseC_Equipment(double estimatedValue)
        {
            if (estimatedValue <= 0) return 0;
            return estimatedValue * 0.001;  // 0.10%
        }
    }

}
