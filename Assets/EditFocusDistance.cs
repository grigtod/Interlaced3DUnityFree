using UnityEngine;
using System.Collections;

public class EditFocusDistance : MonoBehaviour 
{
    public GameObject focusGameObject;

    public void ChangeFocusDistance(UnityEngine.UI.Slider sliderRef)
    {
        focusGameObject.transform.localPosition = new Vector3(0, 0, sliderRef.value);
    }
}
