using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject Mass;
    public Transform MassPosition ;

    public float percentage = 0.1f ;
    PlayerEatMass PlayerMass ;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMass = GetComponent<PlayerEatMass>();
    }
    public void TrowMass(){
        if (transform.localScale.x <= 1 ){
            return ;
        }
        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float zr = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg + 90f ;
        transform.rotation = Quaternion.Euler(0 , 0 ,zr) ;
        GameObject b = Instantiate(Mass , MassPosition.position , Quaternion.identity);
        b.GetComponent<MassForce>().ApplyForce = true ;
        PlayerMass.AddMass(b);
        transform.localScale -= new Vector3(0.05f , 0.05f , 0.05f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(percentage , percentage , percentage) * Time.deltaTime;
    }
}
