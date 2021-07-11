using UnityEditor;

[CustomEditor(typeof(PartyEvent))]
public class PartyEventEditor : BaseGameEventEditor<PartyEventArgs>
{
    UnitFactory factory;

    protected override PartyEventArgs CreateEventArgs()
    {
        Party p = new Party();
        for (int i = 0; i < 6; i++)
        {
            p.AddUnit(factory.RandomizeUnit());
        }
        return new PartyEventArgs()
        {
            Party = p
        };
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
