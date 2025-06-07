using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject spawnPosObj;
    [SerializeField]
    private Vector3 spawnRange = new Vector3(2, 0, 2);
    private float spawnInterval0 = 2f;
    [SerializeField]
    private float spawnInterval = 2f;
    [SerializeField]
    private float spawnProbability = 0.2f;
    [SerializeField]
    private bool isPassengerSpawner = false;

    private Vector3 spawnPos;

    private void Start()
    {
        spawnPos = spawnPosObj.transform.position;

        if (isPassengerSpawner) GameController.Instance.AddPassengerSpawner(gameObject);

        StartCoroutine(nameof(Spawn));
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            if (Random.Range(0, 1f) > spawnProbability)
            {
                if (GameController.Instance.IsTrafficSpawnRateReducedByHalf) spawnInterval = spawnInterval0 * 2;
                if (GameController.Instance.IsNoTraffic) break;

                yield return new WaitForSeconds(spawnInterval);
                continue;
            }

            float offsetX = Random.Range(-spawnRange.x, spawnRange.x);
            float offsetZ = Random.Range(-spawnRange.z, spawnRange.z);
            GameObject obj = Instantiate(prefab);
            obj.transform.position = spawnPos + new Vector3(offsetX, 0, offsetZ);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
