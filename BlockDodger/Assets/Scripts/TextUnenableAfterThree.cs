using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUnenableAfterThree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObscureAfterThree());
    }

    IEnumerator ObscureAfterThree()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
