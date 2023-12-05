using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.UI.Button;

public class SkillSelector : MonoBehaviour
{
    [SerializeField] public GameObject SkillCard;

    [SerializeField] public GameObject[] SkillImages;
    private string[] skillIds = new string[] { "Dash", "Explosion", "Fireball", "Heal", "KnifeToss", "Lai", "Rage", "Stomp", "SwordSlash", "VampireSlash" };
    private List<string> chosenSkills = new List<string>();
    private Dictionary<string, string> descriptions = new Dictionary<string, string>()
    {
        { "Dash", "Speed up player" },
        { "Explosion", "Creates fire around player" },
        { "Fireball", "Deals enemy damage" },
        { "Heal", "Restore 10 HP" },
        { "KnifeToss", "Deals enemy damage" },
        { "Lai", "Fast movement with damage" },
        { "Rage", "Boost stats" },
        { "Stomp", "Hit from jump" },
        { "SwordSlash", "More demage from sward attack" },
        { "VampireSlash", "Heal from damage" }
    };
    private Dictionary<string, string> skillNames = new Dictionary<string, string>()
    {
        { "Dash", "Dash" },
        { "Explosion", "Explosion" },
        { "Fireball", "Fireball" },
        { "Heal", "Heal" },
        { "KnifeToss", "Knife toss" },
        { "Lai", "Lai" },
        { "Rage", "Rage" },
        { "Stomp", "Stomp" },
        { "SwordSlash", "Sword slash" },
        { "VampireSlash", "Vampire slash" }
    };
    private GameObject SkillGrid;
    // Start is called before the first frame update
    void Start()
    {
        SkillGrid = GameObject.Find("SkillGrid");
        for (int i = 0; i < skillIds.Length; i++)
        {
            GameObject toggle = Instantiate(SkillCard);
            toggle.transform.SetParent(SkillGrid.transform);
            toggle.name = skillIds[i];
            Sprite skillImage = Resources.Load<Sprite>("UI/Skills/" + skillIds[i]);
            toggle.transform.Find("SkillImage").GetComponent<Image>().sprite = skillImage;
            toggle.transform.Find("SkillImage").Find("SkillNameText").GetComponent<TextMeshProUGUI>().text = skillNames[skillIds[i]];
            toggle.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = descriptions[skillIds[i]];
            toggle.GetComponent<Toggle>().onValueChanged.AddListener(delegate
            {
                ToggleChange(toggle.GetComponent<Toggle>());
            });
        }
        SkillCard.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleChange(Toggle change)
    {
        string toggleName = change.name;

        if (chosenSkills.Contains(toggleName))
        {
            chosenSkills.Remove(toggleName);
            if (chosenSkills.Count == chosenSkills.Count - 1)
            {

                Toggle[] toggles = GetComponentsInChildren<Toggle>();
                foreach (Toggle toggle in toggles)
                {
                    toggle.interactable = true;
                }
                Selectable button = transform.Find("Start Game").GetComponent<Selectable>();
                button.interactable = false;
            }
        }
        else
        {
            chosenSkills.Add(toggleName);
        }

        if (chosenSkills.Count == chosenSkills.Count)
        {

            Toggle[] toggles = GetComponentsInChildren<Toggle>();
            foreach (Toggle toggle in toggles)
            {
                if (!chosenSkills.Contains(toggle.name))
                    toggle.interactable = false;
            }
            Selectable button = transform.Find("Start Game").GetComponent<Selectable>();
            button.interactable = true;
        }
    }
    public void ApplySkills()
    {
        for (int i = 0; i < chosenSkills.Count; i++)
        {
            SkillImages[i].transform.Find(chosenSkills[i]).gameObject.SetActive(true);
        }

    }
}
