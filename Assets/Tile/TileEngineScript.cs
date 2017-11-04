using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEngineScript : MonoBehaviour
{
	// Developer
	private GameObject[,] tileList;

	[Header("Prefabs")]
	public GameObject tilePrefab;

	[Header("Measurements")]
	public float tileWidth;
	public float tileHeight;
	public int totalTileOnX;
	public int totalTileOnY;

	[ContextMenu("Create Tiles")]
	public void CreateTiles()
	{
		tileList = new GameObject[totalTileOnY,totalTileOnX];
		for(int y = 0; y < totalTileOnY; y++)
		{
			for(int x = 0; x < totalTileOnX; x++)
			{
				float xPos = -(totalTileOnX / 2.0f * tileWidth); //leWidth * x) + (tileWidth / 2.0f);
				float yPos = -(totalTileOnY / 2.0f * tileWidth); //+ (tileHeight * y) + (tileHeight / 2.0f);

				tileList[y,x] = Instantiate(tilePrefab, new Vector3(xPos, yPos, 0.0f), Quaternion.identity, this.transform);
			}
		}
	}
}
