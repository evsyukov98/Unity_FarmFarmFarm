using SaveServices;

namespace Template
{
    public class TemplateSave : IState
    {
        public int ID;
        public string Name;

        public TemplateSave(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
