using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveStuff.Model;

namespace EveStuff
{
    public class DecryptorTraits
    {
        public double ProbabilityModifier { get; private set; }
        public int RunsModifier { get; private set; }
        public int MaterialLevelModifier { get; private set; }
        public int ProductionLevelModifier { get; private set; }

        private DecryptorTraits(double prob, int runs, int ml, int pl)
        {
            ProbabilityModifier = prob;
            RunsModifier = runs;
            MaterialLevelModifier = ml;
            ProductionLevelModifier = pl;
        }

        static public DecryptorTraits Decryptor0 = new DecryptorTraits(0.0, 0, -4, -4);
        static public DecryptorTraits Decryptor1 = new DecryptorTraits(0.6, 9, -6, -3);
        static public DecryptorTraits Decryptor2 = new DecryptorTraits(1.0, 2, -3, 0);
        static public DecryptorTraits Decryptor3 = new DecryptorTraits(1.1, 0, -1, -1);
        static public DecryptorTraits Decryptor4 = new DecryptorTraits(1.2, 1, -2, -1);
        static public DecryptorTraits Decryptor5 = new DecryptorTraits(1.8, 4, -5, -2);
    }

    public class Decryptor
    {
        public int DecryptorTypeID { get; private set; }
        public DecryptorTraits Traits { get; private set; }

        private Decryptor(int typeID, DecryptorTraits traits)
        {
            DecryptorTypeID = typeID;
            Traits = traits;
        }

        static public Decryptor None = new Decryptor(-1, DecryptorTraits.Decryptor0);

        static public Decryptor FormationLayout = new Decryptor(23178, DecryptorTraits.Decryptor3);
        static public Decryptor ClassicDoctrine = new Decryptor(23179, DecryptorTraits.Decryptor4);
        static public Decryptor SacredManifesto = new Decryptor(23180, DecryptorTraits.Decryptor2);
        static public Decryptor CircularLogic = new Decryptor(23181, DecryptorTraits.Decryptor1);
        static public Decryptor WarStrategon = new Decryptor(23182, DecryptorTraits.Decryptor5);

        static public Decryptor CalibrationData = new Decryptor(21579, DecryptorTraits.Decryptor3);
        static public Decryptor AdvancedTheories = new Decryptor(21580, DecryptorTraits.Decryptor4);
        static public Decryptor OperationHandbook = new Decryptor(21581, DecryptorTraits.Decryptor2);
        static public Decryptor CircuitrySchematics = new Decryptor(21582, DecryptorTraits.Decryptor1);
        static public Decryptor AssemblyInstuctions = new Decryptor(21583, DecryptorTraits.Decryptor5);

        static public Decryptor CollisionMeasurements = new Decryptor(23183, DecryptorTraits.Decryptor3);
        static public Decryptor TestReports = new Decryptor(23184, DecryptorTraits.Decryptor4);
        static public Decryptor EngagementPlan = new Decryptor(23185, DecryptorTraits.Decryptor2);
        static public Decryptor SymbioticFigures = new Decryptor(23186, DecryptorTraits.Decryptor1);
        static public Decryptor StolenFormulas = new Decryptor(23187, DecryptorTraits.Decryptor5);

        static public Decryptor TuningInstructons = new Decryptor(21573, DecryptorTraits.Decryptor3);
        static public Decryptor PrototypeDiagram = new Decryptor(21574, DecryptorTraits.Decryptor4);
        static public Decryptor UserManual = new Decryptor(21575, DecryptorTraits.Decryptor2);
        static public Decryptor InterfaceAlignmentChart = new Decryptor(21576, DecryptorTraits.Decryptor1);
        static public Decryptor InstallationGuide = new Decryptor(21577, DecryptorTraits.Decryptor5);

        static public Decryptor[] AmarrDecryptors = new[] { None, FormationLayout, ClassicDoctrine, SacredManifesto, CircularLogic, WarStrategon };
        static public Decryptor[] MinmatarDecryptors = new[] { None, CalibrationData, AdvancedTheories, OperationHandbook, CircuitrySchematics, AssemblyInstuctions };
        static public Decryptor[] GalenteDecryptors = new[] { None, CollisionMeasurements, TestReports, EngagementPlan, SymbioticFigures, StolenFormulas };
        static public Decryptor[] CaldariDecryptors = new[] { None, TuningInstructons, PrototypeDiagram, UserManual, InterfaceAlignmentChart, InstallationGuide };

