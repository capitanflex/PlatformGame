using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   
    private void Start() {
        StartCoroutine(DestroyBullet());
    }
    public GameObject f;
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(f);
    }
}
