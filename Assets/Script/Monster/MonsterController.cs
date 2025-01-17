using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation(){
        Invoke(nameof(PlayAnimationName), 5f);
    }
    void PlayAnimationName(){
        animator.Play("monsterAnimation");
    }
    void PlayAnimationBefore(){
        animator.Play("MonsterBeforeStart");
    }
    void PlayAnimationIdle(){
        animator.Play("MonsterIdle");
    }
}
