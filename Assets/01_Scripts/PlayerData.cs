using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int maxHp = 100;
    public int curHp = 100;

    public float fatigue = 0;

    public int maxGold = 1000000;
    public int curGold = 0;

    public int day = 1;
    public float currentTime = 0;

    public int maxStorage = 10;
    public int curStorage = 0;
}
