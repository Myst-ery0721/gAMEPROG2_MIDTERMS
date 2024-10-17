using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float stopDistance = 0.5f;
    private GameOver gameOver; 

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

       
        gameOver = FindObjectOfType<GameOver>();
        if (gameOver == null)
        {
            Debug.LogError("GameOver script not found in the scene!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= stopDistance)
        {
            DestroyPlayer();
        }
        else
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void DestroyPlayer()
    {
        if (gameOver != null) 
        {
            gameOver.TriggerGameOver(); 
        }

        Destroy(player.gameObject); 
        Destroy(gameObject); 
    }
}
