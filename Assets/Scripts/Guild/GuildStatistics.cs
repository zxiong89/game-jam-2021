using System.Collections.Generic;

public static class GuildStatistics 
{
    public static double GoldSpent = 0d;
    public static double GoldGained = 0d;
    public static Dictionary<string, QuestStatistics> WorldResults = 
        new Dictionary<string, QuestStatistics>();

    public static void AddQuestResult(Quest quest)
    {
        QuestStatistics results;
        if (WorldResults.ContainsKey(quest.LocationData.Name))
        {
            results = WorldResults[quest.LocationData.Name];
        }
        else
        {
            results = new QuestStatistics();
            WorldResults[quest.LocationData.Name] = results;
        }

        foreach(var defeated in quest.Defeated)
        {
            incrementKeyCount(results.Defeated, defeated.Key, defeated.Value);
        }

        foreach (var explored in quest.Explored)
        {
            incrementKeyCount(results.Explored, explored.Key, explored.Value);
        }
    }

    private static void incrementKeyCount(Dictionary<string, double> dict, string key, double inc)
    {
        var orig = dict.ContainsKey(key) ? dict[key] : 0d;
        dict[key] = orig + inc;
    }
}
