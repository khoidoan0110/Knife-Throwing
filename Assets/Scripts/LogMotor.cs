using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMotor : MonoBehaviour
{
    private class RotationElement
    {
        public float speed, duration;
    }

    private List<RotationElement> rotationPattern;

    [SerializeField] private WheelJoint2D wheelJoint;
    private JointMotor2D motor;

    private void Awake()
    {
        motor = new JointMotor2D();
    }

    void Start()
    {
        rotationPattern = new List<RotationElement>();
        int level = MainMenu.selectedLevel;
        GameController.instance.knifeCount = 8;
        switch (level)
        {
            case 1:
                RotationElement r1 = new RotationElement { speed = 150f, duration = 1.75f };
                RotationElement r1b = new RotationElement { speed = -150f, duration = 1.75f };
                rotationPattern.Add(r1);
                rotationPattern.Add(r1b);
                StartCoroutine(PlayRotationPattern());
                break;

            case 2:
                RotationElement r2 = new RotationElement { speed = 200f, duration = 1.5f };
                RotationElement r2b = new RotationElement { speed = -200f, duration = 1.5f };
                RotationElement r2c = new RotationElement { speed = 150f, duration = 1.5f };
                RotationElement r2d = new RotationElement { speed = -150f, duration = 1.5f };
                rotationPattern.Add(r2);
                rotationPattern.Add(r2b);
                rotationPattern.Add(r2c);
                rotationPattern.Add(r2d);
                StartCoroutine(PlayRotationPattern());
                break;

            case 3:
                RotationElement r3 = new RotationElement { speed = 250f, duration = 1.5f };
                RotationElement r3b = new RotationElement { speed = -250f, duration = 1.5f };
                RotationElement r3c = new RotationElement { speed = 300f, duration = 0.5f };
                RotationElement r3d = new RotationElement { speed = -300f, duration = 0.5f };
                RotationElement r3e = new RotationElement { speed = 100f, duration = 1.5f };
                RotationElement r3f = new RotationElement { speed = -100f, duration = 1.5f };
                rotationPattern.Add(r3);
                rotationPattern.Add(r3b);
                rotationPattern.Add(r3c);
                rotationPattern.Add(r3d);
                rotationPattern.Add(r3e);
                rotationPattern.Add(r3f);
                StartCoroutine(PlayRotationPattern());
                break;

            case 4:
                RotationElement r4 = new RotationElement { speed = 400f, duration = 1.5f };
                RotationElement r4b = new RotationElement { speed = -400f, duration = 1.5f };
                RotationElement r4c = new RotationElement { speed = 150f, duration = 1.5f };
                RotationElement r4d = new RotationElement { speed = -150f, duration = 1.5f };
                RotationElement r4e = new RotationElement { speed = 250f, duration = 1f };
                RotationElement r4f = new RotationElement { speed = -250f, duration = 1f };
                rotationPattern.Add(r4);
                rotationPattern.Add(r4b);
                rotationPattern.Add(r4c);
                rotationPattern.Add(r4d);
                rotationPattern.Add(r4e);
                rotationPattern.Add(r4f);
                StartCoroutine(PlayRotationPattern());
                break;

            case 5:
                RotationElement r5 = new RotationElement { speed = 100f, duration = 1f };
                RotationElement r5b = new RotationElement { speed = -100f, duration = 1f };
                RotationElement r5c = new RotationElement { speed = 400f, duration = 1f };
                RotationElement r5d = new RotationElement { speed = -400f, duration = 1f };
                RotationElement r5e = new RotationElement { speed = 200f, duration = 1.5f };
                RotationElement r5f = new RotationElement { speed = -200f, duration = 1.5f };
                rotationPattern.Add(r5);
                rotationPattern.Add(r5b);
                rotationPattern.Add(r5c);
                rotationPattern.Add(r5d);
                rotationPattern.Add(r5e);
                rotationPattern.Add(r5f);
                StartCoroutine(PlayRotationPattern());
                break;

            case 6:
                RotationElement r6 = new RotationElement { speed = 350f, duration = 1.5f };
                RotationElement r6b = new RotationElement { speed = -350f, duration = 1.5f };
                RotationElement r6c = new RotationElement { speed = 250f, duration = 1f };
                RotationElement r6d = new RotationElement { speed = -250f, duration = 1f };
                RotationElement r6e = new RotationElement { speed = 500f, duration = 2f };
                RotationElement r6f = new RotationElement { speed = -500f, duration = 2f };
                RotationElement r6g = new RotationElement { speed = 150f, duration = 1.5f };
                RotationElement r6h = new RotationElement { speed = -150f, duration = 1.5f };
                RotationElement r6i = new RotationElement { speed = 450f, duration = 2f };
                RotationElement r6j = new RotationElement { speed = -450f, duration = 2f };
                RotationElement r6k = new RotationElement { speed = 600f, duration = 0.5f };
                RotationElement r6l = new RotationElement { speed = -600f, duration = 0.5f };
                rotationPattern.Add(r6);
                rotationPattern.Add(r6b);
                rotationPattern.Add(r6c);
                rotationPattern.Add(r6d);
                rotationPattern.Add(r6e);
                rotationPattern.Add(r6f);
                rotationPattern.Add(r6g);
                rotationPattern.Add(r6h);
                rotationPattern.Add(r6i);
                rotationPattern.Add(r6k);
                rotationPattern.Add(r6l);
                StartCoroutine(PlayRotationPattern());
                break;

            case 7:
                RotationElement r7 = new RotationElement { speed = 100f, duration = 1.5f };
                RotationElement r7b = new RotationElement { speed = -250f, duration = 1.5f };
                RotationElement r7c = new RotationElement { speed = 290f, duration = 1f };
                RotationElement r7d = new RotationElement { speed = -310f, duration = 1.5f };
                RotationElement r7e = new RotationElement { speed = 510f, duration = 1.5f };
                RotationElement r7f = new RotationElement { speed = -80f, duration = 2f };
                RotationElement r7g = new RotationElement { speed = 3000f, duration = 1.5f };
                RotationElement r7h = new RotationElement { speed = -200f, duration = 1.5f };
                RotationElement r7i = new RotationElement { speed = 50f, duration = 1f };
                RotationElement r7j = new RotationElement { speed = -150f, duration = 1f };
                RotationElement r7k = new RotationElement { speed = 500f, duration = 1.5f };
                RotationElement r7l = new RotationElement { speed = -200f, duration = 2.5f };
                rotationPattern.Add(r7);
                rotationPattern.Add(r7b);
                rotationPattern.Add(r7c);
                rotationPattern.Add(r7d);
                rotationPattern.Add(r7e);
                rotationPattern.Add(r7f);
                rotationPattern.Add(r7g);
                rotationPattern.Add(r7h);
                rotationPattern.Add(r7i);
                rotationPattern.Add(r7k);
                rotationPattern.Add(r7l);
                StartCoroutine(PlayRotationPattern());
                break;

            case 8:
                RotationElement r8 = new RotationElement { speed = 60f, duration = 1.5f };
                RotationElement r8b = new RotationElement { speed = -150f, duration = 1.5f };
                RotationElement r8c = new RotationElement { speed = 200f, duration = 1f };
                RotationElement r8d = new RotationElement { speed = 250f, duration = 1f };
                RotationElement r8e = new RotationElement { speed = -300f, duration = 2f };
                RotationElement r8f = new RotationElement { speed = 400f, duration = 2f };
                RotationElement r8g = new RotationElement { speed = -150f, duration = 1.5f };
                RotationElement r8h = new RotationElement { speed = -210f, duration = 1.5f };
                RotationElement r8i = new RotationElement { speed = 400f, duration = 2f };
                RotationElement r8j = new RotationElement { speed = -220f, duration = 2f };
                RotationElement r8k = new RotationElement { speed = 300f, duration = 0.5f };
                RotationElement r8l = new RotationElement { speed = -800f, duration = 0.5f };
                rotationPattern.Add(r8);
                rotationPattern.Add(r8b);
                rotationPattern.Add(r8c);
                rotationPattern.Add(r8d);
                rotationPattern.Add(r8e);
                rotationPattern.Add(r8f);
                rotationPattern.Add(r8g);
                rotationPattern.Add(r8h);
                rotationPattern.Add(r8i);
                rotationPattern.Add(r8k);
                rotationPattern.Add(r8l);
                StartCoroutine(PlayRotationPattern());
                break;

            case 9:
                RotationElement r9 = new RotationElement { speed = 550f, duration = 1.5f };
                RotationElement r9b = new RotationElement { speed = -120f, duration = 1.5f };
                RotationElement r9c = new RotationElement { speed = 300f, duration = 1f };
                RotationElement r9d = new RotationElement { speed = -20f, duration = 1f };
                RotationElement r9e = new RotationElement { speed = 10f, duration = 2f };
                RotationElement r9f = new RotationElement { speed = -600f, duration = 2f };
                RotationElement r9g = new RotationElement { speed = 200f, duration = 1.5f };
                RotationElement r9h = new RotationElement { speed = -200f, duration = 1.5f };
                RotationElement r9i = new RotationElement { speed = 450f, duration = 2f };
                RotationElement r9j = new RotationElement { speed = -300f, duration = 2f };
                RotationElement r9k = new RotationElement { speed = 60f, duration = 0.5f };
                RotationElement r9l = new RotationElement { speed = -100f, duration = 0.5f };
                rotationPattern.Add(r9);
                rotationPattern.Add(r9b);
                rotationPattern.Add(r9c);
                rotationPattern.Add(r9d);
                rotationPattern.Add(r9e);
                rotationPattern.Add(r9f);
                rotationPattern.Add(r9g);
                rotationPattern.Add(r9h);
                rotationPattern.Add(r9i);
                rotationPattern.Add(r9k);
                rotationPattern.Add(r9l);
                StartCoroutine(PlayRotationPattern());
                break;

            case 10:
                RotationElement r10 = new RotationElement { speed = 300f, duration = 1.5f };
                RotationElement r10b = new RotationElement { speed = -150f, duration = 1.5f };
                RotationElement r10c = new RotationElement { speed = 300f, duration = 1f };
                RotationElement r10d = new RotationElement { speed = -350f, duration = 1f };
                RotationElement r10e = new RotationElement { speed = 450f, duration = 2f };
                RotationElement r10f = new RotationElement { speed = -200f, duration = 2f };
                RotationElement r10g = new RotationElement { speed = 100f, duration = 1.5f };
                RotationElement r10h = new RotationElement { speed = -300f, duration = 1.5f };
                RotationElement r10i = new RotationElement { speed = 500f, duration = 2f };
                RotationElement r10j = new RotationElement { speed = -450f, duration = 2f };
                RotationElement r10k = new RotationElement { speed = 700f, duration = 0.5f };
                RotationElement r10l = new RotationElement { speed = -450f, duration = 0.5f };
                RotationElement r10m = new RotationElement { speed = 500f, duration = 1f };
                RotationElement r10n = new RotationElement { speed = -100f, duration = 0.5f };
                rotationPattern.Add(r10);
                rotationPattern.Add(r10b);
                rotationPattern.Add(r10c);
                rotationPattern.Add(r10d);
                rotationPattern.Add(r10e);
                rotationPattern.Add(r10f);
                rotationPattern.Add(r10g);
                rotationPattern.Add(r10h);
                rotationPattern.Add(r10i);
                rotationPattern.Add(r10k);
                rotationPattern.Add(r10l);
                rotationPattern.Add(r10m);
                rotationPattern.Add(r10n);
                StartCoroutine(PlayRotationPattern());
                break;

        }
    }

    private IEnumerator PlayRotationPattern()
    {
        int rotationIdx = 0;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            motor.motorSpeed = rotationPattern[rotationIdx].speed;
            motor.maxMotorTorque = 10000;
            wheelJoint.motor = motor;

            yield return new WaitForSecondsRealtime(rotationPattern[rotationIdx].duration);
            rotationIdx++;
            rotationIdx = rotationIdx < rotationPattern.Count ? rotationIdx : 0;
        }
    }
}
