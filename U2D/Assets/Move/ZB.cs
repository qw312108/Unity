using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZB : MonoBehaviour
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.localPosition = new Vector3(-3.6f, 0.0f, 0.0f);
    }
}
