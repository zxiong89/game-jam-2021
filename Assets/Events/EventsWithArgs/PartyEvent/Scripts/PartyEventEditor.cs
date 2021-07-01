using UnityEditor;

[CustomEditor(typeof(PartyEvent))]
public class PartyEventEditor : BaseGameEventEditor<Party>
{
    UnitFactory factory;

    protected override Party CreateEventArgs()
    {
        Party p = new Party();
        for (int i = 0; i < 6; i++)
        {
            p.AddUnit(factory.RandomizeUnit());
        }
        return p;
    }

    protected override void DisplayEditorFields()
    {
        factory = (UnitFactory)EditorGUILayout.ObjectField(factory, typeof(UnitFactory), allowSceneObjects: true);
    }

    protected override bool CanDisplayButton()
    {
        return (factory != null);
    }
}
