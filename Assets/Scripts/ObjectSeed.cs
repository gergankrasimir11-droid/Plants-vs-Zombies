using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSeed : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject draggedPlantObject;
    public GameObject plantObject;
    public Canvas canvas;
    public GameObject draggedObjectInstance;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggedObjectInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        draggedObjectInstance = Instantiate(draggedPlantObject, canvas.transform);
        draggedObjectInstance.transform.position = Input.mousePosition;
        draggedObjectInstance.GetComponent<ObjectDragging>().seed = this;

        gameManager.draggingObject = draggedObjectInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.PlaceObject();
        gameManager.draggingObject = null;
        Destroy(draggedObjectInstance);
    }
}
