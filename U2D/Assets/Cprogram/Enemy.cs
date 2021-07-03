using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform _enemy;
    public float e_speed;
    public int health = 100;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//获得Tag player的位置
        _enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //向玩家坐标移动
        _enemy.position = Vector2.MoveTowards(_enemy.position,
            player.position,
            e_speed * Time.deltaTime);



    }
}
