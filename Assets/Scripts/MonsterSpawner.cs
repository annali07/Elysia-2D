using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
   
    private void Start()
    {
        StartCoroutine(SpawnMonsters());



    }


    IEnumerator SpawnMonsters()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(4, 7));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);



            //leftside
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Ghost>().speed = 5f;
            }
            //right side
            else
            {

                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Ghost>().speed = -5f;
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
