using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData {
    public string nickname;
    public int totalTime;
    public LinkedList<int> augmentIds;
    private LinkedList<Log> logs;

    public PlayerData(string nickname) {
        this.nickname = nickname;
        augmentIds = new LinkedList<int>();
        logs = new LinkedList<Log>();
    }

    public void Insert(int time, Vector3 position) {
        this.logs.AddLast(new Log { time = time, position = position });
    }
}

[System.Serializable]
public class Log {
    public int time;
    public Vector3 position;
}