        static public Dictionary<RaceType, Decryptor[]> RacialDecryptors = new Dictionary<RaceType, Decryptor[]>{
            {RaceType.Caldari, CaldariDecryptors},
            {RaceType.Minmatar, MinmatarDecryptors},
            {RaceType.Amarr, AmarrDecryptors},
            {RaceType.Galente, GalenteDecryptors},
            {RaceType.ORE, GalenteDecryptors}
        };

    }

    public class InventionTraits
    {
        public static int InventionLabSlots = 7;
        public static int MaxCopySlotMinutes = 40 * 7 * 24 * 60;
        public static int AdvCopySlotMinutes = 7 * 24 * 60 * 3 / 2;

        public double BaseProbability { get; private set; }
        public double InventionSlotsPerWeek { get; private set; }
        public double CopiesPerWeek { get; private set; }
        public int MaxRuns { get; private set; }
        private InventionTraits(double baseProbabality, double inventionTime, double copiesPerWeek, int maxRuns)
        {
            BaseProbability = baseProbabality;
            InventionSlotsPerWeek = inventionTime;
            CopiesPerWeek = copiesPerWeek;
            MaxRuns = maxRuns;
        }

        public static InventionTraits FrigateTraits = new InventionTraits(0.3, 8 * InventionLabSlots, MaxCopySlotMinutes/ 100, 30);
        public static InventionTraits DestoryerTraits = new InventionTraits(FrigateTraits.BaseProbability, 7 * InventionLabSlots, MaxCopySlotMinutes / 225, 20);
        public static InventionTraits CruiserTraits = new InventionTraits(0.25, 6 * InventionLabSlots, MaxCopySlotMinutes / 400, 15);
        public static InventionTraits IndustrialTraits = CruiserTraits;
        public static InventionTraits BattleCruiserTraits = new InventionTraits(BattleshipTraits.BaseProbability, 4 * InventionLabSlots, 3 * AdvCopySlotMinutes/ 600, 15 );
        public static InventionTraits BattleshipTraits = new InventionTraits(0.2, 4 * InventionLabSlots, 1 * AdvCopySlotMinutes / 900, 10);
        public static InventionTraits FreighterTraits = new InventionTraits(FrigateTraits.BaseProbability, 2 * InventionLabSlots, 1 * AdvCopySlotMinutes / 64000, 1);

        public static InventionTraits SkiffTraits = new InventionTraits(FrigateTraits.BaseProbability, FrigateTraits.InventionSlotsPerWeek, AdvCopySlotMinutes / 300, 10);
        public static InventionTraits MackinawTraits = new InventionTraits(CruiserTraits.BaseProbability, FrigateTraits.InventionSlotsPerWeek, AdvCopySlotMinutes / 300, 10);
        public static InventionTraits HulkTraits = new InventionTraits(BattleshipTraits.BaseProbability, FrigateTraits.InventionSlotsPerWeek, AdvCopySlotMinutes / 300, 10);

        public static InventionTraits GetInventionTraits(BlueprintInfo bp)
        {
            if (bp.Product.Parent.IsFrigate)
                return FrigateTraits;
            if (bp.Product.Parent.IsDestroyer)
                return DestoryerTraits;
            if (bp.Product.Parent.IsCruiser)
                return CruiserTraits;
            if (bp.Product.Parent.IsIndustrial)
                return IndustrialTraits;
            if (bp.Product.Parent.IsBattleCruiser)
                return BattleCruiserTraits;
            if (bp.Product.Parent.IsBattleship)
                return BattleshipTraits;
            if (bp.Product.Parent.IsFreighter)
                return FreighterTraits;

            if (bp.Product.IsSkiff)
                return SkiffTraits;
            if (bp.Product.IsMackinaw)
                return MackinawTraits;
            if (bp.Product.IsHulk)
                return HulkTraits;

            throw new ArgumentException();
        }
    }

}
