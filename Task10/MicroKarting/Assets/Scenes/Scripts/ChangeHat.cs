using System.Collections.Generic;
using UnityEngine;

public class ChangeHat : MonoBehaviour
{
    public List<GameObject> hatList;
    private int now;
    void Start()
    {
        now = Hat.hatNum;
        ShowHat(now);
    }

    public void nextHat()
    {
        int x = (now + 1) % (hatList.Count + 1);
        Hat.hatNum = x;
        now = x;
        ShowHat(x);
    }

    public void previousHat()
    {
        int x = (now - 1) % (hatList.Count + 1);
        Hat.hatNum = x;
        now = x;
        ShowHat(x);
    }

    private void ShowHat(int num)
    {
        foreach (GameObject i in hatList)
        {
            i.SetActive(false);
        }
        if (num != 0)
        {
            hatList[num - 1].SetActive(true);
        }
    }
}
