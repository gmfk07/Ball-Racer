using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        gameObject.transform.position = new Vector3(target.position.x, 0, -10);
    }
}
