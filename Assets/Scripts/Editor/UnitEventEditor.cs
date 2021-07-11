using UnityEditor;

[CustomEditor(typeof(UnitEvent))]
public class UnitGameEventEditor : BaseGameEventEditor<Unit>
{
    UnitFactory factory;

    protected override Unit CreateEventArgs()
    {
        return factory.RandomizeUnit();
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
