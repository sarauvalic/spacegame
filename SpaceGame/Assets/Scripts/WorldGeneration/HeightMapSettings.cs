using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame.WorldGeneration
{
	public class HeightMapSettings : MonoBehaviour
	{
		public Texture2D HeightMap;
		public float GreyscaleStepSize = 1f;
		public Vector3 TileScale;
	}
}