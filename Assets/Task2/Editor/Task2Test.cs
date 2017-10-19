using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class Task2Test
{
	[Test]
	public void CompareTextures()
	{
		TestCompareTextures.RunForScene("Assets/Task2/Task2.unity", "Task2");
	}
}
