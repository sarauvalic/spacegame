using SpaceGame.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame.WorldGeneration
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(HeightMapSettings))]
    public class TerrainGenerator : MonoBehaviour
    {
		public GameObject testTile;

		private HeightMapSettings settings;
		private Dictionary<Vector2Int, int> heightMap = new Dictionary<Vector2Int, int>();
		private GameObject tilesParent;

		[Attributes.Button(nameof(Generate))]
		public bool GenerateButton;

		public void Generate()
		{
			settings = GetComponent<HeightMapSettings>();
			GenerateHeightMap();
			GenerateTerrain();
		}

		private void GenerateHeightMap()
		{
			for (int x = 0; x < settings.HeightMap.width; x++)
			{
				for (int y = 0; y < settings.HeightMap.height; y++)
				{
					var pixelColor = settings.HeightMap.GetPixel(x, y);
					var height = Mathf.RoundToInt(pixelColor.r / settings.GreyscaleStepSize);
					heightMap[new Vector2Int(x, y)] = height;
				}
			}
		}

		private void GenerateTerrain()
		{
			tilesParent = new GameObject(settings.HeightMap.name.Replace("HM_", "") + "(Tiles)");
			tilesParent.AddComponent(typeof(MeshCombiner));
			foreach (var pair in heightMap)
			{
				//var angle = 0;
				var coords = new Vector3Int(pair.Key.x, pair.Value, pair.Key.y);
				//ruleTile = tileConfig.RuleTiles.FirstOrDefault(rt => AllRulesFullfilled(volumetricMapData, coords, rt, out angle));
				//if(ruleTile == null) => ruleTile = tileConfig.ErrorRuleTile;
				var tilePos = Vector3.Scale(coords, settings.TileScale);
				
				CreateTile(tilePos);
				//CreateTile(coords.x, coords.z, tilePos, bounds, ruleTile, angle);
			}
		}

		private bool AllRulesFulfilled(/*VolumetricMapData volumetricMapData,*/ Vector3Int coords, RuleTile ruleTile, out int Angle)
		{
			//TODO: check if rules for tile is fulfilled

			Angle = 0;
			return true;
		}

		private void CreateTile(Vector3 pos)
		{
			Quaternion rotation = Quaternion.identity;
			Instantiate(testTile, pos, rotation, tilesParent.transform);
		}
	}
}