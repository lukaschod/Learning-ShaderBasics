using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class Task1Test
{
	[Test]
	public void CompareTextures()
	{
		TestCompareTextures.RunForScene("Assets/Task1/Task1.unity", "Task1");
	}
}
