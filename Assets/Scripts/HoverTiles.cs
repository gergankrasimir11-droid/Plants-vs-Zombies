using UnityEngine;
using UnityEngine.UI;

public class HoverTiles : MonoBehaviour
{
    public bool isFull;
    public GameManager gameManager;
    public Image backgroundImage;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameManager.draggingObject != null && isFull == false)
        {
            gameManager.currentTile = this.gameObject;
            backgroundImage.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

            gameManager.currentTile = null;
            backgroundImage.enabled = false;
        

    }
}
