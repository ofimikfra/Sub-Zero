using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject boulder1;
    public GameObject boulder2;
    public GameObject boulder3;
    public GameObject squid1;
    public GameObject squid2;
    public GameObject squid3;
    private float timerB = 0;
    private float timerS = 0;
    public float spawnRateB = 2;
    public float spawnRateS = 4;

    private float timerTite = 0;
    private float timerMite = 0;
    private float timerC2 = 0;
    private float timerC3 = 0;
    public float spawnRateTite = 8;
    public float spawnRateMite = 6;
    public float spawnRateC2 = 5f;
    public float spawnRateC3 = 4.5f;
    public GameObject stalactite;
    public GameObject stalagmite;
    public GameObject caveobs2;

    public Submarine sub;

    List<GameObject> boulders = new List<GameObject>();
    List<GameObject> squids = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        boulders.Add(boulder1);
        boulders.Add(boulder2);
        boulders.Add(boulder3);
        squids.Add(squid1);
        squids.Add(squid2);
        squids.Add(squid3);
    }

    // Update is called once per frame
    void Update()
    {
        //boulders
        if (timerB < spawnRateB)
        {
            timerB+=Time.deltaTime;
        }
        else
        {
            spawnBoulder();
            timerB = 0;
        }

        //squids
        if (timerS < spawnRateS)
        {
            timerS+=Time.deltaTime;
        }
        else 
        {
            spawnSquid();
            timerS = 0;
        }

        if (timerTite < spawnRateTite)
        {
            timerTite+=Time.deltaTime;
        }
        else
        {
            spawnTite();
            timerTite = 0;
        }

        if (timerMite < spawnRateMite)
        {
            timerMite+=Time.deltaTime;
        }
        else
        {
            spawnMite();
            timerMite = 0;
        }

        if (timerC2 < spawnRateC2)
        {
            timerC2+=Time.deltaTime;
        }
        else
        {
            spawnC2();
            timerC2 = 0;
        }

        if (timerC3 < spawnRateC3)
        {
            timerC3+=Time.deltaTime;
        }
        else
        {
            spawnC3();
            timerC3 = 0;
        }
    }

    void spawnBoulder()
    {
        float low = transform.position.y - 3.5f;
        float high = transform.position.y + 3.5f;
        int prefab = Random.Range(0,3);

        Instantiate(boulders[prefab],new Vector3(transform.position.x, Random.Range(low, high), 0), transform.rotation);
    }

    void spawnSquid()
    {
        float low = transform.position.y - 3.5f;
        float high = transform.position.y + 3.5f;
        int prefab = Random.Range(0,3);
        
        Instantiate(squids[prefab], new Vector3(transform.position.x, Random.Range(low, high), 0), transform.rotation);
    }

    void spawnTite()
    {
        float low = transform.position.y + 3.2f;
        float high = transform.position.y + 6f;
        int prefab = Random.Range(0,3);
        
        Instantiate(stalactite, new Vector3(transform.position.x, Random.Range(low, high), 0), transform.rotation);
    }

    void spawnMite()
    {
        float low = transform.position.y - 6f;
        float high = transform.position.y - 3.2f;
        
        Instantiate(stalagmite, new Vector3(transform.position.x, Random.Range(low, high), 0), transform.rotation);
    }

    void spawnC2()
    {
        float low = transform.position.y - 5f;
        float high = transform.position.y - 4.4f;
        
        Instantiate(caveobs2, new Vector3(transform.position.x, Random.Range(low, high), 0), transform.rotation);
    }

    void spawnC3()
    {
        float low = transform.position.y + 4.4f;
        float high = transform.position.y + 5f;

        Quaternion rotation = Quaternion.Euler(0f, 0f, 180f);
        Instantiate(caveobs2, new Vector3(transform.position.x, Random.Range(low, high), 0), rotation);
    }
}
