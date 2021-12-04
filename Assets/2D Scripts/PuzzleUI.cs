using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour
{
    public Image puzzle;
    public GameObject ClickOffArea;
    public string _name;
    public GameObject[] puzzlesinScene;

    public GameObject p;
    public PlayerControl pc;
   

    void Start()
    {
        puzzle.gameObject.SetActive(false);
        _name = gameObject.transform.name;
        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
        ClickOffArea.SetActive(false);
        puzzlesinScene = GameObject.FindGameObjectsWithTag("puzzle");
    }

    public void Out()
    {
        puzzle.gameObject.SetActive(false);
        ClickOffArea.SetActive(false);
        pc.playerLock = false;
        foreach (GameObject p in puzzlesinScene)
        {
            p.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void PuzzlesOn()
    {
        foreach (GameObject p in puzzlesinScene)
        {
            p.GetComponent<BoxCollider>().enabled = true;
        }
    }
    /// <summary>
    ///  for enableing the puzzle out on click 
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float d = Vector2.Distance(p.transform.position, gameObject.transform.position);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (d < 6f)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == _name)
                    {
                        puzzle.gameObject.SetActive(true);
                        ClickOffArea.SetActive(true);
                        pc.puzzle = gameObject.GetComponent<PuzzleUI>();
                        pc.playerLock = true;
                        foreach (GameObject p in puzzlesinScene)
                        {
                            p.GetComponent<BoxCollider>().enabled = false;
                        }
                    }
                }
            }
        }
    }
}
