using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private CameraController cameraReference;

    private Vector2 _distance;

    private void Start() {
        GetComponent<HealthBarController>().onHit += cameraReference.CallScreenShake;
    }

    private void Update() {
        /*Vector2 movementPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRBD2.velocity = movementPlayer * velocityModifier;

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

        Vector3 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);
    
        Vector3 distance = mouseInput - transform.position;
        Debug.DrawRay(transform.position, distance * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0)){
            
        }else if(Input.GetMouseButtonDown(1)){
            Debug.Log("Left Click");
        }*/
    }

    public void PlayerMovement(InputAction.CallbackContext context){
        Vector2 movementPlayer = context.ReadValue<Vector2>();
        myRBD2.velocity = movementPlayer * velocityModifier;

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);
    }

    public void Fire(InputAction.CallbackContext context){
        if(context.performed){
            BulletController myBullet =  Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            myBullet.SetUpVelocity(_distance.normalized, gameObject.tag);
        }
    }

    public void PlayerAim(InputAction.CallbackContext context){
        Vector2 mouseInput = context.ReadValue<Vector2>();
        mouseInput = Camera.main.ScreenToWorldPoint(mouseInput);

        CheckFlip(mouseInput.x);

        _distance = mouseInput - new Vector2(transform.position.x, transform.position.y);
        Debug.DrawRay(transform.position, _distance * rayDistance, Color.red);
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
}
