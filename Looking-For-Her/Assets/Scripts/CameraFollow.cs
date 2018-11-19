using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {

    Transform target;
    float xMax, xMin, yMax, yMin;

    [SerializeField] // bd mogla ustawic tilemap z unity]
    private Tilemap groundTilemap;


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform; //reference to the player

        Vector3 minTile = groundTilemap.CellToWorld(groundTilemap.cellBounds.min); //pobiera granice mapy dolna
        Vector3 maxTile = groundTilemap.CellToWorld(groundTilemap.cellBounds.max); //pobiera granice mapy gorna

        SetLimits(minTile, maxTile);  //ustawia x/y Min i Max
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(Mathf.Clamp(target.position.x,xMin,xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10); // ogranicza ruch kamery, -10 to z pozycji kamery
        
    }

    public void SetLimits(Vector3 minTile, Vector3 maxTile) //pobiera pozycje krancow tilemapy
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;   // to nam daje wysokosc ekranu/kamery
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;
        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}
