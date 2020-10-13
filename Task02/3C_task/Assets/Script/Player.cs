using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Layer outlook;
    public int num = 0;
    public bool active = false;


    public void OnTriggerStay2D(Collider2D collision)
    {
        int v = 0, h = 0;
        bool next = false;
        if (collision.CompareTag("Up"))
        {
            Debug.Log( num + " stay on up");
            v = 1;
        }
        else if (collision.CompareTag("Down"))
        {
            Debug.Log(num + " stay on down");
            v = -1;
        }
        else if (collision.CompareTag("Left"))
        {
            Debug.Log(num + " stay on left");
            h = -1;
        }
        else if (collision.CompareTag("Right"))
        {
            Debug.Log(num + " stay on right");
            h = 1;
        }

        if (collision.CompareTag("Enter")&&active)
        {
            //Debug.Log("destroy " + num + ":" + collision.tag);
            //Destroy(collision.gameObject);
            next = true;
            active = false;
            if (num >= 3) next = false;
        }
        outlook.PlayerController(v, h, num+1, next);
    }

    public void SetActive(bool isActive)
    {
        active = isActive;
    }
}
