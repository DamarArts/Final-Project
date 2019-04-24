using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
