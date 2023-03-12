using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovements : MonoBehaviour
{
    public float Speed = 5f;
    Actions actions ;
    // Start is called before the first frame update
    void Start()
    {
        actions = GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Speed / transform.localScale.x ;
        Vector2 Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position , Direction , speed *Time.deltaTime);
        if (Input.GetKey(KeyCode.Space)){
            actions.TrowMass();
        }
    }
}
