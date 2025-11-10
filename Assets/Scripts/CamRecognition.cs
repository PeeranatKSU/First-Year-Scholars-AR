using UnityEngine;
using UnityEngine.Splines;
using Unity.Cinemachine;
using System.Collections;

public class CamRecognition : MonoBehaviour
{
    public Transform[] waypoints;

    public SplineContainer splineContainer;

    [Tooltip("Capture a snapshot every _ second")]
    public float captureInterval;
    public bool capturing = true;
    private CinemachineSplineDolly splineDolly;

    private void Awake()
    {
        Spline spline = splineContainer.Splines[0];

        for (int i = 0; i < waypoints.Length; i++)
        {
            BezierKnot newKnot = new BezierKnot(waypoints[i].position);

            spline.Add(newKnot);
        }

        spline.Closed = true;
    }

    void Start()
    {
        splineDolly = GetComponent<CinemachineSplineDolly>();

        StartCoroutine(Capture());
    }

    void Update()
    {
        //splineDolly.CameraPosition
    }

    private IEnumerator Capture()
    {
        while (capturing)
        {
            yield return new WaitForSeconds(captureInterval);
            Debug.Log("Captured");
        }
    }
}
