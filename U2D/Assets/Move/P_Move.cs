using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Move : MonoBehaviour
{
    public float p_Speed;
    public Rigidbody2D rigidbody2D;
    public float Jump;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public LayerMask graund;//地面

    private float x;
    private float y;

    private bool jumpRequest = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();//取到玩家

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");//默认x轴方向 AD←→键控制

        //面向左


        Vector3 movement = new Vector3(x, y, z: 0);
        rigidbody2D.transform.position += movement * p_Speed * Time.deltaTime;//人物移动

        RaycastHit2D rayhit = Physics2D.Raycast(this.transform.position, Vector2.down, 0.6f, graund);//射线


        if (Input.GetButtonDown("Jump"))//unity默认空格跳跃
        {
            if (rayhit.collider != null)//触地检测
            {
                jumpRequest = true;//跳跃状态
            }
        }

    }

    void FixedUpdate()
    {



        if (jumpRequest)//跳跃状态设定
        {
            rigidbody2D.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            jumpRequest = false;//防止一直上升
        }
        //跳跃手感的变化
        if (rigidbody2D.velocity.y < 0)//下降时加重
        {
            rigidbody2D.gravityScale = fallMultiplier;

        }
        else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))//单击空格
        {
            rigidbody2D.gravityScale = lowJumpMultiplier;

        }
        else//按住空格
        {
            rigidbody2D.gravityScale = 1f;

        }


    }
}

