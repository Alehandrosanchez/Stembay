using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Timer;
    public float BoomParticleTimer;
    public float BoomColTimer;
    [SerializeField] GameObject Boom;
    [SerializeField] GameObject BoomCol;
    void Start()
    {
        StartCoroutine(Booms());
    }
    IEnumerator Booms()
    {
        yield return new WaitForSeconds(Timer);
        GameObject newBoom = Instantiate(Boom,this.transform.position,Quaternion.identity);
        GameObject newBoomCol = Instantiate(BoomCol, this.transform.position, Quaternion.identity);
        Destroy(newBoom, BoomParticleTimer);
        Destroy(newBoomCol, BoomColTimer);
        Destroy(this.gameObject,0);
    }
}
