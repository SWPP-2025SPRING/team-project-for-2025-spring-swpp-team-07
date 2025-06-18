using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMIndicator : MonoBehaviour
{
    public float length = 20f;
    public GameObject player;
    private GameObject checkpoint; 

    private void Update()
    {
        Vector3 dir = Vector3.Normalize(checkpoint.transform.position - player.transform.position);
        transform.position = player.transform.position + length * dir;
        transform.LookAt(checkpoint.transform, Vector3.right);
    }

    public void SetCheckpoint(GameObject cp){
        checkpoint = cp;
    }
}
