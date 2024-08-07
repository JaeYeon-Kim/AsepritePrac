using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 4.0f;
    private Vector3 moveDirection = Vector3.zero;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x > 0) {
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = false;
        } else if(x < 0) {
            spriteRenderer.flipX = true;
            animator.SetBool("isWalk", true);
        } else {
            animator.SetBool("isWalk", false);
        }

        // 이동 방향 설정
        moveDirection = new Vector3(x, y, 0);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
