using System.Collections;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    public float hiz;
    private bool move;
    private Vector2 input;
    private Animator animator;
    public LayerMask sabitobjelayer;
    public LayerMask NPClayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (!move)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("move", move);

        if (Input.GetKeyDown(KeyCode.Z))
            interact();
    }

    void interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, NPClayer);
        if (collider != null)
        {
            collider.GetComponent<Temas>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        move = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, hiz * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        move = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        float checkRadius = 0.1f;  // Çarpışma kontrol yarıçapı
        Vector3 checkPos = targetPos + new Vector3(0, -0.5f, 0); // Yükseklik farkını hesaba katmak için pozisyonu ayarlayın
        if (Physics2D.OverlapCircle(checkPos, checkRadius, sabitobjelayer | NPClayer) != null)
        {
            return false;
        }
        return true;
    }

    // Karakterin pozisyonunu kaydetme
    public void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        PlayerPrefs.Save();
    }

    // Karakterin pozisyonunu yükleme
    public void LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerX", 0);
        float y = PlayerPrefs.GetFloat("PlayerY", 0);
        float z = PlayerPrefs.GetFloat("PlayerZ", 0);
        transform.position = new Vector3(x, y, z);
    }

    void OnEnable()
    {
        LoadPlayerPosition();
    }
}
