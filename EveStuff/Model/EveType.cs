using System.Collections.Generic;
namespace EveStuff.Model
{

    public class EveType
    {
        public virtual int TypeID { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual int CategoryID { get; set; }
        public virtual int GroupID { get; set; }
        public virtual string Group { get; set; }
        public virtual EveType Parent { get; set; }
        public virtual IList<Ingredient> Ingredients { get; set; }
        public virtual Blueprint Blueprint { get; set; }
        public virtual int RaceID { get; set; }


    }

    public class Blueprint
    {
        public virtual int BlueprintID { get; set; }
        public virtual EveType Product { get; set; }
        public virtual IList<ProductionIngredient> ProductionIngredients { get; set; }
        public virtual IList<InventionIngredient> InventionIngredients { get; set; }

    }

    public class Ingredient
    {
        public virtual int Quantity { get; set; }
        public virtual EveType Component { get; set; }
    }

    public class ProductionIngredient
    {
        public virtual int Quantity { get; set; }
        public virtual EveType Component { get; set; }

    }

    public class InventionIngredient
    {
        public virtual int Quantity { get; set; }
        public virtual EveType Component { get; set; }
    }
}