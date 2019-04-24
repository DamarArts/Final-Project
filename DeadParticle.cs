using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadParticle : MonoBehaviour
{
    public GameObject enemy;
    public bool jewelactivity;

    void Update()
    {
        if (enemy.gameObject.activeSelf)
        {
            transform.position = enemy.transform.position;
        }

        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f * Time.deltaTime, 0) ;
        }
    }
}
