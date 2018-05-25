Shader "Custom/Transpa"
{
	Properties{
		_Color("Main Color", Color) = (0.5,0.5,0.5,0.1)
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	_Transparency("Transparency", Range(0.0,1.0)) = 0.25
	}

		SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200

		CGPROGRAM
#pragma surface surf Lambert alpha:fade

		sampler2D _MainTex;
	fixed4 _Color;
	float _Transparency;

	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = _Transparency;
	}
	ENDCG
	}

		Fallback "Legacy Shaders/Transparent/VertexLit"
}