using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.LEGO.Minifig;

public class TwoDScript : MonoBehaviour
{
    private GameObject cinemachineCam;
    private CinemachineFreeLook cinemachineControls;
    private GameObject player;
    private MinifigController characterController;
    private static string mouseX;
    private static string mouseY;
    private bool hasSwitchedDimension = false;


    // Start is called before the first frame update
    private void Awake()
    {
        mouseX = "Mouse X";
        mouseY = "Mouse Y";
        cinemachineCam = GameObject.Find("Third Person Free Look Camera");
        cinemachineControls = cinemachineCam.GetComponent<CinemachineFreeLook>();
        
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        characterController = player.GetComponent<MinifigController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(characterController.Is3D)
        {
            if(!hasSwitchedDimension)
            {
                cinemachineControls.m_YAxis = new AxisState(0, 1, false, true, 2f, 0.2f, 0.1f, "Mouse Y", false);
                cinemachineControls.m_XAxis = new AxisState(-180, 180, true, false, 300f, 0.1f, 0.1f, "Mouse X", true);
                hasSwitchedDimension = true;
            }
        }
        else
        {
            cinemachineControls.m_YAxis = new AxisState(0, 1, false, true, 2f, 0.2f, 0.1f, "", false);
            cinemachineControls.m_XAxis = new AxisState(-180, 180, true, false, 300f, 0.1f, 0.1f, "", true);
            hasSwitchedDimension = false;
        }
    }
}
