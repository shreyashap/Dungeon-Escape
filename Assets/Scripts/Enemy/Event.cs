using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    private Spider_Enemy spider;


    private void Start()
    {
        spider = transform.parent.GetComponent<Spider_Enemy>();
    }
    public void Fire()
    {
        Debug.Log("Spider Fires");
        spider.Attack();
    }
}
