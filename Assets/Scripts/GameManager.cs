using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentTile;

    public static GameManager Instance;

    private void Awake()
    {
            Instance = this;
    }
   
    public void PlaceObject()
    {

        if (draggingObject != null && currentTile != null)
        {
            Instantiate(
                draggingObject.GetComponent<ObjectDragging>().seed.plantObject,
                currentTile.transform
            );

            HoverTiles tile = currentTile.GetComponent<HoverTiles>();
            tile.isFull = true;
            tile.backgroundImage.enabled = false;

            currentTile = null;
        }

        Debug.Log(
            "Placing seed: " +
            draggingObject.GetComponent<ObjectDragging>().seed.name
        );
        Debug.Log("Placed: " + draggingObject.GetComponent<ObjectDragging>().seed.plantObject.name);

    }
}
