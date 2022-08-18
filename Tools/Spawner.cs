using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    //private enum Direction { Up, Down, Left, Right }
    private Coroutine spawnRoutine;

    public List<GameObject> spawnedList { get; private set; }

    [SerializeField] GameObject obj;
    [SerializeField] Vector3 spawnDirection;
    [SerializeField] bool applyForce;
    [SerializeField] float frequencyInSeconds;



    private void Awake()
    {
        spawnedList = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnRoutine = StartCoroutine(Spawn());
    }
    
    IEnumerator Spawn()
    {

        while(true)
        {
            yield return new WaitForSeconds(frequencyInSeconds);

            GameObject spawned = Instantiate(obj, this.transform.position, Quaternion.identity);
            
            if (applyForce)
            {
                Rigidbody2D rb;
                if (!CheckError.CheckComponentIsNull(rb = spawned.GetComponent<Rigidbody2D>(),nameof(Rigidbody2D),nameof(spawned), this))
                {
                    rb.AddForce(spawnDirection, ForceMode2D.Impulse);
                }
            }

            spawnedList.Add(spawned);


        }

    }


    public void Stop()
    {
        StopCoroutine(spawnRoutine);
    }

    public void StartSpawn()
    {
        if (spawnRoutine == null)
        {
            spawnRoutine = StartCoroutine(Spawn());
        }
        else
        {
            Debug.Log("Spawn just in execution", this);
        }
    }
}
