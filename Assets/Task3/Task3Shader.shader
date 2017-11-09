Shader "Tutorial/Task3Shader"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "" {}
		// 1 TODO: Add a float property with Range(0,1) named _Displacement
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
				float3 normal : NORMAL;
			};

			struct VertData
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;

			// 2 TODO: Add the float property named _Displacement, so that it matches with the Property in TODO #1
		
			VertData vert(AppData i)
			{
				VertData o;
				o.uv = i.uv;
				float DisplaceFactor = 1;

				// 3 TODO: Sample the _MainTex by using tex2Dlod(), and take only the Red channel as the DisplaceFactor
				// 4 TODO: modify the vertex position (i.pos) based on DisplaceFactor and _Displacement so that it displaces outward along the vertex normal (i.normal)

				o.pos = UnityObjectToClipPos(i.pos);
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
