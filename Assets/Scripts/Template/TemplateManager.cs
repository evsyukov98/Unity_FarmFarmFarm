using SaveServices;
using UnityEngine;

namespace Template
{
    public interface ITemplateManager
    {
        void ConsoleWrite(string message);
        void CheckSave();
        void ChangeSaveString(string name);
    }

    public class TemplateManager : StateManager<TemplateSave>, ITemplateManager
    {
        public void ConsoleWrite(string message)
        {
            Debug.Log(message);
        }

        public void ChangeSaveString(string name)
        {
            State.Name = name;
            State.ID++;
            Save();
        }

        public void CheckSave()
        {
            Debug.Log(State.Name + ", new ID:" + State.ID);
        }

        protected override void CreateNewState()
        {
            State = new TemplateSave(456, "Start save name");
        }
    }
}
