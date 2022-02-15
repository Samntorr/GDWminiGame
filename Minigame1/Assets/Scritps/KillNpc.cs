using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNpc : MonoBehaviour
{
    // Needed to get rid of npcs so they don't spawn in endlessly
    void Start()
    {
        StartCoroutine(DestroyExtra());
    }

    IEnumerator DestroyExtra()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
