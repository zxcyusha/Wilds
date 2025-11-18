using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimatorCotroller : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rig;
    public Transform mainCamera;
    public AudioSource Running;
    public float jumpForce = 3.5f;
    public float walkingSpeed = 2f;
    public float runningSpeed = 6f;
    public float currentSpeed;
    private AudioSource Steps;
    private float animationInterpolation = 1f;
    
    void Start()
    {
        Steps = GetComponent<AudioSource>();
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
        anim.SetFloat("x", Input.GetAxis("Horizontal") * animationInterpolation);
        anim.SetFloat("y", Input.GetAxis("Vertical") * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }
    void Walk()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);
        anim.SetFloat("x", Input.GetAxis("Horizontal") * animationInterpolation);
        anim.SetFloat("y", Input.GetAxis("Vertical") * animationInterpolation);
        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Walk();
            }
            else
            {
                Run();
            }
        }
        else
        {
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) Steps.Play();
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Steps.Stop();
            Running.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            Steps.Play();
            Running.Stop();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            Steps.Stop();
            Running.Stop();
        }
    }
    void FixedUpdate()
    {
        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        movingVector = Vector3.ClampMagnitude(camF.normalized * Input.GetAxis("Vertical") * currentSpeed + camR.normalized * Input.GetAxis("Horizontal") * currentSpeed, currentSpeed);
        anim.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
        rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
        rig.angularVelocity = Vector3.zero;
    }
    public void Jump()
    {
        Steps.Stop();
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}