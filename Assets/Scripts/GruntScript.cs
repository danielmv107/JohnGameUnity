using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject John;

    private float lastShoot;
    private float Health = 3;

    private void Update()
    {
        if(John == null) return;

        Vector3 direccion = John.transform.position -transform.position;
        if (direccion.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > lastShoot + 0.25f){
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot(){
        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction *0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit(){
        Health = Health - 1;
        if(Health == 0) Destroy(gameObject);
    }

    
}
