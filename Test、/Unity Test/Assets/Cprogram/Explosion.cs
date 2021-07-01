using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator; //动画器
    private AnimatorStateInfo info; //动画进度

    void Awake() //获取动画器
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0); //持续获得动画进度
        if (info.normalizedTime >= 1)
        {
            Destroy(gameObject); //销毁特效
            //ObjectPool.Instance.PushObject(gameObject);
        }
    }
}
