Shader "RM /Sprites/Detail"
{
	Properties
	{
	    _Color ("Tint", Color) = (1,1,1,1)
	    
	
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_SripteSt ("Sprite strength", Range (0.01, 5)) = 1
		
		_DetailTex ("Detail Texture", 2D) = "white" {}
		_DetailSt ("Detail strength", Range (0.01, 10)) = 1

		_EmSt ("Light strength", Range (0.00, 5)) = 0
		
	
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		CGPROGRAM
		#pragma surface surf  Lambert vertex:vert keepalpha 
		#pragma multi_compile _ PIXELSNAP_ON 
		#pragma target 3.0


		sampler2D _MainTex;
		sampler2D _DetailTex;


	
		fixed4 _Color;
		fixed4 _FogColor;

		float _DetailSt;
		float _SripteSt;
		float _EmSt;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_DetailTex;
			float2 uv_SpeTex;
			float2 uv_BumpMap;
			float2 uv_EmTex;
			fixed4 color;
		};
		
		void vert (inout appdata_full v, out Input o)
		{
			#if defined(PIXELSNAP_ON)
			v.vertex = UnityPixelSnap (v.vertex);
			#endif
			
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.color = v.color * _Color;
		}

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color;
            fixed4 d = tex2D(_DetailTex, IN.uv_DetailTex) * IN.color;
            
            o.Albedo = c.rgb * c.a*_SripteSt;
            o.Albedo *= c.a*IN.color*_EmSt;
            o.Albedo += c.rgb*d.rgb*_DetailSt*d.a* c.a;
			
			o.Alpha = c.a;
			
		}
		

		ENDCG
	}

Fallback "Transparent/VertexLit"
}
