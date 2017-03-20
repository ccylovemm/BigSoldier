using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public Rect followRect;

    void Update()
    {
        if (target == null) return;

        float offx = transform.position.x - target.transform.position.x;
        if (Mathf.Abs(offx) > offsetX)
        {
            float d = Mathf.Abs(offx) - offsetX;
            transform.position += new Vector3(offx > 0 ? -d : d, 0 , 0);
        }

        float offy = target.transform.position.y - transform.position.y;
        if (Mathf.Abs(offy) > offsetY)
        {
            float d = Mathf.Abs(offy) - offsetY;
            transform.position += new Vector3(0 , offx > 0 ? -d : d , 0);
        }

        if (transform.position.x < followRect.x)
        {
            transform.position = new Vector3(followRect.x , transform.position.y , transform.position.z);
        }
        if (transform.position.y > followRect.y)
        {
            transform.position = new Vector3(transform.position.x, followRect.y , transform.position.z);
        }
        if (transform.position.x > followRect.width)
        {
            transform.position = new Vector3(followRect.width, transform.position.y, transform.position.z);
        }
        if (transform.position.y < followRect.height)
        {
            transform.position = new Vector3(transform.position.x, followRect.height , transform.position.z);
        }
    }
}
