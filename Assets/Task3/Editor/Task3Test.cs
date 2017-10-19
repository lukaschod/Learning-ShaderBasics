using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class Task3Test
{
	[Test]
	public void CompareTextures()
	{
		TestCompareTextures.RunForScene("Assets/Task3/Task3.unity", "Task3");
	}
}
