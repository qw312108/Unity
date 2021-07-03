using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Transform player;
    Transform _enemy;
    public float e_speed;
    public bool expose; //玩家是否暴露

    // Start is called before the first frame update
    void Start()
    {
        _enemy = this.gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//获得Tag player的位置
        _enemy = GetComponent<Transform>();

        expose = false;//初始值：未暴露
    }

    // Update is called once per frame
    void Update()
    {

        if (expose)//暴露时向主角移动
        {
            //向玩家坐标移动
            _enemy.position = Vector2.MoveTowards(_enemy.position,
                player.position,
                e_speed * Time.deltaTime);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            expose = true;
        }
    }
}
