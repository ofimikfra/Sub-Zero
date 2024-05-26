using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPoint : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public GameObject player;
    public Vector3 offset;

    void Update () 
    {
        if (player!=null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
