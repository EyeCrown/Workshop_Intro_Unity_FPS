using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public bool canSpawn;

    [SerializeField] private GameObject m_Enemy;
    [SerializeField] private GameObject m_Target;
    [SerializeField] private GameObject m_PatrolPointsParent;

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

        if (spawnTime >= spawnRate && canSpawn)
        {
            spawnTime = 0f;
            GameObject newEnemy = Instantiate(m_Enemy, transform);
            newEnemy.GetComponent<Enemy>().target = m_Target.transform;
            newEnemy.GetComponent<Enemy>().SetParams(distance, angle, GeneratePatrolPoints(m_PatrolPointsParent));
        }
    }

    private List<Transform> GeneratePatrolPoints(GameObject parentGameObject)
    {
        List<Transform> points = new List<Transform>();

        foreach (Transform child in parentGameObject.GetComponentInChildren<Transform>())
        {
            points.Add(child);
        }

        return points;
    }
}
