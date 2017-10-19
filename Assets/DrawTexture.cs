using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DrawTexture : MonoBehaviour
{
    public Texture2D texture = null;

	void Update()
	{
		if( Input.GetMouseButton( 0 ) )
        {
            var pos = Input.mousePosition / Screen.height;
            texture.SetPixel((int)(pos.x * texture.width), (int)(pos.y * texture.height), Color.black);
            texture.Apply();
        }

        if( Input.GetMouseButton( 1 ) )
        {
            Color[] colors = new Color[texture.width * texture.height];
            for( int i = 0; i < colors.Length; ++i )
                colors[ i ] = Color.white;
            texture.SetPixels(colors);
            texture.Apply();
        }
	}
}
