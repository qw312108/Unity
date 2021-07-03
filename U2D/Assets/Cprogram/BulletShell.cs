using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    public float speed; //子弹飞出速度
    public float stopTime = .5f; //子弹停止时间
    public float fadeSpeed = .01f; //子弹消失速度
    new private Rigidbody2D rigidbody; //刚体
    private SpriteRenderer sprite; //2d精灵渲染器

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        rigidbody.velocity = Vector3.up * speed; //弹壳向上抛出力
    }

    private void OnEnable() //弹壳范围内随机散落
    {
        float angel = Random.Range(-30f, 30f);
        rigidbody.velocity = Quaternion.AngleAxis(angel, Vector3.forward) * Vector3.up * speed;

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        rigidbody.gravityScale = 3;

        StartCoroutine(Stop());
    }

    IEnumerator Stop() //弹壳一定时间后逐渐消失
    {
        yield return new WaitForSeconds(stopTime);
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;

        while (sprite.color.a > 0) //渲染器大于0时每帧颜色（逐渐透明）
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, sprite.color.a - fadeSpeed);
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
        //ObjectPool.Instance.PushObject(gameObject);
    }
}
