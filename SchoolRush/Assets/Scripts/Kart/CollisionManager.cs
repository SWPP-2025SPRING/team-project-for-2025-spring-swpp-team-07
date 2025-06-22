using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Rigidbody rb;
    private const float bumpCoef = 3000f;

    [SerializeField]
    private KartController kartController;
    
    [Header("ID 순서대로 0~6 체크포인트 오브젝트를 넣어주세요")]
    public GameObject[] checkpoints;           // 0→ID=0(시작지점), … , 6→ID=6(도착지점)

    private void Start() {
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < checkpoints.Length; i++)
            checkpoints[i].SetActive(false);

        checkpoints[kartController.GetNextCheckpointID()].SetActive(true);
    }

    private void Update()
    {
        // 개발용 치트키: checkpoint 로 순간이동
        #if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            for (int i = 0; i <= 6; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i) || Input.GetKeyDown(KeyCode.Keypad0 + i))
                {
                    Debug.Log($"Cheat: Teleporting to checkpoint {i}");
                    GoToCheckPoint(i);
                    break;
                }
            }
        }
        #endif
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager audioManager = AudioManager.Instance;
        GameObject gameObject = collision.gameObject;

        if (gameObject.CompareTag("Passenger")) {
            ShieldResult shieldResult = kartController.UseShield();
            if (shieldResult == ShieldResult.Succeed) return;
            GoToCheckPoint(kartController.GetNextCheckpointID() - 1);
            audioManager.PlayOneShot(audioManager.hitPassengerAudio);
        } else if (gameObject.CompareTag("Traffic")) {
            ShieldResult shieldResult = kartController.UseShield();
            if (shieldResult == ShieldResult.Succeed) return;
            audioManager.PlayOneShot(audioManager.hitTrafficAudio);
            NotifyDizziness();
            Vector3 v = transform.position - gameObject.transform.position + Vector3.up;
            rb.AddForce(bumpCoef * v, ForceMode.Impulse);
        } else if (gameObject.CompareTag("Building")) {
            audioManager.PlayOneShot(audioManager.hitWallAudio);
        } else if (gameObject.CompareTag("Terrain")) {
            kartController.SetAsOnGround();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Checkpoint")) return;
        int checkpointID = other.GetComponent<CheckpointIdentifier>().ID;
        if (checkpointID != kartController.GetNextCheckpointID()) return;

        OnEnterCheckpoint(checkpointID);
    }

    private void OnEnterCheckpoint(int checkpointID)
    {
        Debug.Log($"체크포인트 {checkpointID} 도착!");
        checkpoints[checkpointID].SetActive(false);
        kartController.IncrementNextCheckpointID();

        if (kartController.GetNextCheckpointID() < checkpoints.Length) checkpoints[kartController.GetNextCheckpointID()].SetActive(true);
    }

    public void GoToCheckPoint(int id)
    {
        transform.position = checkpoints[id].transform.Find("PortPos").position;
    }

    private void NotifyDizziness() {
        kartController.GetDizzy();
    }
}
