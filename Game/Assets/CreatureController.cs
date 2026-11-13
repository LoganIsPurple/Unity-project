using UnityEngine;

public class CreatureController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform head;
    [SerializeField] float headMaxTurnAngle;
    [SerializeField] float headTrackingSpeed;
    void LateUpdate()
    {
        Quaternion currentLocalRotation = head.localRotation;
        head.localRotation = Quaternion.identity;

        Vector3 targetWorldLookDir = target.position - head.position;
        Vector3 targetLocalLookDir = head.InverseTransformDirection(targetWorldLookDir);

        targetLocalLookDir = Vector3.RotateTowards(Vector3.forward, targetLocalLookDir, Mathf.Deg2Rad * headMaxTurnAngle, 0);

        Quaternion targetLocalRotation = Quaternion.LookRotation(targetLocalLookDir, Vector3.up);

        head.localRotation = Quaternion.Slerp(currentLocalRotation, targetLocalRotation, 1 - Mathf.Exp(-headTrackingSpeed * Time.deltaTime));
    }
}
