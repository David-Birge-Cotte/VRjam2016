using UnityEngine;
using System.Collections;
using UnityEditor;

public class CheckPollySurface
{
	[MenuItem("Jam/Transform/Clean Surface")]
	public static void CleanTransform()
	{
		Transform polysurface = (Selection.activeObject as GameObject).transform;

		Debug.Log (polysurface);
		Debug.Log (Selection.activeObject);

		MeshRenderer[] meshes = polysurface.GetComponentsInChildren<MeshRenderer> ();

		foreach (MeshRenderer mesh in meshes) 
		{
			Debug.Log ("mesh " + mesh.name);

			MeshCollider collider = mesh.GetComponent<MeshCollider> ();

			if (collider == null) 
			{
				collider = mesh.gameObject.AddComponent<MeshCollider> ();
			}

			try
			{
				collider.sharedMesh = mesh.GetComponent<MeshFilter>().sharedMesh;

				Debug.Log(collider.sharedMesh.vertices.Length + " " + collider.sharedMesh.triangles.Length + " " + collider.sharedMesh.vertexCount);

				if (collider.sharedMesh.vertices.Length >= 4)
				{
					collider.convex = true;
				}
				else
				{
					throw new System.Exception("not enough vertice " + collider.sharedMesh.vertexCount);
				}
			}
			catch(System.Exception ex) 
			{
				Debug.LogWarning ("Failed to used surface " + mesh.name + " because " + ex.ToString ());
				GameObject.Destroy(mesh.GetComponent<MeshCollider>());
			}
		}
	}
}
