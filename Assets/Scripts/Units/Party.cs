using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public int MaxSize = 0;

    [SerializeField]
    private List<Unit> units = new List<Unit>();

    #region Unit Management Methods

    public bool CanAdd() => MaxSize == 0 || units.Count < MaxSize;

    public bool Add(Unit unit)
    {
        if (!CanAdd()) return false;
        units.Add(unit);
        return true;
    }

    public bool Remove(Unit unit) => units.Remove(unit);

    #endregion

    #region Party Calculations

    public void UpdateOverall()
    {

    }

    #endregion

    #region Monobehavior

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion
}
