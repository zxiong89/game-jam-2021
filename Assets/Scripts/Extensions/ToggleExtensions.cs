using UnityEngine.UI;

public static class ToggleExtensions
{
    /// <summary>
    /// Finds the selected toggle in the toggle group. Assumes that the toggles is a child of the toggle group.
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    public static Toggle FindSelectedToggle(ToggleGroup group)
    {
        if (group != null)
        {
            foreach (var toggle in group.GetComponentsInChildren<Toggle>())
            {
                if (toggle.isOn) return toggle;
            }
        }
        return null;
    }
}
