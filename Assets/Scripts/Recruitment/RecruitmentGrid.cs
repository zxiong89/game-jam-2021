using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitmentGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject resumePrefab;

    private List<RecruitmentData> potentialRecruits = new List<RecruitmentData>();

    public void AddToGrid(Unit[] units)
    {       
        ClearGrid();
        for (int i = 0; i < units.Length; i++)
        {
            var data = new RecruitmentData(units[i]);
            potentialRecruits.Add(data);

            var newResumeObj = Instantiate(resumePrefab, this.transform);
            var resumeDisplay = newResumeObj.GetComponent<UnitResumeDisplay>();
            resumeDisplay.SetResume(data);
        }
    }

    public void ClearGrid()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            Destroy(transform.GetChild(i - 1).gameObject);
        }
    }

    public void RemoveUnit(RecruitmentData removalData)
    {
        int index = potentialRecruits.FindIndex((data) => data == removalData);
        Destroy(transform.GetChild(index).gameObject);
        potentialRecruits.RemoveAt(index);
    }
}
