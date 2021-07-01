using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
    //重新装填
{

    public int maxAmmo = 20; //最大子弹数
    public int defaulAmmo = 20; //剩余子弹数
    [HideInInspector]   //隐藏该项目
    public int currentAmmo;   //当前弹药
    public float reloadspeed = 2f; //装填等待时间

    public Text ammoText; //UI

    public bool needReload; //需要装填
  
    void Start()
    {
        currentAmmo = defaulAmmo; //弹药检测
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= 0) //需要换单
            needReload = true;

        if (Input.GetKeyDown(KeyCode.R)) //R键换弹
            StartCoroutine(Reload());

        ammoText.text = currentAmmo + "//" + maxAmmo; //UI格式
    }

    private IEnumerator Reload() //换弹判断test
    {
        Debug.Log("Reload");
        yield return new WaitForSeconds(reloadspeed);
        currentAmmo = defaulAmmo;
        needReload = false;
    }
}
