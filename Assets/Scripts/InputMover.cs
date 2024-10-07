using UnityEngine;

public class InputMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _rotateSpeed = 1f;

    private const string _verticalInput = "Vertical";
    private const string _horizontallInput = "Horizontal";

    private float _axisX;
    private float _axisY;

    private void Update()
    {
        _axisX = Input.GetAxis(_horizontallInput);
        _axisY = Input.GetAxis(_verticalInput);

        Vector3 moveDirection = new Vector3(_axisX, 0f, _axisY);        
        transform.position += moveDirection * Time.deltaTime * _moveSpeed;

        RotateBody(moveDirection);
    }

    private void RotateBody(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotateSpeed);
        }
    }
}
