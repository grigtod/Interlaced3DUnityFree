using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class GenerateInterlacedGeometry : MonoBehaviour 
{
    public bool inverse = false;
    public int ignoreLayerIndex;

    private Camera camRef;
    private List<GameObject> quads = new List<GameObject>();
  
    private Vector3 cornerSW;
    private Vector3 cornerSE;
    private Vector3 cornerNW;
    private Vector3 cornerNE;
    private Vector3 middle;

    void CalculateCorners()
    {
        //http://forum.unity3d.com/threads/how-to-get-the-actual-width-and-height-of-the-near-clipping-plane.72384/
        cornerNW = camRef.ScreenToWorldPoint(new Vector3(0, (float)(Screen.height - 1), camRef.nearClipPlane + .0001f));
        cornerNE = camRef.ScreenToWorldPoint(new Vector3((float)(Screen.width - 1), (float)(Screen.height - 1), camera.nearClipPlane + .0001f));
        cornerSW = camRef.ScreenToWorldPoint(new Vector3(0, 0, camRef.nearClipPlane + .0001f));
        cornerSE = camRef.ScreenToWorldPoint(new Vector3((float)(Screen.width - 1), 0, camRef.nearClipPlane + .0001f));

        middle = camRef.ScreenToWorldPoint(new Vector3((float)(Screen.width - 1)/2, (float)(Screen.height - 1) / 2, camRef.nearClipPlane + .0001f));

        //Debug.DrawLine(cornerNW, cornerSE,Color.red);
        //Debug.DrawLine(cornerNE, cornerSW, Color.red);
    }

    public Material depthMat;

    void Awake()
    {
        if (camRef == null)
        {
            camRef = GetComponent<Camera>();
        }
        CalculateCorners();
        GenerateQuads();
    }

    void GenerateQuads()
    {
        if (quads.Count > 0)
        {
            for (int i = 0; i < quads.Count; i++)
            {
                Destroy(quads[i].gameObject);
            }
            quads.Clear();
        }
        float quadWidth = (cornerNE.x - cornerNW.x)/(Screen.width);
        float quadHeight = (cornerSE.y - cornerNE.y);
        int iStart = 0;
        if (inverse)
        {
            iStart = 0;
        }
        else
        {
            iStart = 1;
        }
        
        for (int i = iStart; i < Screen.width; i+=2)
        {
            quads.Add(GameObject.CreatePrimitive(PrimitiveType.Quad));
            int index = quads.Count - 1;
            quads[index].renderer.material = depthMat;

            quads[index].transform.parent = this.transform;
            quads[index].transform.localScale = new Vector3(quadWidth, quadHeight, 1);
            quads[index].transform.position = new Vector3(cornerNW.x + i * quadWidth, middle.y, middle.z);
            quads[index].transform.rotation = camRef.transform.rotation;
            quads[index].layer = ignoreLayerIndex;
        }
    }


}
