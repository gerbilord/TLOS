using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; // TODO make float variable/reference
    private Rigidbody2D myRigidbody;
    private Animator animator;

    private Vector2 tempMovement = Vector2.down;
    private Vector2 direction = Vector2.down;

    [SerializeField] public StringVariable playerState;
    [SerializeField] private PlayerPowerQueue playerPowerQueue;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetAnimatorDirection(direction);
        playerState.SetValue("Idle");
    }

    void SetAnimatorDirection(Vector2 direction)
    {
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void Update() // ALL INPUTS GO HERE
    {
        GetInput();
        UpdateAnimator(); // Does this go in update or fixed update?

    }

    private void GetInput()
    {

        if (Input.GetButtonDown("Fire1") && playerState.Value != "Attack")
        {
            StartCoroutine(MeleeCo());
        }
        else if (Input.GetButtonDown("Fire2") && playerState.Value != "Attack")
        {
            StartCoroutine(ShootCo());
        }
        else if(playerState.Value != "Attack")
        {
            GetMovementInput();
        }
    }

    public IEnumerator ShootCo()
    {
        tempMovement = Vector2.zero;
        GenericPower currentPower = playerPowerQueue.UsePower();
        currentPower.projectile.Shoot(transform.position, direction);
        yield return ChangeStateCo(currentPower.projectile.playerUseTime, "Attack", "Idle"); // TODO replace .3f with current value thing.
    }

    public IEnumerator MeleeCo()
    {
        tempMovement = Vector2.zero;
        GenericPower currentPower = playerPowerQueue.UsePower();
        currentPower.melee.Shoot(transform.position, direction);
        yield return ChangeStateCo(currentPower.melee.playerUseTime, "Attack", "Idle"); // TODO replace .3f with current value thing.
    }

    public IEnumerator ChangeStateCo(float time, string startState, string endState)
    {
        playerState.SetValue(startState);
        yield return new WaitForSeconds(time);
        playerState.SetValue(endState);
    }

    private void GetMovementInput()
    {
        tempMovement = Vector3.zero;
        tempMovement.x = GetAxisBinary("Horizontal");
        tempMovement.y = GetAxisBinary("Vertical");
        tempMovement.Normalize();
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition((Vector2)transform.position + tempMovement * speed * Time.fixedDeltaTime );
    }

    void UpdateAnimator()
    {
        if (tempMovement != Vector2.zero)
        {
            animator.SetFloat("moveX", tempMovement.x);
            animator.SetFloat("moveY", tempMovement.y);
            //animator.SetBool("moving", true);

            direction.x = tempMovement.x;
            direction.y = tempMovement.y;
        }
        else
        {
            //animator.SetBool("moving", false);
        }

    }

    float GetAxisBinary(string dir)
    {
        float value = Input.GetAxisRaw(dir);
        float sensitivity = .15F;

        if (value > sensitivity)
        {
            return 1;
        }
        else if (value < sensitivity * -1.0F)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
