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
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);

                i++;
            }
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
            transform.gameObject.SetActive(true);
        }
    }
}