using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDisplayLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject globals;

    public void LoadMenuOption(GameObject prefab)
    {
        ClearDisplay();
        GameObject.Instantiate(prefab, transform);
    }

    private void ClearDisplay()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            var curChild = transform.GetChild(i);
            Destroy(curChild.gameObject);
        }
    }
}
