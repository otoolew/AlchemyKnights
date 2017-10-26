using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour {
    public string abilityButtonAxisName = "Fire2";
    public Image abilityIcon;
    public Image darkMask;
    public Text coolDownTextDisplay;

    public List<Ability> abilityList = new List<Ability>();

    [SerializeField] private Ability currentAbility;
    [SerializeField] private GameObject weaponHolder;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    private int abilitySlot = 0;

    void Start()
    {
        abilityList.TrimExcess();
        Initialize(abilityList[abilitySlot], weaponHolder);
    }

    public void Initialize(Ability selectedAbility, GameObject weaponHolder)
    {
        currentAbility = selectedAbility;
        abilityIcon.sprite = currentAbility.abilitySprite;
        darkMask.sprite = currentAbility.abilitySprite;
        coolDownDuration = currentAbility.abilityBaseCoolDown;
        currentAbility.InitializeAbility(weaponHolder);
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetButtonUp(abilityButtonAxisName))
            {
                ButtonTriggered();
            }
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)// scroll up
            {
                //Debug.Log(abilitySlot);
                abilitySlot++;
                if (abilitySlot >= abilityList.Count)
                    abilitySlot = 0;
                Initialize(abilityList[abilitySlot], gameObject);
            }
            else if (d < 0f) // scroll down
            {
                //Debug.Log(abilitySlot);
                abilitySlot--;
                if (abilitySlot < 0)
                    abilitySlot = abilityList.Count - 1;
                Initialize(abilityList[abilitySlot], gameObject);
            }
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;
        currentAbility.TriggerAbility();
    }
}
