using Zenject;
using UnityEngine;
using UnityEngine.UI;

namespace Template
{
    /// <summary>
    /// Тестовый класс для проверки функциональностей 
    /// <summary>
    public class TemplateButtonController : MonoBehaviour
    {
        private ITemplateManager _templateManager;

        [Inject]
        public void Inject(ITemplateManager templateManager)
        {
            _templateManager = templateManager;
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);

            _templateManager.ConsoleWrite("DI check message");
        }

        private void OnButtonClick()
        {
            _templateManager.CheckSave();
            _templateManager.ChangeSaveString("Changed save name");
        }
    }
}
