using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float interval; //射击间隔
    public GameObject bulletPrefab; //子弹参数
    public GameObject shellPrefab; //蛋壳
    private Transform muzzlePos; //枪口position
    private Transform shellPos; //子弹仓position
    private Vector2 mousePos; //鼠标位置
    private Vector2 direction; //发射方向
    private float timer; //计时器
    private float flipY; //localscale Y值（反转）
    private Animator animator; //动画获取

    ReloadScript ammoScript;

    void Start() //获取动画器和子物体位置
    {
        animator = GetComponent<Animator>();
        muzzlePos = transform.Find("Muzzle");
        shellPos = transform.Find("BulletShell");

        flipY = transform.localScale.y;

        ammoScript = GetComponent<ReloadScript>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //获取鼠标当前世界位置（Camera.main.ScreenToWorldPoint）将像素坐标转为世界坐标

        if(mousePos.x<transform.position.x) //检测枪械角度到达一定值翻转
            transform.localScale = new Vector3(flipY, -flipY, 1);
        else
            transform.localScale = new Vector3(flipY, flipY, 1);
        Shoot();
    }

   void Shoot()
    {
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized; //获取鼠标方向向量枪械朝向鼠标方向
        transform.right = direction;

        if (timer != 0) //不为0时重置
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        } 

        if (Input.GetButton("Fire1") && !ammoScript.needReload) //按鼠标键发射 （装填设置）
        {

            if (timer == 0)  //判断计时器 为0持续射击
            {
                timer = interval; //开始计时
                Fire();
            }
        }
    }

    void Fire()
    {
        animator.SetTrigger("Shoot"); //发射动画
        ammoScript.currentAmmo--; //检测子弹数

        GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity); //子弹位置为枪口位置
        //GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        //bullet.transform.position = muzzlePos.position;

        float angel = Random.Range(-5f, 5f); //子弹偏移
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction); //发射方向为枪口方向  Quaternion.AngleAxis(angel, Vector3.forward) * 

        Instantiate(shellPrefab, shellPos.position, shellPos.rotation); //子弹壳跟随弹仓旋转角度
        //GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
        //shell.transform.position = shellPos.position;
        //shell.transform.rotation = shellPos.rotation;
    }
}
