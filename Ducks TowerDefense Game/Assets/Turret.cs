using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

//Ep 4, lock the turret to enemy around 15 min
public class Turret : MonoBehaviour{

    private Transform target;
    public float range = 3f;
    public string enemyTag = "Enemy";
    public float rotationSpeed = 5f; // Speed at which the turret rotates

    //public Transform partToRotate;//I dont think we need it

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //find all the enemies and store it into this array

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range){ //Find the nearest enemy within the range of turret
            target = nearestEnemy.transform;
        }
        else{ //If enemy exceed range, return null till new enemy come within range
            target = null;
        }
    }
    // Update is called once per frame
    void Update(){
        if(target == null){
            return;
        }

        // Calculate the direction to the target
        Vector3 direction = target.position - transform.position;

        // Calculate the angle in radians and convert to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a target rotation using the calculated angle
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        // Smoothly rotate the turret towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    }

    void OnDrawGizmosSelected(){ //Draw the range of the turret
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
