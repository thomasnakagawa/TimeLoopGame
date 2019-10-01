using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OatsUtil;
using ObjectTub;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3f;
    [SerializeField] private float LookSpeed = 3f;

    [Header("Throwing")]
    [SerializeField] private GameObject TennisBallPrefab = default;
    [SerializeField] private Transform TennisBallSpawnTransform = default;
    [SerializeField] private float ThrowStrength = 10f;

    private CharacterController CharacterController;
    private Animator Animator;

    private Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        CharacterController = this.RequireComponent<CharacterController>();
        Animator = this.RequireComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            CharacterController.SimpleMove(transform.forward * MoveSpeed);
            Animator.SetBool("Walking", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Animator.SetBool("Walking", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Animator.SetTrigger("Throw");
        }

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * LookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * LookSpeed, 0, 0);
    }

    public void ThrowBall()
    {
        GameObject ball = ObjectPool.TakeObjectFromTub(TennisBallPrefab);
        ball.transform.position = TennisBallSpawnTransform.position;
        ball.transform.RequireComponent<Rigidbody>().AddForce(TennisBallSpawnTransform.forward * ThrowStrength);
    }
}
