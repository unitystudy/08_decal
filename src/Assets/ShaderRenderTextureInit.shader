Shader "CustomRenderTexture/Initialize"
{
	SubShader
	{
		Pass
		{
			Name "Initialize"
			CGPROGRAM
			#include "UnityCustomRenderTexture.cginc"
			#pragma vertex InitCustomRenderTextureVertexShader
			#pragma fragment frag
			#pragma target 3.0

			half4 frag(v2f_init_customrendertexture i) : SV_Target
			{
				return half4(0.5, 0.5, 0.5, 0.0);
			}
			ENDCG
		}
	}
}
