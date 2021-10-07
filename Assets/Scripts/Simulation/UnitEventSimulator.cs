using UnityEngine;

public class UnitEventSimulator
{
    private float unitJoinCounter = 0;
    private float unitDeathCounter = 0;
    private float unitPoachedCounter = 0;

    public void UpdateUnitEvents(UnitRoster freeAgentRoster, Guild playerGuild, UnitRoster inPartyRoster)
    {
        UnitWantsToJoinEvent(freeAgentRoster, playerGuild);
        UnitDeath(freeAgentRoster, playerGuild, inPartyRoster);
        UnitPoached(playerGuild, inPartyRoster);
    }

    private void UnitWantsToJoinEvent(UnitRoster freeAgentRoster, Guild playerGuild)
    {
        unitJoinCounter += FloatExtensions.Randomize(18, 50, 34) * TimeMultiplier();
        if(unitJoinCounter > 100)
        {
            Unit randUnit = GetRandomUnit(freeAgentRoster);
            if (randUnit == null) return;

            var recruitData = RecruitmentDataFactory.GetOrAddData(randUnit);
            recruitData.UpdateFee();
            if (recruitData.Fee < playerGuild.Gold * .25f)
            {
                PopupMessage.ShowPopup(new PopupEventArgs()
                {
                    Text = randUnit.DisplayName + " wants to join your guild!\n" +
                        "Their hiring fee is " + 0 + "G",
                    AcceptTextOverride = "Hire",
                    AcceptCallback = (popupContent) =>
                    {
                        PopupMessage.ShowPopup(new PopupEventArgs()
                        {
                            Text = "Add the hiring workflow here!"
                        });
                    },
                    CloseTextOverride = "Refuse",
                    PausesTime = true
                });
            }
            unitJoinCounter -= 100;
        }

    }

    private void UnitDeath(UnitRoster freeAgentRoster, Guild PlayerGuild, UnitRoster inPartyRoster)
    {
        unitDeathCounter += FloatExtensions.Randomize(10f, 15f, 20f) * TimeMultiplier() * GuildSizeMultiplier(PlayerGuild, inPartyRoster);
        if(unitDeathCounter > 100)
        {
            Unit randUnit = GetRandomUnit(freeAgentRoster, PlayerGuild.Roster, inPartyRoster);
            if (randUnit == null) return;

            if (randUnit.IsInPlayerGuild())
            {
                if (UnityEngine.Random.Range(0f, 1f) > GuildSizeMultiplier(PlayerGuild, inPartyRoster)) return;
                PopupMessage.ShowPopup(new PopupEventArgs()
                {
                    Text = randUnit.DisplayName + " has died.",
                    PausesTime = true
                });
            }
            randUnit.Retire();
            unitDeathCounter -= 100;
        }

    }

    private void UnitPoached(Guild playerGuild, UnitRoster inPartyRoster)
    {
        unitPoachedCounter += FloatExtensions.Randomize(12.5f, 18.75f, 25) * TimeMultiplier() * GuildSizeMultiplier(playerGuild, inPartyRoster);
        if(unitPoachedCounter > 100)
        {
            Unit randUnit = GetRandomUnit(playerGuild.Roster, inPartyRoster);
            if (randUnit == null) return;
            PopupMessage.ShowPopup(new PopupEventArgs()
            {
                Text = randUnit.DisplayName + " left to join another guild.",
                PausesTime = true
            });
            randUnit.Retire();
            unitPoachedCounter -= 100;
        }
    }

    private Unit GetRandomUnit(params UnitRoster[] rosters)
    {
        int totalCount = 0;
        foreach(var roster in rosters)
        {
            totalCount += roster.Count;
        }
        if (totalCount == 0) return null;

        int randUnitIndex = UnityEngine.Random.Range(0, totalCount);
        int curRosterIndex = 0;
        while(randUnitIndex >= rosters[curRosterIndex].Count)
        {
            randUnitIndex -= rosters[curRosterIndex].Count;
            curRosterIndex++;
        }
        return rosters[curRosterIndex][randUnitIndex];
    }

    private float TimeMultiplier()
    {
        return Time.deltaTime / SimulationConstants.SECONDS_PER_YEAR;
    }

    private float GuildSizeMultiplier(Guild playerGuild, UnitRoster inPartyRoster)
    {
        float guildCount = playerGuild.Roster.Count + inPartyRoster.Count;
        return (guildCount >= 20) ? 1 : guildCount / 20f;
    }
}
