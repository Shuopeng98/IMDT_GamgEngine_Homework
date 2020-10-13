using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public List<Player> players;
    public List<Layer_0> layers;
    public List<float> speed;
    public float maxSpeed = 5f;
    public int nowNum = 0;

    private void Start()
    {
        speed.Add(maxSpeed);
    }
    void Update()
    {
        PlayerController(0, 0, 0, false);
    }

    public void PlayerController(int v, int h, int num,bool next)
    {
        if(num == 0)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            players[0].transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * (speed[num]));   
        }
        else if(num <=nowNum)
        { 
            float vertical = v;
            float horizontal = h;
            players[num].transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed[num]);
        }
        if(next)
        {
            CreateLayer(num);
            nowNum++;
        }
    }

    public void CreateLayer(int num)
    {
        Transform tra = layers[0].transform;
        
        Layer_0 newLayer = Instantiate<Layer_0>(layers[0], new Vector3(0, 0, 0), tra.rotation);

        speed.Add(speed[num - 1] / 2);
        newLayer.SetNum(num);
        players.Add(newLayer.GetPlayer());
        layers.Add(newLayer);

        layers[num].player.transform.position = new Vector3(0, -2, 0);
        float v = 5f - 5f / (float)Math.Pow(2, num);
        layers[num].transform.position = new Vector3(0, v, 0);
        float s = (float)(1 / Math.Pow(2, num));
        layers[num].transform.localScale = new Vector3(s, s, 1);

        Debug.Log(num+": center " + v + "| scale " + s);
        layers[num].player.SetActive(true);
    }
}
