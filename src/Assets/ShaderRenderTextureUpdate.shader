Shader "CustomRenderTexture/Update"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Tex("InputTex", 2D) = "white" {}
	}

	SubShader
	{
		Lighting Off
	    Blend SrcAlpha OneMinusSrcAlpha

	    Pass
	    {
			Name "Update"
			CGPROGRAM
			#include "UnityCustomRenderTexture.cginc"
			#pragma vertex CustomRenderTextureVertexShader
			#pragma fragment frag
			#pragma target 3.0

			float      _OffsetX;
			float      _OffsetZ;
			float      _TexScale;
			float4	   _Color;
			sampler2D   _Tex;

			float4 frag(v2f_customrendertexture IN) : COLOR
			{
				float3 rgb = _Color;
				float a = tex2D(_Tex, (IN.localTexcoord.xy - float2(_OffsetX, _OffsetZ)) * _TexScale + 0.5).a;
				return float4(rgb, a);
		    }
			ENDCG
		}
	}
}
