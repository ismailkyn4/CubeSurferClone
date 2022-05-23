using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moving : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float rightLeftSpeed;
    float inputHorizontal;
    MainCubeScript mainCube; //MAinCube scriptine eriþmek için oluþturduk.
    private void Awake()
    {
        mainCube = Object.FindObjectOfType<MainCubeScript>();
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (mainCube.SetMove())
        {
            inputHorizontal = Input.GetAxis("Horizontal");
            float xMove = (inputHorizontal * rightLeftSpeed * Time.deltaTime);
            transform.Translate(xMove, 0, forwardSpeed * Time.deltaTime);
            float xPosition = Mathf.Clamp(transform.position.x, -4.5f, 4.5f);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
    }

}
