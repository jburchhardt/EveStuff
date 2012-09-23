using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveStuff.Model;

namespace EveStuff
{

    public class InventionConfiguration
    {
        public double InventionProbability { get; private set; }
        public double ItemsPerBlueprint { get; private set; }

        public double ProductionCostPerItem { get; private set; }
        public double InventionCostPerItem { get; private set; }
        public double CostPerItem { get; private set; }

        public double InventionItemsPerWeek { get; private set; }
        public double CopyItemsPerWeek { get; private set; }
        public double FinancedItemsPerWeek { get; private set; }
        public double ItemsPerWeek { get; private set; }

        public string ItemsPerWeekExp { get; private set; }

        public double Profit { get; private set; }
        public double ProfitPerWeek { get; private set; }
        public double Margin { get; private set; }

 
        public Decryptor Decrypt { get; set; }
        public BlueprintInfo Blueprint { get; set; }
        public bool IsMaxRuns { get; set; }

        public InventionConfiguration() { }

        public void CalculateStuff()
        {
            var traits = InventionTraits.GetInventionTraits(Blueprint);

            InventionProbability = traits.BaseProbability * 1.05 * 1.2 * Decrypt.Traits.ProbabilityModifier;
            ItemsPerBlueprint = InventionProbability * ((IsMaxRuns ? 1 : 0) + Decrypt.Traits.RunsModifier);
            
            ProductionCostPerItem = (Blueprint.Product.ReproValue - Blueprint.Product.Parent.ReproValue) * (1.1 - 0.1 * Decrypt.Traits.MaterialLevelModifier) + Blueprint.ExtraProductionPrice;
            InventionCostPerItem = Blueprint.InventionPrice / ItemsPerBlueprint;
            CostPerItem = InventionCostPerItem + ProductionCostPerItem;

            InventionItemsPerWeek = traits.InventionSlotsPerWeek * ItemsPerBlueprint;
            CopyItemsPerWeek = traits.CopiesPerWeek * ItemsPerBlueprint;
            FinancedItemsPerWeek = 2e9 / CostPerItem;
            if (IsMaxRuns)
                CopyItemsPerWeek /= traits.MaxRuns;
            if (InventionItemsPerWeek < CopyItemsPerWeek)
            {
                ItemsPerWeek = InventionItemsPerWeek;
                ItemsPerWeekExp = String.Format(@"{0:f} invented", ItemsPerWeek);
            }
            else
            {
                ItemsPerWeek = CopyItemsPerWeek;
                ItemsPerWeekExp = String.Format(@"{0:f} copied", ItemsPerWeek);
            }

            if (FinancedItemsPerWeek < ItemsPerWeek)
            {
                ItemsPerWeek = FinancedItemsPerWeek;
                ItemsPerWeekExp = String.Format(@"{0:f} financed", ItemsPerWeek);
            }

            Profit = Blueprint.Product.Price - CostPerItem;
            Margin = 100 * Profit / CostPerItem;
            ProfitPerWeek = ItemsPerWeek * Profit;
        }
 
    }

    public class InventionManager
    {
        public BlueprintInfo Blueprint { get; set; }
        public IList<InventionConfiguration> Configurations { get; private set; }
        public InventionConfiguration BestMarginConfiguration { get; private set; }
        public InventionConfiguration BestProfitConfiguration { get; private set; }

        private void addConfiguration(InventionConfiguration cfg)
        {
            cfg.CalculateStuff();
            if (BestMarginConfiguration == null || cfg.Margin > BestMarginConfiguration.Margin)
                BestMarginConfiguration = cfg;
            if (BestProfitConfiguration == null || cfg.ProfitPerWeek > BestProfitConfiguration.ProfitPerWeek)
                BestProfitConfiguration = cfg;
            Configurations.Add(cfg);
        }

        public void CalculateStuff()
        {
            var decryptors = Decryptor.RacialDecryptors[Blueprint.Product.Race];
            foreach (var decryptor in decryptors)
            {
                addConfiguration(new InventionConfiguration { Blueprint = Blueprint, Decrypt = decryptor, IsMaxRuns = false });
                addConfiguration(new InventionConfiguration { Blueprint = Blueprint, Decrypt = decryptor, IsMaxRuns = true  });
            }
        }
    }
}