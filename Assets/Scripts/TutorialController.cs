using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject DialogPage;
    [SerializeField] private Text tname;
    [SerializeField] private Text texts;

    private bool showPage;
    private bool isInTutorial;
    private int part;
    private string inDialogName = "Обучение";

    // Start is called before the first frame update
    void Start()
    {
        string pathPlayer = Application.persistentDataPath + "/saveplayer.scrfc";
        isInTutorial = !File.Exists(pathPlayer);
        showPage = false;
        part = 0;
        if (isInTutorial)
            Debug.Log("Tutorial started");
        else
            Debug.Log("Tutorial skipped");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTutorial)
        {
            switch (part)
            {
                case 0:
                    if (!showPage)
                    {
                        DialogPage.SetActive(true);
                        tname.text = inDialogName;
                        texts.text = "Добро пожаловать в Sacrificio.\n Кратко пробежимся по упралению. Для перемещения используйте клавиши W,A,S,D на вашей клавиатуре!";
                        showPage = true;
                        Debug.Log("Tutorial part movement");
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                        {
                            showPage = false;
                            part++;
                        }
                    }
                    break;
                case 1:
                    if (!showPage)
                    {
                        DialogPage.SetActive(true);
                        tname.text = inDialogName;
                        texts.text = "Что бы поговорить с НПС надо нажать клавишу E (английскую)";
                        showPage = true;
                        Debug.Log("Tutorial part talking");
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            showPage = false;
                            part++;
                        }
                    }
                    break;
                case 2:
                    if (!showPage)
                    {
                        DialogPage.SetActive(true);
                        tname.text = inDialogName;
                        texts.text = "Что бы атаковать врага нажмите левую кнопку мыши";
                        showPage = true;
                        Debug.Log("Tutorial part attack");
                    }
                    else
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            showPage = false;
                            part++;
                        }
                    }
                    break;
                case 3:
                    if (!showPage)
                    {
                        DialogPage.SetActive(true);
                        tname.text = inDialogName;
                        texts.text = "Что бы восстановить здоровье нужно подойти к сердечку.\n Давайте попробуем!";
                        showPage = true;
                        Debug.Log("Tutorial part health");
                    }
                    else
                    {
                        if (FindObjectOfType<HealthManager>().CurrentHealth == FindObjectOfType<HealthManager>().MaxHealth)
                        {
                            showPage = false;
                            part++;
                        }
                    }
                    break;
                case 4:
                    if (!showPage)
                    {
                        DialogPage.SetActive(true);
                        tname.text = inDialogName;
                        texts.text = "Теперь вы полностью готовы к приключению. Дорогу осилит идущий. Удачи!";
                        showPage = true;
                        Debug.Log("Tutorial part final");
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                        {
                            DialogPage.SetActive(false);
                        }
                    }
                    break;
            }
        }
    }
}
