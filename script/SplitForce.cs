using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitForce : MonoBehaviour
{
    public float Speed ;
    public float LoseSpeed;
    public float DefaultSpeed ;

    public bool ApplySplitForce  = false ;

    public void SplitForce_Method(){
        Vector2 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(dir.y , dir.x) * Mathf.Rad2Deg + 90f ;
        transform.rotation = Quaternion.Euler(0 , 0 , angle ) ;
        Speed = DefaultSpeed ;
        ApplySplitForce = true ;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ApplySplitForce == false ) {
            enabled = false ;
            return ;
        }
        transform.Translate(Vector2.up * Speed * Time.deltaTime) ;
        Speed -= LoseSpeed * Time.deltaTime ;
        if (Speed <= 0 ) {
            enabled = false ;
        }
    }
}
