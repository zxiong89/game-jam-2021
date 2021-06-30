using System;

public enum AdventurerTier 
{ 
    Apprentice = 0,
    Experienced = 1,
    Expert = 2,
    Veteran = 3
}

public static class AdventurerTierHelpers 
{
    public static AdventurerTier Convert(int value) 
    {
        if(Enum.IsDefined(typeof(AdventurerTier), value))
        {
            return (AdventurerTier)value;
        }
        else
        {
            throw new Exception("Could not convert value to AdventurerTier");
        }
    }
}
