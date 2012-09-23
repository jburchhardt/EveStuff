using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveStuff.Model;
using System.ComponentModel;

namespace EveStuff
{

    public enum RaceType
    {
        Caldari = 1,
        Minmatar = 2,
        Amarr = 4,
        Galente = 8,
        ORE = 128
    }

    static public class EveTypeInfoRepository
    {
        static private IDictionary<EveType, EveTypeInfo> allTypes = new Dictionary<EveType, EveTypeInfo>();
        static public EveTypeInfo GetEveTypeInfo(EveType type)
        {
            if (!allTypes.ContainsKey(type))
                allTypes[type] = new EveTypeInfo { BaseType = type };
            return allTypes[type];
        }
    }

    public class EveTypeInfo : INotifyPropertyChanged
    {
        public EveType BaseType { get; set; }
        public string Name { get { return BaseType.Name; } }
        public EveTypeInfo Parent { get { return EveTypeInfoRepository.GetEveTypeInfo(BaseType.Parent); } }
        public string Group { get { return BaseType.Group; } }
        public RaceType Race { get { return (RaceType) RaceType.ToObject(typeof(RaceType), BaseType.RaceID); } }
        public double Price
        {
            get
            {
                return BaseType.Price;
            }
            set
            {
                BaseType.Price = value;
                onPropertyChanged("Price");
            }
        }
 
        public double ReproValue
        {
            get
            {
                if (BaseType.Ingredients == null || BaseType.GroupID == 429 )
                    return BaseType.Price;
                double sum = 0;
                foreach (var ing in BaseType.Ingredients)
                {
                    var info = EveTypeInfoRepository.GetEveTypeInfo(ing.Component);
                    sum += ing.Quantity * info.ReproValue;
                }
                return sum;
            }
        }



        private void onPropertyChanged(string prop)
        {
            var h = PropertyChanged;
            if( h != null)
                h(this, new PropertyChangedEventArgs(prop));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsFrigate { get { return BaseType.GroupID == 25; } }
        public bool IsDestroyer { get { return BaseType.GroupID == 420; } }
        public bool IsCruiser { get { return BaseType.GroupID == 26; } }
        public bool IsBattleCruiser { get { return BaseType.GroupID == 419; } }
        public bool IsBattleship { get { return BaseType.GroupID == 27; } }
        public bool IsIndustrial { get { return BaseType.GroupID == 28; } }
        public bool IsFreighter { get { return BaseType.GroupID == 513; } }

        public bool IsSkiff { get { return BaseType.TypeID == 22546; } }
        public bool IsMackinaw { get { return BaseType.TypeID == 22548; } }
        public bool IsHulk { get { return BaseType.TypeID == 22544; } }
    }

    public class BlueprintInfo
    {
        public Blueprint BaseBlueprint { get; set; }
        public EveTypeInfo Product { get { return EveTypeInfoRepository.GetEveTypeInfo(BaseBlueprint.Product); } }
        public double ExtraProductionPrice
        {
            get
            {
                if (BaseBlueprint.ProductionIngredients == null)
                    return 0;
                double sum = 0;
                foreach (var ing in BaseBlueprint.ProductionIngredients)
                    sum += ing.Quantity * ing.Component.Price;
                return sum;
            }
        }

        public double InventionPrice
        {
            get
            {
                if (BaseBlueprint.InventionIngredients == null)
                    return 0;
                double sum = 0;
                foreach (var ing in BaseBlueprint.InventionIngredients)
                    sum += ing.Quantity * ing.Component.Price;
                return sum;
            }
        }
    }
}