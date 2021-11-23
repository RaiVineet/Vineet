using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickoutUI : MonoBehaviour
{
    public GameObject p;
    public PlayerControl pc;

    public GameObject puzzle;
    public PuzzleUI PUI;

    void Start()
    {
        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
        PUI = puzzle.GetComponent<PuzzleUI>();
    }

    public void Out()
    {
        pc.PuzzleOut();
        pc.playerLock = false;
    }
}
