using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMIndicator : MonoBehaviour
{
    public TMPro.TextMeshProUGUI distUI;
    public GameObject player;
    private float length = 20f;
    private GameObject checkpoint;

    private const float amp = 2f;
    private const float freq = 2f;

    private void Update()
    {
        Vector3 vector = checkpoint.transform.position - player.transform.position;
        Vector3 dir = Vector3.Normalize(vector);
        transform.position = player.transform.position + (length + amp * Mathf.Sin(Time.time * freq)) * dir;

        Quaternion rotation = Quaternion.LookRotation(dir, transform.up);
        transform.rotation = rotation * Quaternion.Euler(0, -90, 0);

        Vector3 pos = transform.position;
        transform.position = new(pos.x, player.transform.position.y + 30, pos.z);

        distUI.text = $"Target: {vector.magnitude:F0}m";
    }

    public void SetCheckpoint(GameObject cp){
        checkpoint = cp;
    }
}
