using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingObject : MonoBehaviour
{
    public float timeBeforeDisappear = 3f;
    public float timeToDisappear = 3f;

    void Update()
    {
        
    }

    public void StartDeath()
    {
        StartCoroutine(WaitCoroutine());
    }

    public IEnumerator WaitCoroutine()
    { 
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeBeforeDisappear);
        Destroy(gameObject);
    }

    //IEnumerator DisappearCoroutine()
    //{
    //    yield return new WaitForSeconds(
    //}
}
