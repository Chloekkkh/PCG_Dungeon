using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 跟随的目标对象
    public Vector3 velocity; // 速度
    public Vector3 offset;   // 偏移量
    [Range(0,1)]
    public float smoothTime = 0.3f; // 平滑时间

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void LateUpdate()
    {
        // 相机的位置
        Vector3 targetPos = target.position + offset;
        if(target.position.y<-22||target.position.y>22)
        {
            float y = transform.position.y;
            transform.position = new Vector3(targetPos.x, y, transform.position.z);
        }
        else if(target.position.x<-15||target.position.x>15)
        {
            float x = transform.position.x;
            transform.position = new Vector3(x, targetPos.y, transform.position.z);
        }
        else if((target.position.y<-22&&target.position.x>15)||target.position.y>22||target.position.x<-15)
        {
            transform.position = transform.position;
        }
        else
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
