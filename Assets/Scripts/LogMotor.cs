using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMotor : MonoBehaviour
{
    [System.Serializable]
    private class RotationElement
    {
        public float speed, duration;
    }

    [SerializeField]
    private RotationElement[] rotationPattern;

    private WheelJoint2D wheelJoint;
    private JointMotor2D motor;

    private void Awake(){
        wheelJoint = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        StartCoroutine(PlayRotationPattern());
    }

    private IEnumerator PlayRotationPattern(){
        int rotationIdx = 0;
        while(true){
            yield return new WaitForFixedUpdate();
            motor.motorSpeed = rotationPattern[rotationIdx].speed;
            motor.maxMotorTorque = 10000;
            wheelJoint.motor = motor;

            yield return new WaitForSecondsRealtime(rotationPattern[rotationIdx].duration);
            rotationIdx++;
            rotationIdx = rotationIdx < rotationPattern.Length ? rotationIdx : 0;
        }
    }
}
