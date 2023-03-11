using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassSpawner : MonoBehaviour
{
    #region Instance
    public static MassSpawner ins ;

    private void Awake() {
        ins = this;    
    }
    #endregion
    public GameObject Mass ;
    public List<GameObject> Players = new List<GameObject>() ;
    public List<GameObject> CreatedMasses = new List<GameObject>();
    public int MaxMass = 50 ;
    public float Time_To_Create_Mass = 0.5f ;
    public Vector2 pos ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateMass());
    }
    public IEnumerator CreateMass(){
        yield return new WaitForSecondsRealtime(Time_To_Create_Mass);
        if (CreatedMasses.Count < MaxMass) {
            Vector2 p = new Vector2(Random.Range(-pos.x,pos.x) , Random.Range(-pos.y , pos.y)) ;
            p /= 2 ;
            GameObject m = Instantiate(Mass , p , Quaternion.identity) ;
            AddMass(m);
            for (int i = 0 ; i < Players.Count ; i ++ ) {
                PlayerEatMass pp = Players[i].GetComponent<PlayerEatMass>();
                pp.AddMass(m);
            }
        }
        StartCoroutine(CreateMass());
    }
    public void AddMass(GameObject m ){
        if (CreatedMasses.Contains(m)== false) {
            CreatedMasses.Add(m) ;
        }
    }
    public void removeMass(GameObject m ){
        if (CreatedMasses.Contains(m)== true) {
            CreatedMasses.Remove(m) ;
        }
    }
    // Update is called once per frame
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position , pos);
    }
}
