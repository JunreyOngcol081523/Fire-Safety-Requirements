using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Safety_Requirements
{
    public class StorageItems
    {
        double _from_value, _to_value, _amount;
        List<StorageItems> storageitems = new List<StorageItems>();
        public double from_value
        {
            get { return _from_value; }
            set { _from_value = value; }
        }
        public double to_value
        {
            get { return _to_value; }
            set { _to_value = value; }
        }
        public double amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public StorageItems()
        {

        }

        // a. Flammable/Combustible Solids
        public void StorageFlammableCombustibleSolids_1()//Calcium carbide
        {
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 40.0, to_value = 80.0, amount = 49.0 });
            storageitems.Add(new StorageItems() { from_value = 80.0, to_value = 200.0, amount = 63.0 });
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 2000.0, amount = 126.0 });
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 4000.0, amount = 189.0 });
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 20000.0, amount = 252.0 });
            storageitems.Add(new StorageItems() { from_value = 20000.0, to_value = 40000.0, amount = 315.0 });
            storageitems.Add(new StorageItems() { from_value = 40000.0, to_value = 200000.0, amount = 472.0 });
            storageitems.Add(new StorageItems() { from_value = 200000.1, to_value = 200000.1, amount = 630.0 });

        }
        public void StorageFlammableCombustibleSolids_2()//Pyroxylin
        {
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 40.0, to_value = 200.0, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 800.0, amount = 84.0 });
            storageitems.Add(new StorageItems() { from_value = 800.0, to_value = 2000.0, amount = 168.0 });
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 4000.0, amount = 315.0 });
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 12000.0, amount = 630.0 });
            storageitems.Add(new StorageItems() { from_value = 12000.0, to_value = 40000.0, amount = 1049.0 });
            storageitems.Add(new StorageItems() { from_value = 40000.1, to_value = 40000.1, amount = 2097.0 });
        }
        public void StorageFlammableCombustibleSolids_3()
        //Matches
        {
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 100.0, to_value = 400.0, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 400.0, to_value = 2000.0, amount = 210.0 });
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 4000.0, amount = 420.0 });
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 20000.0, amount = 839.0 });
            storageitems.Add(new StorageItems() { from_value = 20000.1, to_value = 20000.1, amount = 1678.0 });

        }
        public void StorageFlammableCombustibleSolids_4()
        //Nitrate, phosphorous, bromine, sodium, picric acid and other hazardous chemicals of similar flammable, explosive, oxidizing or lacrymatory properties
        {
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 20.0, to_value = 100.0, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 100.0, to_value = 400.0, amount = 63.0 });
            storageitems.Add(new StorageItems() { from_value = 400.0, to_value = 2000.0, amount = 158.0 });
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 4000.0, amount = 315.0 });
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 20000.0, amount = 460.0 });
            storageitems.Add(new StorageItems() { from_value = 20000.1, to_value = 20000.1, amount = 460.0 });

        }
        public void StorageFlammableCombustibleSolids_5()
        {
            //Shredded combustible materials, such as wood shaving / excelsior(kusot),
            //sawdust, kapok, straw and hay; combustible loose fibers: cotton waste(estopa),
            //sisal, oakum; and other similar combustible shavings and fine materials:
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 0.25, to_value = 3.0, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 3.0, to_value = 14.0, amount = 112.0 });
            storageitems.Add(new StorageItems() { from_value = 14.0, to_value = 28.0, amount = 189.0 });
            storageitems.Add(new StorageItems() { from_value = 28.0, to_value = 70.0, amount = 315.0 });
            storageitems.Add(new StorageItems() { from_value = 70.1, to_value = 70.1, amount = 486.0 });


        }
        public void StorageFlammableCombustibleSolids_6()
        {
            //Tar, resin, waxes, copra, rubber, cork, bituminous coal and similar combustible materials:
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 400.0, amount = 49.0 });
            storageitems.Add(new StorageItems() { from_value = 401.0, to_value = 4000.0, amount = 98.0 });
            storageitems.Add(new StorageItems() { from_value = 4001.0, to_value = 20000.0, amount = 189.0 });
            storageitems.Add(new StorageItems() { from_value = 20000.1, to_value = 20000.1, amount = 315.0 });
        }

        //b. flammable/combustible liquids
        public void StorageFlammableCombustibleLiquids_1()
        {
            //            For flammable liquids having flashpoint of -6.67oC or below, such as gasoline,
            //ether, carbon bisolphide, naptha, benzol (benzene), collodion, aflodin and
            //acetone.
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 20.0, to_value = 100.0, amount = 35.0 });            //0
            storageitems.Add(new StorageItems() { from_value = 100.0, to_value = 200.0, amount = 42.0 });           //1
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 400.0, amount = 84.0 });           //2
            storageitems.Add(new StorageItems() { from_value = 400.0, to_value = 2000.0, amount = 168.0 });//3
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 4000.0, amount = 252.0 });//4
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 6000.0, amount = 350.0 });//5
            storageitems.Add(new StorageItems() { from_value = 6000, to_value = 8000.0, amount = 420.0 });//6
            storageitems.Add(new StorageItems() { from_value = 8000, to_value = 10000.0, amount = 504.0 });//7
            storageitems.Add(new StorageItems() { from_value = 10000, to_value = 12000.0, amount = 672.0 });//8
            storageitems.Add(new StorageItems() { from_value = 12000, to_value = 14000.0, amount = 839.0 });//9
            storageitems.Add(new StorageItems() { from_value = 14000, to_value = 16000.0, amount = 1007.0 });//10
            storageitems.Add(new StorageItems() { from_value = 16000, to_value = 32000.0, amount = 1259.0 });//11
            storageitems.Add(new StorageItems() { from_value = 32000, to_value = 40000.0, amount = 1678.0 });//12
            storageitems.Add(new StorageItems() { from_value = 40000, to_value = 200000.0, amount = 2517.0 });//13
            storageitems.Add(new StorageItems() { from_value = 200000, to_value = 800000.0, amount = 3775.0 });//14
            storageitems.Add(new StorageItems() { from_value = 800000, to_value = 2000000.0, amount = 5033.0 });//15
            storageitems.Add(new StorageItems() { from_value = 2000000, to_value = 6000000.0, amount = 6711.0 });//16
            storageitems.Add(new StorageItems() { from_value = 6000000, to_value = 8000000.0, amount = 8388.0 });//17
            storageitems.Add(new StorageItems() { from_value = 8000000.1, to_value = 400, amount = 4.0 });//18
        }
        public void StorageFlammableCombustibleLiquids_2()
        {
            //            For flammable liquids having flashpoint of above - 6.67oC and below 22.8 oC such
            //as alcohol, amyl, toluol, ethyl, acetate and like.
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 20.0, to_value = 100.0, amount = 32.0 });
            storageitems.Add(new StorageItems() { from_value = 100.0, to_value = 200.0, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 400.0, amount = 63.0 });
            storageitems.Add(new StorageItems() { from_value = 400.0, to_value = 2000.0, amount = 105.0 });
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 4000.0, amount = 168.0 });
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 20000.0, amount = 350.0 });
            storageitems.Add(new StorageItems() { from_value = 20000, to_value = 100000.0, amount = 839.0 });
            storageitems.Add(new StorageItems() { from_value = 100000, to_value = 200000.0, amount = 1678.0 });
            storageitems.Add(new StorageItems() { from_value = 200000.1, to_value = 200000.1, amount = 2097.0 });

        }
        public void StorageFlammableCombustibleLiquids_3()
        {
            //            For liquids having flashpoint of 22.8 oC to 93.3 oC, such as kerosene, turpentine,
            //thinner, prepared paints, varnish, diesel oil, fuel oil, kerosene, cleansing solvent,
            //polishing liquids and similar
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 20.0, to_value = 100.0, amount = 18.0 });
            storageitems.Add(new StorageItems() { from_value = 100.0, to_value = 200.0, amount = 28.0 });
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 400.0, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 400.0, to_value = 4000.0, amount = 105.0 });
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 20000.0, amount = 315.0 });
            storageitems.Add(new StorageItems() { from_value = 20000.0, to_value = 40000.0, amount = 420.0 });
            storageitems.Add(new StorageItems() { from_value = 40000.0, to_value = 200000.0, amount = 630.0 });
            storageitems.Add(new StorageItems() { from_value = 200000.0, to_value = 400000.0, amount = 1049.0 });
            storageitems.Add(new StorageItems() { from_value = 400000.0, to_value = 2000000.0, amount = 1678.0 });
            storageitems.Add(new StorageItems() { from_value = 2000000.0, to_value = 3600000, amount = 1748.0 });
            storageitems.Add(new StorageItems() { from_value = 3600000.1, to_value = 3600000.1, amount = 2098.0 });
        }
        public void StorageFlammableCombustibleLiquids_4()
        {
            //            For combustible liquids having flash point greater than 93.3 oC that is subject to
            //spontaneous ignition or is artificially heated to a temperature equal to or higher
            //than its flash point, such as crude oil, petroleum oil and others.
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 20.0, to_value = 100.0, amount = 18.0 });
            storageitems.Add(new StorageItems() { from_value = 100.0, to_value = 200.0, amount = 28.0 });
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 400.0, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 400.0, to_value = 2000.0, amount = 84 });
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 4000.0, amount = 105.0 });
            storageitems.Add(new StorageItems() { from_value = 4000.0, to_value = 80000.0, amount = 315.0 });
            storageitems.Add(new StorageItems() { from_value = 80000.1, to_value = 80000.1, amount = 630.0 });

        }

        //c. flammable gases
        //Liquefied Petroleum Gas (LPG) in liter water capacity
        public void StorageFlammableGases_1a()//For bulk storage
        {
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 1.0, to_value = 200.0, amount = 70.0 });
            storageitems.Add(new StorageItems() { from_value = 200.0, to_value = 2000.0, amount = 140.0 });
            storageitems.Add(new StorageItems() { from_value = 2000.0, to_value = 8000.0, amount = 280.0 });
            storageitems.Add(new StorageItems() { from_value = 8000.0, to_value = 20000.0, amount = 699.0 });
            storageitems.Add(new StorageItems() { from_value = 20000.0, to_value = 200000.0, amount = 1398.0 });
            storageitems.Add(new StorageItems() { from_value = 200000.0, to_value = 400000.0, amount = 5592.0 });
            storageitems.Add(new StorageItems() { from_value = 400000.1, to_value = 4000.0, amount = 35.0 });

        }
        public void StorageFlammableGases_1b()//For other than bulk storage
        {
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 1.0, to_value = 60.0, amount = 6.0 });
            storageitems.Add(new StorageItems() { from_value = 60, to_value = 100, amount = 7.0 });
            storageitems.Add(new StorageItems() { from_value = 100, to_value = 200, amount = 11.0 });
            storageitems.Add(new StorageItems() { from_value = 200, to_value = 400, amount = 14.0 });
            storageitems.Add(new StorageItems() { from_value = 400, to_value = 800, amount = 28.0 });
            storageitems.Add(new StorageItems() { from_value = 800, to_value = 1200, amount = 42.0 });
            storageitems.Add(new StorageItems() { from_value = 1200, to_value = 2000, amount = 56.0 });
            storageitems.Add(new StorageItems() { from_value = 2000.1, to_value = 400, amount = 4.0 });

        }
        //Other flammable gases in liter water capacity
        public void StorageFlammableGases_2()
        {
            storageitems.Clear();
            storageitems.Add(new StorageItems() { from_value = 20, to_value = 100, amount = 21 });
            storageitems.Add(new StorageItems() { from_value = 100, to_value = 400, amount = 42 });
            storageitems.Add(new StorageItems() { from_value = 400, to_value = 2000, amount = 126 });
            storageitems.Add(new StorageItems() { from_value = 2000, to_value = 8000, amount = 252 });
            storageitems.Add(new StorageItems() { from_value = 8000, to_value = 40000, amount = 630 });
            storageitems.Add(new StorageItems() { from_value = 40000, to_value = 200000, amount = 1259 });
            storageitems.Add(new StorageItems() { from_value = 200000, to_value = 400000, amount = 1888 });
            storageitems.Add(new StorageItems() { from_value = 400000.1, to_value = 40000.1, amount = 3146 });

        }
        public double getAmount(double n)
        {
            if (n >= storageitems[0].from_value)
            {
                for (int i = 0; i < storageitems.Count(); i++)
                {
                    if (n >= storageitems[i].from_value && n <= storageitems[i].to_value)
                    {
                        return storageitems[i].amount;
                    }

                }
                return storageitems[storageitems.Count() - 1].amount;
            }
            else
            {
                return storageitems[0].amount;
            }

        }
        public double getAmountwithExcess(double n)
        {
            if (n >= storageitems[0].from_value)
            {
                if (n >= storageitems[storageitems.Count() - 1].from_value)
                {
                    double myval = n;
                    double amnt_per_ltr = storageitems[storageitems.Count() - 1].amount;
                    double amnt_to_divide = storageitems[storageitems.Count() - 1].to_value;
                    double amnt_to_be_added = storageitems[storageitems.Count() - 2].amount;
                    double val_capacity = storageitems[storageitems.Count() - 2].to_value;
                    double result = (Math.Ceiling((myval - val_capacity) / amnt_to_divide) * amnt_per_ltr) + amnt_to_be_added;
                    return result;
                }
                else
                {
                    for (int i = 0; i < storageitems.Count(); i++)
                    {
                        if (n >= storageitems[i].from_value && n <= storageitems[i].to_value)
                        {
                            return storageitems[i].amount;
                        }

                    }
                    return storageitems[storageitems.Count() - 1].amount;
                }

            }
            return storageitems[0].amount;

        }
    }
}
