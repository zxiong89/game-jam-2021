using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitmentGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject resumePrefab;

    public void AddToGrid(Unit[] units, int[] fee)
    {
        if (units.Length != fee.Length) throw new System.Exception("Mismatch between number of units and fees to generate recruitment resumes.");
        
        ClearGrid();
        for (int i = 0; i < units.Length; i++)
        {
            var newResumeObj = Instantiate(resumePrefab, this.transform);
            var resumeDisplay = newResumeObj.GetComponent<UnitResumeDisplay>();
            resumeDisplay.SetResume(units[i], fee[i]);
        }
    }

    public void ClearGrid()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            Destroy(transform.GetChild(i - 1).gameObject);
        }
    }
}
