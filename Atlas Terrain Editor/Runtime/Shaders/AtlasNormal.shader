Shader "Hidden/Atlas/AtlasNormal"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
	SubShader
	{

		ZTest Always
		ZWrite Off
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float _Strength;
			float _Height;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = float4(v.vertex.xy * 2 - 1, 0, 1);
				o.vertex.y *= -1;
				o.uv = v.uv;
				return o;
			}
			
			float4 frag (v2f i) : SV_Target
			{


				float4 uvlod = float4(i.uv,0,0);

				float4 h;
				h[0] = tex2Dlod(_MainTex, uvlod + float4(_Strength * float2(0, -1), 0, 0)).r * _Height;
				h[1] = tex2Dlod(_MainTex, uvlod + float4(_Strength * float2(-1, 0), 0, 0)).r * _Height;
				h[2] = tex2Dlod(_MainTex, uvlod + float4(_Strength * float2(1, 0), 0, 0)).r * _Height;
				h[3] = tex2Dlod(_MainTex, uvlod + float4(_Strength * float2(0, 1), 0, 0)).r * _Height;
				
				float3 n;

				n.z = h[0] - h[3];
				n.x = h[1] - h[2];
				n.y = 2;
				
				n = normalize(n);

				return float4( 0.5 + n * 0.5,1);
				
			}

			ENDCG
		}
	}
}
