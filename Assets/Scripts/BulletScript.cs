using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed; 

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Rigidbody2D.velocity= Direction * Speed;
    }

    public void SetDirection(Vector3 direction){
        Direction = direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JohnMovent john = collision.GetComponent<JohnMovent>();
        GruntScript grunt = collision.GetComponent<GruntScript>();

        if(john != null){
            john.Hit();
        }
        if(grunt != null){
            grunt.Hit();
        }

        DestroyBullet();
    }
    

}
