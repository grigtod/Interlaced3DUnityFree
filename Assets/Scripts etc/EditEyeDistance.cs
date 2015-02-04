using UnityEngine;
using System.Collections;

public class EditEyeDistance : MonoBehaviour 
{
    public GameObject leftEyeRef;
    public GameObject rightEyeRef;

    public void ChangeEyeDistance(UnityEngine.UI.Slider sliderRef)
    {
        leftEyeRef.transform.localPosition = new Vector3(-sliderRef.value/2, 0, 0);
        rightEyeRef.transform.localPosition = new Vector3(sliderRef.value/2, 0, 0);
    }
}
