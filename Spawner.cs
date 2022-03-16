using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float Xmin,Xmax,Ymin,Ymax;
    [SerializeField]float Time_SpawnerCD_MIN, Time_SpawnerCD_MAX;
    [SerializeField] GameObject Havchik;


    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(Time_SpawnerCD_MIN, Time_SpawnerCD_MAX));
        Instantiate(Havchik,new Vector3(this.transform.position.x+Random.Range(Xmin, Xmax), this.transform.position.y+Random.Range(Ymin, Ymax),0),Quaternion.identity);
        StartCoroutine(Spawn());
    }

}
