using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; //速度
    public GameObject explosionPrefab; //爆炸特效
    new private Rigidbody2D rigidbody; //刚体
    public int damage = 25;

    void Awake() //awake函数中获得刚体
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction) //子弹移动方向
    {
        rigidbody.velocity = direction * speed; //方向x速度
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); //产生特效并销毁子弹
        //GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        //exp.transform.position = transform.position;

        Destroy(gameObject);
        //ObjectPool.Instance.PushObject(gameObject);
    }
}
