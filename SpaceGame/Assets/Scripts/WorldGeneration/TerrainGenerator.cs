using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame.WorldGeneration
{
    public class TerrainGenerator : MonoBehaviour
    {
		[Attributes.Button(nameof(Generate))]
		public bool GenerateButton;
		public void Generate()
		{
            Debug.Log("Pressed Generate Button");
		}
    }
}