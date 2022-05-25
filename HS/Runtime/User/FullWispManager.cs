using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FullWispManager : MonoBehaviour, IInfoUICapable
{
    public Guid guid { get; set; }
    public string userID;
    public bool wispSwitched = false;
    public string wispName = "";
    public string wispOrganization = "";
    public bool poolLoaded = false;
    public GameObject noCoreWisp;

    private GameObject _wispCore;

    [System.NonSerialized] public HS.AvatarDriver avatarDriver;

    public void Start()
    {

        _wispCore = Instantiate(noCoreWisp, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
        _wispCore.transform.parent = this.gameObject.transform;
        _wispCore.transform.localPosition = new Vector3(0, 0, 0);
        avatarDriver = _wispCore.GetComponent<HS.AvatarDriver>();
        _wispCore.SetActive(false);
        this.gameObject.SetActive(false);

        poolLoaded = true;
    }

    public void SetRole(int roleNumber, string userID)
    {
        _wispCore.SetActive(true);
        avatarDriver = _wispCore.GetComponent<HS.AvatarDriver>();
        if (avatarDriver == null) return;
        avatarDriver.SetAvatarName(wispName);
        avatarDriver.name = "user " + userID + " " + wispName;
    }

    public void SetName(string name)
    {
        this.wispName = name;

        HS.AvatarDriver avatarDriver = _wispCore.GetComponent<HS.AvatarDriver>();
        if (avatarDriver == null) return;
        avatarDriver.SetAvatarName(wispName);
    }

    public void OnDisable()
    {
        if (poolLoaded == true)
        {
            noCoreWisp.SetActive(false);
            userID = "";
            wispName = "";
        }
    }

}
