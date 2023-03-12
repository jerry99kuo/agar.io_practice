using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassForce : MonoBehaviour
{
    public bool ApplyForce = false ;
    public float Speed = 30f ;
    public float LoseSpeed = 140f ;
    public float Randomrotation = 10f ;
    public float Randomforce = 5f ;
    // Start is called before the first frame update
    void Start()
    {
        if (ApplyForce == false ) {
            enabled = false ;
            return ;
        }
        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float zr = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg + 90f ;
        zr += Random.Range(-Randomrotation , Randomrotation);
        transform.rotation = Quaternion.Euler(0 , 0 , zr ) ;
        Speed += Random.Range(-Randomforce , Randomforce);

    }

    // Update is called once per frame
    void Update()
    {
        if (ApplyForce){
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
            Speed -= LoseSpeed * Time.deltaTime ;
            if (Speed <= 0 ){
                enabled =  false ;
            }
        }
    }
}
