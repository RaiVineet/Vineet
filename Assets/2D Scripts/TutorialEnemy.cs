using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public float moveSpeed;

    private void Start()
    {
        StartCoroutine(tutorialEnemyKill());
    }

    IEnumerator tutorialEnemyKill()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
    }
}
