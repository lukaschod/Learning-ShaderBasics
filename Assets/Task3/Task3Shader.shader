Shader "Tutorial/Task3Shader"
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
				uint id : SV_VertexID; // This is the index of vertex in buffer
			};

			struct VertData
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			struct CustomBufferData
			{
				float4 pos;
				float2 uv;
			};

			sampler2D _MainTex;

			// 1 TODO: Add buffer property _CustomBuffer
			RWStructuredBuffer<CustomBufferData> _CustomBuffer;
			
			VertData vert(AppData i)
			{
				VertData o;
				//CustomBufferData data; // 2 TODO: Read from _CustomBuffer array to data, use i
				CustomBufferData data = _CustomBuffer[i.id];
				o.pos = UnityObjectToClipPos(data.pos);
				o.uv = data.uv;
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
