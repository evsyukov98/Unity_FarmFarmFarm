using System.Collections.Generic;

namespace SaveServices
{
    public interface ISaveProvider
    {
        Dictionary<int, IState> LoadSave();
        void SaveSaves(Dictionary<int, IState> saves);
        void RemoveSaves();
    }
}
