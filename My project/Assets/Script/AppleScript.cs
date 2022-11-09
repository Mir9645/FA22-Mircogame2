using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public GameObject[] Apples;
    public float secondSpawn;
    public float minTras;
    public float maxTras;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnApples());
    }

    IEnumerator SpawnApples()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(Apples[Random.Range(0, Apples.Length)],
                position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
        
    }
}
