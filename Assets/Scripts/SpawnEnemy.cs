using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public bool canSpawn;

    [SerializeField] private GameObject m_Enemy;
    [SerializeField] private GameObject m_Target;

    [SerializeField] private float angle;
    [SerializeField] private float distance;

    [SerializeField] private float spawnRate;

    private float spawnTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnRate)
        {
            if (canSpawn)
            {
                GameObject newEnemy = Instantiate(m_Enemy, transform);
                newEnemy.GetComponent<Enemy>().target = m_Target.transform;
                newEnemy.GetComponent<Enemy>().SetParams(distance, angle);
            }

            spawnTime = 0f;
        }
    }
}
