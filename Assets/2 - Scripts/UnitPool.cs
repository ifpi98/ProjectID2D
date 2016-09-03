using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitPool : MonoBehaviour
{
    public Unit unitPrefab;

    public List<Unit> unitObjects;

    void Start()
    {
        unitObjects = new List<Unit>();
    }

    public Unit[] Get(int count)
    {
        if (count > unitObjects.Count)
        {
            for (int i = unitObjects.Count; i < count; i++ )
            {
                var unit = Instantiate<Unit>(unitPrefab);
                unitObjects.Add(unit);
            }
        }

        return unitObjects.ToArray();
    }

    public void Set(string[] strArr)
    {
        for (int i = 0; i < strArr.Length; i++)
        {
            unitObjects[i].Label.text = strArr[i];
            Color color = unitObjects[i].GetComponent<Image>().color;
            color.a = 1;
            unitObjects[i].GetComponent<Image>().color = color;
            color = unitObjects[i].Label.color;
            color.a = 1;
            unitObjects[i].Label.color = color;
        }
    }
}
