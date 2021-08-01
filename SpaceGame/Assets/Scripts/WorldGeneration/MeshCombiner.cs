using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame.Helpers
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [ExecuteInEditMode]
    public class MeshCombiner : MonoBehaviour
    {
        [Attributes.Button(nameof(CombineChildMeshes))]
        public bool combineButton;
        public void CombineChildMeshes()
        {
            MeshFilter[] temp = GetComponentsInChildren<MeshFilter>();
            MeshFilter[] meshFilters = new MeshFilter[temp.Length - 1];
			for (int i = 0; i < meshFilters.Length; i++)
			{
                meshFilters[i] = temp[i + 1];
			}
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

			for (int i = 0; i < meshFilters.Length; i++)
			{
                combine[i] = new CombineInstance
                {
                    mesh = meshFilters[i].sharedMesh,
                    transform = meshFilters[i].transform.localToWorldMatrix
                };
                meshFilters[i].gameObject.SetActive(false);
            }
			
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
            transform.gameObject.SetActive(true);
        }
    }
}