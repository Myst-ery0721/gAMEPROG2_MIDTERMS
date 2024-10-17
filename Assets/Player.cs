using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 1.0f;
    private float shootTimer = 0;

    public float rotationSpeed = 5.0f;
    public float range = 5.0f;


    public Color[] circleColors = { Color.red, Color.yellow, Color.blue };
    private int currentColorIndex = 0;
    public SpriteRenderer circleRenderer;

    void Start()
    {
      
        if (circleColors.Length > 0)
        {
            currentColorIndex = 0;
            circleRenderer.color = circleColors[currentColorIndex];
        }
    }

    GameObject FindNearestEnemy()
    {
    
        string[] colorTags = { "Red", "Yellow", "Blue" };
        GameObject nearest = null;
        float minDist = range;

        foreach (string colorTag in colorTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(colorTag);
            foreach (GameObject enemy in enemies)
            {
                float dist = Vector2.Distance(transform.position, enemy.transform.position);
                if (dist < minDist)
                {
                    nearest = enemy;
                    minDist = dist;
                }
            }
        }
        return nearest;
    }

    void RotateTowards(GameObject target)
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            RotateTowards(nearestEnemy);
        }

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
        
            string[] colorTags = { "Red", "Yellow", "Blue" };
            bulletScript.SetEnemyTag(colorTags[currentColorIndex]);
        }
    }


    private void OnMouseDown()
    {
        ChangeCircleColor();
    }

    public void ChangeCircleColor()
    {

        currentColorIndex = (currentColorIndex + 1) % circleColors.Length;

        circleRenderer.color = circleColors[currentColorIndex];
    }
}
