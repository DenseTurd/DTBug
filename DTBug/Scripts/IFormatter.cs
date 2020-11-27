using UnityEngine;
public interface IFormatter 
{
    void Init();
    string Format(LogType type, string line);
}
