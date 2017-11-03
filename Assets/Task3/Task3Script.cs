using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Task3Script : MonoBehaviour 
{
	public Material mat;
	public ComputeBuffer customBuffer;

	private struct Vertex
	{
		public Vector4 pos;
		public Vector2 uv;
		public Vertex(Vector4 pos, Vector2 uv) { this.pos = pos; this.uv = uv; }
	}

	private void OnDestroy()
	{
		if (customBuffer != null)
			customBuffer.Release();
	}

	private void Awake() 
	{
		if (mat == null)
			return;

		if (customBuffer == null)
		{
			var vertices = new Vertex[]
			{
				// 4 TODO: Add vertex with (0, 0, 0, 1) coordinates
				// 5 TODO: Add vertex with (1, 1, 0, 1) coordinates
				// 6 TODO: Add vertex with (1, 0, 0, 1) coordinates
			};

			// 1 TODO: Create customBuffer with correct arguments
			// 2 TODO: Update customBuffer data with vertices

			// 3 TODO: Set buffer customBuffer for material mat
		}
	}
}
