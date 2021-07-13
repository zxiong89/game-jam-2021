using System.Text;
using UnityEngine;

public static class UnitExtensions
{
    public const float STAT_AVERAGE_BASE = 20f;

    private readonly static GrowthFactor STAT_AVERAGE_GROWTH = new GrowthFactor()
    {
        EarlyMod = 10,
        LinearMod = 1,
        LateMod = 0.02f
    };

    private const float STAT_LOW_BASE = 10f;

    private readonly static GrowthFactor STAT_LOW_GROWTH = new GrowthFactor()
    {
        EarlyMod = 1,
        LinearMod = 0.5f,
        LateMod = 0.01f
    };

    private const float STAT_HIGH_BASE = 30f;

    private readonly static GrowthFactor STAT_HIGH_GROWTH = new GrowthFactor()
    {
        EarlyMod = 20,
        LinearMod = 3,
        LateMod = 0.04f
    };

    public static string UnitToString(Unit u)
    {
        var f = u.Class.Data.FrontlineMod.Atk >= u.Class.Data.BacklineMod.Atk;
        var c = u.CalcContribution(f);
        return $"{c.PhyAtk + c.MagAtk}, {c.PhyAtk}, {c.MagAtk}, {c.Def}, {c.AtkSup}, {c.DefSup}";
    }

    public static void SimulateLevel1To100(Unit u, string cell1)
    {
        var sb = new StringBuilder();
        u.Level = 1;
        sb.AppendLine($"{cell1}, 1, {UnitToString(u)}");
        for (int lv = 10; lv <= 100; lv += 10)
        {
            u.Level = lv;
            sb.AppendLine($"{cell1}, {lv}, {UnitToString(u)}");
        }

        Debug.Log(sb.ToString());
    }

    public static void SetUnitClass(Unit u, UnitClassData classData)
    {
        u.Class.Data = classData; 
    }

    public static void SetUnitGrowth(Unit u, StatBlock statBlock)
    {
        u.Stats = statBlock;
    }

    public readonly static StatBlock AVERAGE = new StatBlock()
    {
        Str = new StrengthStat()
        {
            BodyBase = STAT_AVERAGE_BASE,
            BodyGrowth = STAT_AVERAGE_GROWTH,
            BrawnBase = STAT_AVERAGE_BASE,
            BrawnGrowth = STAT_AVERAGE_GROWTH,
            PowerBase = STAT_AVERAGE_BASE,
            PowerGrowth = STAT_AVERAGE_GROWTH
        },
        Con = new ConstitutionStat()
        {
            EnduranceBase = STAT_AVERAGE_BASE,
            EnduranceGrowth = STAT_AVERAGE_GROWTH,
            StaminaBase = STAT_AVERAGE_BASE,
            StaminaGrowth = STAT_AVERAGE_GROWTH,
            VitalityBase = STAT_AVERAGE_BASE,
            VitalityGrowth = STAT_AVERAGE_GROWTH
        },
        Dex = new DexterityStat()
        {
            SpeedBase = STAT_AVERAGE_BASE,
            SpeedGrowth = STAT_AVERAGE_GROWTH,
            AgilityBase = STAT_AVERAGE_BASE,
            AgilityGrowth = STAT_AVERAGE_GROWTH,
            ReflexesBase = STAT_AVERAGE_BASE,
            ReflexesGrowth = STAT_AVERAGE_GROWTH
        },
        Int = new IntelligenceStat()
        {
            IntellectBase = STAT_AVERAGE_BASE,
            IntellectGrowth = STAT_AVERAGE_GROWTH,
            KnowledgeBase = STAT_AVERAGE_BASE,
            KnowledgeGrowth = STAT_AVERAGE_GROWTH,
            MindBase = STAT_AVERAGE_BASE,
            MindGrowth = STAT_AVERAGE_GROWTH
        },
        Wis = new WisdomStat()
        {
            SenseBase = STAT_AVERAGE_BASE,
            SenseGrowth = STAT_AVERAGE_GROWTH,
            SpiritBase = STAT_AVERAGE_BASE,
            SpiritGrowth = STAT_AVERAGE_GROWTH,
            WillBase = STAT_AVERAGE_BASE,
            WillGrowth = STAT_AVERAGE_GROWTH
        }
    };

