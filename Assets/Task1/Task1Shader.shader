Shader "Tutorial/Task1Shader"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "" {}
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct AppData
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct VertData
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			
			VertData vert(AppData i)
			{
				VertData o;
				o.pos = UnityObjectToClipPos(i.pos);
				o.uv = i.uv;
				return o;
			}
			
			float4 frag(VertData i) : SV_Target
			{
				float4 col = tex2D(_MainTex, i.uv);
				return col;
			}
			ENDCG
		}
	}
}
