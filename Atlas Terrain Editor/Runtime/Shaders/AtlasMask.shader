Shader "Hidden/Atlas/AtlasMask"
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
				float2 fade: TEXCOORD2;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float2 fade: TEXCOORD2;
			};

			sampler2D _MainTex;
			float _Power;
			float _EdgeFade;
			float _EdgeFadePower;

			float EdgeFade(float2 uv) {
			
				//uv = (uv - 0.5) * 2;
				//
				//return clamp(pow(clamp(1 - length(uv)*_EdgeFade, 0, 1), 0.2)*1.1,0,1);

				if (_EdgeFade <= 0) {

					return 1.0;

				} else {

					float f = (1.0 - abs((uv.x - 0.5) * 2.0)) * (1.0 - abs((uv.y - 0.5) * 2.0));

					f = pow(f, 2);

					return clamp(f * 100.0 * clamp(1.0 - _EdgeFade, 0.0, 1.0), 0.0, 1.0);

				}

			}

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = float4(v.vertex.xy * 2 - 1, 0, 1);
				o.vertex.y *= -1;
				o.uv = v.uv;
				o.fade = v.fade;
				return o;
			}
			
			float4 frag (v2f i) : SV_Target
			{

				float c = tex2D(_MainTex, i.uv).r * i.fade.r;

#if UNITY_COLORSPACE_GAMMA 
				c = pow(c, 2.2f);
#endif

				c = clamp(pow(c, _Power), 0.0, 1.0) *EdgeFade(i.uv);

				return float4(c.rrr, 0);
				
			}

			ENDCG
		}
	}
}
