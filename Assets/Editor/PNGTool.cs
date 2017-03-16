using UnityEngine;
using System.IO;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

public class PNGTool
{
	[MenuItem("PNGTool/Fromat")]
	static void TextureToFormat()
	{
		foreach (Object texture in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
		{
			if(texture.GetType() != typeof(Texture2D))continue;
			Texture2D tex = (Texture2D)texture;
			string path = AssetDatabase.GetAssetPath(tex);
			TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
			textureImporter.textureType = TextureImporterType.Default;
			textureImporter.isReadable = false;
			textureImporter.generateCubemap = TextureImporterGenerateCubemap.None;
			textureImporter.wrapMode = TextureWrapMode.Clamp;
			textureImporter.mipmapEnabled = false;
			textureImporter.npotScale = TextureImporterNPOTScale.None;
			textureImporter.textureFormat = TextureImporterFormat.RGBA32;
			AssetDatabase.ImportAsset(path);
		}
		AssetDatabase.Refresh();
		Debug.Log("导出结束");
	}

	[MenuItem("PNGTool/Export")]
	static void TextureToPNGS()
	{
		float t = Time.time;
		Debug.Log("导出开始");
		if(Directory.Exists(Application.dataPath + "/PNG"))
		{
			Directory.Delete(Application.dataPath + "/PNG" , true);
		}
		foreach (Object texture in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
		{
			if (texture.GetType() != typeof(Texture2D)) continue;
			Texture2D imgae = (Texture2D)texture;
			string path = AssetDatabase.GetAssetPath(imgae);
			TextureImporter textureImpoter = AssetImporter.GetAtPath(path) as TextureImporter;
			foreach(SpriteMetaData metaData in textureImpoter.spritesheet)
			{
				Texture2D newImage = new Texture2D((int)metaData.rect.width , (int)metaData.rect.height);
				for(int y = (int)metaData.rect.y ; y < metaData.rect.y + metaData.rect.height ; y ++)
				{
					for(int x = (int)metaData.rect.x ; x < metaData.rect.x + metaData.rect.width ; x ++)
					{
						newImage.SetPixel(x - (int)metaData.rect.x , y - (int)metaData.rect.y , imgae.GetPixel(x , y));
					}
				}
				if(newImage.format != TextureFormat.ARGB32 && newImage.format != TextureFormat.RGB24)
				{
					Texture2D newTexture = new Texture2D(newImage.width , newImage.height);
					newTexture.SetPixels(newImage.GetPixels(0) , 0);
					newImage = newTexture;
				}

				var pngData = newImage.EncodeToPNG();
				Directory.CreateDirectory(Application.dataPath + "/PNG/" + imgae.name + "/");
				File.WriteAllBytes(Application.dataPath + "/PNG/" + imgae.name + "/" + metaData.name + ".png" , pngData);
			}
		}
		AssetDatabase.Refresh();
		Debug.Log("导出结束 用时 " + (Time.time - t) + "s");
	}
}
