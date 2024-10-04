using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSelectionController : MonoBehaviour
{
    public bool Moving;
    float time;
    float duration = .5f;
    public Vector3 OffscreenPos;
    public Vector3 DefaultPos;
    float MovingDistanceDif = 0.01f;
    ArmController armController;

    // Start is called before the first frame update
    void Start()
    {
        Moving = false;
        DefaultPos = transform.position;
        OffscreenPos = new(-6.5f, -7f, 0);

        armController = GameObject.Find("Borry").GetComponent<ArmController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (MouseController() && !Moving)
        {
            armController.HeldWeapon = transform.name;
            Moving = true;
        }

        if (Moving && armController.HeldWeapon == transform.name)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = t * t * (3f - 2f * t);

            transform.position = new Vector3(Mathf.Lerp(DefaultPos.x, OffscreenPos.x, t), Mathf.Lerp(DefaultPos.y, OffscreenPos.y, t), 0);

            if ((OffscreenPos.y - MovingDistanceDif) < transform.position.y && transform.position.y < (OffscreenPos.y + MovingDistanceDif))
            {
                time = 0;
                Moving = false;
                transform.position = OffscreenPos;
            }
        }

        if (armController.HeldWeapon != transform.name && transform.position != DefaultPos)
        {
            Moving = true;
            time += Time.deltaTime;
            float t = time / duration;
            t = t * t * (3f - 2f * t);

            transform.position = new Vector3(Mathf.Lerp(OffscreenPos.x, DefaultPos.x, t), Mathf.Lerp(OffscreenPos.y, DefaultPos.y, t), 0);

            if ((DefaultPos.y - MovingDistanceDif) < transform.position.y && transform.position.y < (DefaultPos.y + MovingDistanceDif))
            {
                Moving = false;
                time = 0;
                transform.position = DefaultPos;
            }
        }
    }

    bool MouseController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D RayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (RayHit.collider != null && (RayHit.collider.gameObject == this.gameObject))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        else
        {
            return false;
        }
    }

}
