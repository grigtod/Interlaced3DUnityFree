using UnityEngine;
using System.Collections;

public class CamLookAt : MonoBehaviour 
{
    public Transform focalPoint;
    private float refRate;

    void Start()
    {
        StartCoroutine("LookAtUpdate");
    }

    IEnumerator LookAtUpdate()
    {
        while (true)
        {
            transform.LookAt(focalPoint.position);
            yield return new WaitForSeconds(refRate);
        }
    }

}
