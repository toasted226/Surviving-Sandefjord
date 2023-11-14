using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float interactRange;
    public float interactCooldown;

    public Transform holdingHand;
    public Item heldItem;
    [Tooltip("The percentage (between 0 and 1) by which speed is reduced while carrying heavy items")]
    public float carryingSpeedReduction;

    private Vector2 movement;
    private float maxMoveSpeed;
    [SerializeField]private bool canInteract;
    private Rigidbody2D rb;

    private void Start()
    {
        movement = Vector2.zero;
        maxMoveSpeed = moveSpeed;
        canInteract = true;
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Player rotation by mouse movement
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x - transform.position.x > 0)
        {
            transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
        }
        else 
        { 
            transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
        }
        
        if (Input.GetButtonDown("Interact") && canInteract)
        {
            if (heldItem == null) 
            {
                TryInteract();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * new Vector3(movement.x, movement.y, 0f));
    }

    void TryInteract() 
    {
        // Get list of all interactables in range
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, interactRange);

        // Find closest interactable        
        float shortestDistance = float.MaxValue;
        Interactable closest = null;

        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].TryGetComponent<Interactable>(out var interactable))
            {
                Vector2 ipos = interactable.transform.position;
                Vector2 pos = transform.position;
                float dist = Mathf.Sqrt(Mathf.Pow(pos.y - ipos.y, 2) + Mathf.Pow(pos.x - ipos.x, 2));
                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    closest = interactable;
                }
            }
        }

        if (closest != null)
        {
            closest.Interact(this);
            canInteract = false;
            Invoke(nameof(InteractCooldown), interactCooldown);
        }
    }

    void InteractCooldown() 
    {
        canInteract = true;
    }

    public void PickupItem(Item item)
    {
        heldItem = item;
        item.transform.parent = holdingHand;
        item.transform.localPosition = Vector2.zero;

        if (heldItem.IsHeavy())
        {
            moveSpeed -= moveSpeed * carryingSpeedReduction;
        }
    }

    public void DropItem() 
    {
        if (heldItem != null)
        {
            heldItem.transform.parent = null;
            heldItem.DropItem();
            heldItem = null;
            moveSpeed = maxMoveSpeed;
        }
    }

    public void ConsumeItem()
    {
        Destroy(heldItem.gameObject);
    }
}
