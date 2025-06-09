using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;

public static class PlayerDataSaveLoad {
    public static void SaveData(PlayerData playerData) {
        try {
            string json = JsonUtility.ToJson(playerData);
            Debug.Log(json);
            string timestamp = ((int)System.DateTimeOffset.UtcNow.ToUnixTimeSeconds()).ToString();

            UnityWebRequest request = new UnityWebRequest("http://localhost:4000", "POST");

            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SendWebRequest();
            Debug.Log("Request sent");
        } catch (Exception e) {
            Debug.Log("A");
            Debug.LogError("Failed to save data: " + e.Message);
        }
    }
}
