using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update ()
    {
        transform.position = player.transform.position + offset;
    }
}