Shader "Tutorial/Task2Shader"
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

			// 1 TODO: Add color property named _GradientStartColor
			// 2 TODO: Add color property named _GradientEndColor
			
			float4 frag(VertData i) : SV_Target
			{
				float4 col = tex2D(_MainTex, i.uv);
				// 3 TODO: Make linear gradient between _GradientStartColor and _GradientEndColor
				float4 gradient = 1;
				return col * gradient;
			}
			ENDCG
		}
	}
}
