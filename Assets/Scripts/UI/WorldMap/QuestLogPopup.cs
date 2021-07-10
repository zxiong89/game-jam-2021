using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogPopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    [SerializeField]
    private RectTransform content;

    public void SetQuestLog(Quest quest)
    {
        display.text = quest.Log();
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }
}
