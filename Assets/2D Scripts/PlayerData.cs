using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public string levelName;
    public float[] position;
    public float hp;
    public float BatteryLife;
    public bool haveFlashlight;
    public bool haveLighter;
    public bool haveSprayCan;
    public string handslot;
    public string Itemslot1;
    public string Itemslot2;
    public string Itemslot3;
    public string Itemslot4;
    public string Itemslot5;
    public string Itemslot6;

    public PlayerData(PlayerControl player)
    {
        levelName = SceneManager.GetActiveScene().name;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;

        hp = player.hp;
        BatteryLife = player.batteryLife;

       /// haveFlashlight = player.haveFlashlight;
       //haveLighter = player.haveLighter;
       // haveSprayCan = player.haveSprayCan;

        if (player.flashlightHand.transform.childCount > 0)
            handslot = player.flashlightHand.transform.GetChild(0).gameObject.name;
        if (player.ItemSlots[1].childCount > 0)
            Itemslot1 = player.ItemSlots[1].transform.GetChild(0).gameObject.name;
        if (player.ItemSlots[2].childCount > 0)
            Itemslot2 = player.ItemSlots[2].transform.GetChild(0).gameObject.name;
        if (player.ItemSlots[3].childCount > 0)
            Itemslot3 = player.ItemSlots[3].transform.GetChild(0).gameObject.name;
        if (player.ItemSlots[4].childCount > 0)
            Itemslot4 = player.ItemSlots[4].transform.GetChild(0).gameObject.name;
        if (player.ItemSlots[5].childCount > 0)
            Itemslot5 = player.ItemSlots[5].transform.GetChild(0).gameObject.name;
        if (player.ItemSlots[6].childCount > 0)
            Itemslot6 = player.ItemSlots[6].transform.GetChild(0).gameObject.name;
    }
}
