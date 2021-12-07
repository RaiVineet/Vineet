using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryItemUse : MonoBehaviour
{
    public GameObject Player;
    public PlayerControl pc;
    public Button UseButton;
    public Button InspectButton;
    public GameObject panel;
    public Animator anim;

    public GameObject textObj;

    bool _active;

    void Start()
    {
        panel.SetActive(true);
        UseButton.enabled = false;
        InspectButton.enabled = false;
        _active = false;
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            pc = Player.GetComponent<PlayerControl>();
            textObj = GameObject.FindGameObjectWithTag("Player Text");
        }
    }

    public void ClickOn()
    {
        panel.SetActive(true);
        UseButton.enabled = true;
        InspectButton.enabled = true;
        _active = true;
    }

    public void EquipLigher()
    {
        pc.EquipLighter();
        panel.SetActive(true);
        _active = false;
    }

    public void EquipFlashlight()
    {
        
        pc.EquipFlashlight();
        panel.SetActive(true);
        _active = false;
    }

    public void CombineSprayCan()
    {
        pc.CombineSprayCan();
        panel.SetActive(true);
        _active = false;
    }

    public void Use()
    {
        switch (gameObject.name)   //switch statement to find the item
        {
            case "KeyPrefab(Clone)":
                pc.WhichUseItem("Key");
                break;
            case "Key2Prefab(Clone)":
                pc.WhichUseItem("Key2");
                break;
            case "Key3Prefab(Clone)":
                pc.WhichUseItem("Key3");
                break;
            case "Key4Prefab(Clone)":
                pc.WhichUseItem("Key4");
                break;
            case "Key5Prefab(Clone)":
                pc.WhichUseItem("Key5");
                break;
            case "Key6Prefab(Clone)":
                pc.WhichUseItem("Key6");
                break;

            case "LighterPrefab(Clone)":
                pc.WhichUseItem("Lighter");
                break;
            case "Lightbulb1Prefab(Clone)":
                pc.WhichUseItem("Lightbulb1");
                break;
            case "Lightbulb2Prefab(Clone)":
                pc.WhichUseItem("Lightbulb2");
                break;
            case "Lightbulb3Prefab(Clone)":
                pc.WhichUseItem("Lightbulb3");
                break;
        }

        //change cursor to a new 'use' cursor
        panel.SetActive(false);
        UseButton.enabled = false;
        InspectButton.enabled = false;
    }

    public void Inspect()
    {
        StartCoroutine(InspectTimer());
    }

    IEnumerator InspectTimer()
    {
        switch (gameObject.name)   //switch statement to find the item
        {
            case "KeyPrefab(Clone)":
                pc.InspectText.text = "It's a small key.";
                break;
            case "Key2Prefab(Clone)":
                pc.InspectText.text = "It's another key. Will this fit in that lock?";
                break;
            case "Key3Prefab(Clone)":
                pc.InspectText.text = "It's another key.";
                break;
            case "Key4Prefab(Clone)":
                pc.InspectText.text = "It's another key.";
                break;
            case "Key5Prefab(Clone)":
                pc.InspectText.text = "The key from the cabinet. I think there was a locked door over there.";
                break;
            case "LighterPrefab(Clone)":
                pc.InspectText.text = "It's a lighter.";
                break;
            case "Lightbulb1Prefab(Clone)":
                pc.InspectText.text = "It's a lightbulb.";
                break;
            case "Lightbulb2Prefab(Clone)":
                pc.InspectText.text = "It's a lightbulb.";
                break;
            case "Lightbulb3Prefab(Clone)":
                pc.InspectText.text = "It's a lightbulb.";
                break;
            case "SprayCanPrefab(Clone)":
                pc.InspectText.text = "It's a spray can.";
                break;
        }
        pc.InspectText.enabled = true;
        panel.SetActive(false);
        UseButton.enabled = false;
        InspectButton.enabled = false;
        _active = false;

        yield return new WaitForSeconds(3.0f);

        pc.InspectText.enabled = false;
    }

    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            pc = Player.GetComponent<PlayerControl>();
            textObj = GameObject.FindGameObjectWithTag("Player Text");
            pc.InspectText = textObj.GetComponent<TextMeshProUGUI>();
        }
        if (_active)
        {
            if (Input.GetMouseButton(0) && panel.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(), Input.mousePosition, Camera.main))
            {
                panel.SetActive(false);
                _active = false;
            }
        }
    }
}
