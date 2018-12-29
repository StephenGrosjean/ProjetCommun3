using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour {

    [SerializeField] private List<int> IDs;

    public void RemoveID(int ID)
    {
        if (IDs.Contains(ID))
        {
            IDs.Remove(ID);
        }
    }

    public void AddID(int ID)
    {
        if (!IDs.Contains(ID))
        {
            IDs.Add(ID);

        }
    }

    public bool CheckIfUsed(int ID)
    {
        bool isUsed = false;

        if (IDs.Contains(ID))
        {
            isUsed = true;
        }

        return isUsed;

    }
}
