using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer_0 : MonoBehaviour
{
    public Player player;
    public int num = 0;

    public Player GetPlayer()
    {
        player = GetComponentInChildren<Player>();
        return player;
    }

    public void SetNum(int n)
    {
        num = n;
        player.num = n;
    }

}

