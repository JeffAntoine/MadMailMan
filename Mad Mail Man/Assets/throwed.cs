using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwed : MonoBehaviour{
    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public Transform BulletTrailPreFab;
    float timeToFire;
    float timeToSpawnEffect=0;
    public float effectSpawnRate = 10;

    Transform firePoint;


    private void Awake(){
        firePoint = transform.Find("FirePoint");
        if (firePoint == null){
            Debug.LogError("fire point not found");
        }
    }
    void Update(){
       // Shoot(); //would shoot continously if un-commented
        if (fireRate == 0){
            if (Input.GetButtonDown("Fire1")){
                Shoot();
            }
        }
        else{
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFire){
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    void Shoot(){
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        //limit throwing
        if (Time.time > timeToSpawnEffect){
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        //Effect();
        Debug.DrawLine(firePointPosition,(mousePosition-firePointPosition)*100, Color.black);
        if (hit.collider != null){
            Debug.DrawLine(firePointPosition,hit.point, Color.red );
            Debug.Log("We Hit "+hit.collider.name + " and did "+Damage+" damage.");
        }
    }
    void Effect(){
        Instantiate(BulletTrailPreFab, firePoint.position, firePoint.rotation);
    }
}