    public readonly static StatBlock LOW = new StatBlock()
    {
        Str = new StrengthStat()
        {
            BodyBase = STAT_LOW_BASE,
            BodyGrowth = STAT_LOW_GROWTH,
            BrawnBase = STAT_LOW_BASE,
            BrawnGrowth = STAT_LOW_GROWTH,
            PowerBase = STAT_LOW_BASE,
            PowerGrowth = STAT_LOW_GROWTH
        },
        Con = new ConstitutionStat()
        {
            EnduranceBase = STAT_LOW_BASE,
            EnduranceGrowth = STAT_LOW_GROWTH,
            StaminaBase = STAT_LOW_BASE,
            StaminaGrowth = STAT_LOW_GROWTH,
            VitalityBase = STAT_LOW_BASE,
            VitalityGrowth = STAT_LOW_GROWTH
        },
        Dex = new DexterityStat()
        {
            SpeedBase = STAT_LOW_BASE,
            SpeedGrowth = STAT_LOW_GROWTH,
            AgilityBase = STAT_LOW_BASE,
            AgilityGrowth = STAT_LOW_GROWTH,
            ReflexesBase = STAT_LOW_BASE,
            ReflexesGrowth = STAT_LOW_GROWTH
        },
        Int = new IntelligenceStat()
        {
            IntellectBase = STAT_LOW_BASE,
            IntellectGrowth = STAT_LOW_GROWTH,
            KnowledgeBase = STAT_LOW_BASE,
            KnowledgeGrowth = STAT_LOW_GROWTH,
            MindBase = STAT_LOW_BASE,
            MindGrowth = STAT_LOW_GROWTH
        },
        Wis = new WisdomStat()
        {
            SenseBase = STAT_LOW_BASE,
            SenseGrowth = STAT_LOW_GROWTH,
            SpiritBase = STAT_LOW_BASE,
            SpiritGrowth = STAT_LOW_GROWTH,
            WillBase = STAT_LOW_BASE,
            WillGrowth = STAT_LOW_GROWTH
        }
    };

    public readonly static StatBlock HIGH = new StatBlock()
    {
        Str = new StrengthStat()
        {
            BodyBase = STAT_HIGH_BASE,
            BodyGrowth = STAT_HIGH_GROWTH,
            BrawnBase = STAT_HIGH_BASE,
            BrawnGrowth = STAT_HIGH_GROWTH,
            PowerBase = STAT_HIGH_BASE,
            PowerGrowth = STAT_HIGH_GROWTH
        },
        Con = new ConstitutionStat()
        {
            EnduranceBase = STAT_HIGH_BASE,
            EnduranceGrowth = STAT_HIGH_GROWTH,
            StaminaBase = STAT_HIGH_BASE,
            StaminaGrowth = STAT_HIGH_GROWTH,
            VitalityBase = STAT_HIGH_BASE,
            VitalityGrowth = STAT_HIGH_GROWTH
        },
        Dex = new DexterityStat()
        {
            SpeedBase = STAT_HIGH_BASE,
            SpeedGrowth = STAT_HIGH_GROWTH,
            AgilityBase = STAT_HIGH_BASE,
            AgilityGrowth = STAT_HIGH_GROWTH,
            ReflexesBase = STAT_HIGH_BASE,
            ReflexesGrowth = STAT_HIGH_GROWTH
        },
        Int = new IntelligenceStat()
        {
            IntellectBase = STAT_HIGH_BASE,
            IntellectGrowth = STAT_HIGH_GROWTH,
            KnowledgeBase = STAT_HIGH_BASE,
            KnowledgeGrowth = STAT_HIGH_GROWTH,
            MindBase = STAT_HIGH_BASE,
            MindGrowth = STAT_HIGH_GROWTH
        },
        Wis = new WisdomStat()
        {
            SenseBase = STAT_HIGH_BASE,
            SenseGrowth = STAT_HIGH_GROWTH,
            SpiritBase = STAT_HIGH_BASE,
            SpiritGrowth = STAT_HIGH_GROWTH,
            WillBase = STAT_HIGH_BASE,
            WillGrowth = STAT_HIGH_GROWTH
        }
    };
}
