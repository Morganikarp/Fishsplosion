using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class ArmController : MonoBehaviour
{
    Vector3 PivotPos;
    Vector3 MousePos;

    SpriteRenderer SR;
    public Sprite[] SpriteStates;
    GameObject GunArm;
    GameObject C4Arm;

    public string HeldWeapon;
    public GameObject[] ProjectilePrefabs;

    bool ProjectileActive;
    GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        GunArm = transform.GetChild(0).gameObject;
        C4Arm = transform.GetChild(1).gameObject;
        PivotPos = transform.position;
        HeldWeapon = "Empty";
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = new(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        if (Input.GetMouseButtonDown(0) && !ProjectileActive)
        {
            Fire();
        }

        if (!GameObject.Find("PistolBullet(Clone)"))
        {
            Projectile = null;
        }

        if (Projectile == null)
        {
            ProjectileActive = false;
        }

        switch (HeldWeapon)
        {
            case ("Empty"):
                SR.sprite = SpriteStates[0];
                GunArm.SetActive(false);
                C4Arm.SetActive(false);
                break;
            case ("Pistol"):
                SR.sprite = SpriteStates[1];
                GunArm.SetActive(true);
                C4Arm.SetActive(false);
                Vector3 DirVect = MousePos - PivotPos;
                float Angle = Mathf.Atan2(DirVect.y, DirVect.x) * 180 / Mathf.PI;

                if (-90  < Angle && Angle < 30)
                {
                    GunArm.transform.eulerAngles = new(0, 0, Angle);
                }

                break;

            case ("C4"):
                SR.sprite = SpriteStates[1];
                GunArm.SetActive(false);
                C4Arm.SetActive(true);
                DirVect = MousePos - PivotPos;
                Angle = Mathf.Atan2(DirVect.y, DirVect.x) * 180 / Mathf.PI;

                if (-90 < Angle && Angle < 30)
                {
                    C4Arm.transform.eulerAngles = new(0, 0, Angle);
                }

                break;
        }
    }

    void Fire()
    {
        ProjectileActive = true;

        Vector3 DirVect = MousePos - PivotPos;
        Vector3 UnitVect = DirVect / Mathf.Sqrt(Mathf.Pow(DirVect.x, 2) + Mathf.Pow(DirVect.x, 2));

        switch (HeldWeapon)
        {
            case ("Pistol"):
                Projectile = Instantiate(ProjectilePrefabs[0]);
                PistolBulletController BulletCont = Projectile.GetComponent<PistolBulletController>();

                Projectile.transform.position = PivotPos;
                Projectile.transform.eulerAngles = new(0, 0, Mathf.Atan2(DirVect.y, DirVect.x) * 180 / Mathf.PI);

                BulletCont.DirectionVector = UnitVect;

                break;

            case ("C4"):
                Projectile = Instantiate(ProjectilePrefabs[1]);
                C4Controller C4Cont = Projectile.GetComponent<C4Controller>();

                Projectile.transform.position = PivotPos;
                Projectile.transform.eulerAngles = new(0, 0, Mathf.Atan2(DirVect.y, DirVect.x) * 180 / Mathf.PI);

                C4Cont.DirectionVector = DirVect;
                break;
        }
    }
}
