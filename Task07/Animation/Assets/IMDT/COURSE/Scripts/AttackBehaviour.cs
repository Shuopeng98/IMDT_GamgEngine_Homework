using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : GenericBehaviour
{
    // Start is called before the first frame update
    public string hitButton = "Hit";
    private int hitBool;
    private int moveBool;
    private int jumpBool;
    private Animator anim;
    private float speed;

    void Start()
    {
        hitBool = Animator.StringToHash("Hit");
        moveBool = Animator.StringToHash("Speed");
        jumpBool = Animator.StringToHash("Jump");
        anim = GetComponent<Animator>();
        behaviourManager.SubscribeBehaviour(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = anim.GetFloat(moveBool);
        bool now = anim.GetBool(hitBool);
        bool jump = anim.GetBool(jumpBool);
        if ((speed>0.01f|| jump) && now)
        {
            anim.SetBool(hitBool, false);
        }
        if (VirtualInput.GetButtonDown(hitButton))
        {
            now = anim.GetBool(hitBool);
            anim.SetBool(hitBool, !now);
        }
    }
}
