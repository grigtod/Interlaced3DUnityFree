Shader "Depth" 
{

	//http://answers.unity3d.com/questions/404637/subtractive-rendering.html
     SubShader 
	 {
        Tags {"Queue"="Background" }
		Blend SrcAlpha OneMinusSrcAlpha	
        Lighting On
		ColorMask 0
        ZWrite On
		//Cull Off
        Pass
        {
             Material
             {
                 Diffuse (0,0,0,0)
             }
		}
     } 

 FallBack Off
 }




