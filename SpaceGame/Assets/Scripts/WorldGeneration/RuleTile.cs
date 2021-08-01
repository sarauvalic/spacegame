using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame.WorldGeneration
{
	[CreateAssetMenu(fileName = "RuleTile", menuName = "ScriptableObjects/RuleTile", order = 1)]
	public class RuleTile : ScriptableObject
	{
		public GameObject tilePrefab;
		
		public List<float> allowedAngles = new List<float> { 0, 90, 180, 270 };
		public Dictionary<Vector2Int, NeighborRule> planarNeighbors;
		public Dictionary<Vector2Int, NeighborRule> verticalNeighbors;

		public enum NeighborRule { MustBe, CanBe, MustNotBe };
		public void GetNeighborRules()
		{

		}
	}
}