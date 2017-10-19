using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.Rendering;
using UnityEditor;
using UnityEditor.SceneManagement;
using NUnit.Framework;
using System.Collections;
using System.IO;

public class TestCompareTextures
{
	private const string texturesFolder = "Textures/";
	private const string textureExtension = ".png";
	private const string cameraTexturePostFix = "_CameraTexture";
	private const string compareTexturePostFix = "_CompareTexture";

	public static void RunForScene(string pathToScene, string name)
	{
		EditorSceneManager.OpenScene("Assets/" + name + "/" + name + ".unity");

		var cameraTexture = CaptureCamera(name);
		var compareTexture = TryGetCompareTexture(name);

		if (compareTexture == null)
		{
			SaveTexture(name + compareTexturePostFix, cameraTexture);
			return;
		}

		var texturesSimilarity = GetTextureSimilarity(cameraTexture, compareTexture);
		Assert.IsTrue(texturesSimilarity >= 0.9f);
	}

	private static Texture2D CaptureCamera(string name)
	{
		var width = 256;
		var height = 256;
		var rt = new RenderTexture(width, height, 24);

		var camera = Camera.main;
		camera.targetTexture = rt;
		camera.Render();

		RenderTexture.active = rt;
		var texture = new Texture2D(width, height);
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0, false);
        texture.Apply();
        RenderTexture.active = null;

        SaveTexture(name + cameraTexturePostFix, texture);

		return texture;
	}

	private static void SaveTexture(string name, Texture2D texture)
	{
		var directory = "Assets/Common/Resources/" + texturesFolder;
        if (!Directory.Exists(directory))
        	Directory.CreateDirectory(directory);

        var graphicsDeviceName = GetCurrentGraphicsAPIPostFix();
        var fullPath = directory + name + graphicsDeviceName + textureExtension;
		File.WriteAllBytes(fullPath, texture.EncodeToPNG());
		AssetDatabase.Refresh();

		var importSettings = (TextureImporter)AssetImporter.GetAtPath(fullPath);
		importSettings.isReadable = true;
		importSettings.textureCompression = TextureImporterCompression.Uncompressed;
		importSettings.SaveAndReimport();
	}

	private static string GetCurrentGraphicsAPIPostFix()
	{
        switch (SystemInfo.graphicsDeviceType)
        {
        	case GraphicsDeviceType.Direct3D11:
        		return "_D3D11";
        	case GraphicsDeviceType.Metal:
        		return "_Metal";
        	default:
        		Debug.LogError("Please use d3d11 or metal for graphics API!");
        		return null;
        }
	}

	private static Texture2D TryGetCompareTexture(string name)
	{
		var graphicsDeviceName = GetCurrentGraphicsAPIPostFix();
		var texture = Resources.Load<Texture2D>(texturesFolder + name + compareTexturePostFix + graphicsDeviceName);
		return texture;
	}

	private static float GetTextureSimilarity(Texture2D first, Texture2D second)
	{
		Assert.AreEqual(first.width, second.width);
		Assert.AreEqual(first.height, second.height);
		var width = first.width;
		var height = first.height;

		var firstPixels = first.GetPixels();
		var secondPixels = second.GetPixels();

		// TODO: Make it partial comparing

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				var index = i + width * j;
				var firstPixel = firstPixels[index];
				var secondPixel = secondPixels[index];

				if (firstPixel != secondPixel)
					return 0;
			}
		}

		return 1;
	}
}
