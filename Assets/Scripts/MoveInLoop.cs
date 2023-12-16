using UnityEngine;
using System;
using System.Collections;

public class MoveInLoop : MonoBehaviour
{
    public Transform startPoint;
    public Transform middlePoint;
    public Transform endPoint;
    public float speed = 0.5f;

    private float t = 0f;
    private bool caminando = true;

    void Awake () {
        StartCoroutine(Patroll());
    }

    IEnumerator Patroll () {
        while (true) {
            //IR al medio
            Vector3 towardsTarget = middlePoint.position - transform.position;
            while (towardsTarget.magnitude > 0.1f) {
                transform.position += towardsTarget.normalized * speed * Time.deltaTime;
                yield return 0;
                towardsTarget = middlePoint.position - transform.position;
            }

            //girar al final
            Quaternion startRotation = transform.rotation;
            Quaternion rotationTarget = startRotation * Quaternion.Euler(0,90,0);
            float elapsedTime = 0;
            float animationTime = 0.5f;
            while (elapsedTime < animationTime) {
                transform.rotation = Quaternion.Lerp(startRotation, rotationTarget, elapsedTime / animationTime);
                elapsedTime += Time.deltaTime;
                yield return 0;
            }

            //IR al final
            towardsTarget = endPoint.position - transform.position;
            while (towardsTarget.magnitude > 0.1f) {
                transform.position += towardsTarget.normalized * speed * Time.deltaTime;
                yield return 0;
                towardsTarget = endPoint.position - transform.position;
            }

            //Dar media vuelta
            startRotation = transform.rotation;
            rotationTarget = startRotation * Quaternion.Euler(0,180,0);
            elapsedTime = 0;
            animationTime = 1f;
            while (elapsedTime < animationTime) {
                transform.rotation = Quaternion.Lerp(startRotation, rotationTarget, elapsedTime / animationTime);
                elapsedTime += Time.deltaTime;
                yield return 0;
            }

            //IR al medio
            towardsTarget = middlePoint.position - transform.position;
            while (towardsTarget.magnitude > 0.1f) {
                transform.position += towardsTarget.normalized * speed * Time.deltaTime;
                yield return 0;
                towardsTarget = middlePoint.position - transform.position;
            }
            
            //girar al principio
            startRotation = transform.rotation;
            rotationTarget = startRotation * Quaternion.Euler(0,-90,0);
            elapsedTime = 0;
            animationTime = 0.5f;
            while (elapsedTime < animationTime) {
                transform.rotation = Quaternion.Lerp(startRotation, rotationTarget, elapsedTime / animationTime);
                elapsedTime += Time.deltaTime;
                yield return 0;
            }

            //Volver al origen
            towardsTarget = startPoint.position - transform.position;
            while (towardsTarget.magnitude > 0.1f) {
                transform.position += towardsTarget.normalized * speed * Time.deltaTime;
                yield return 0;
                towardsTarget = startPoint.position - transform.position;
            }

            //Dar media vuelta
            startRotation = transform.rotation;
            rotationTarget = startRotation * Quaternion.Euler(0,-180,0);
            elapsedTime = 0;
            animationTime = 1f;
            while (elapsedTime < animationTime) {
                transform.rotation = Quaternion.Lerp(startRotation, rotationTarget, elapsedTime / animationTime);
                elapsedTime += Time.deltaTime;
                yield return 0;
            }
        }
    }

}
