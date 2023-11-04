public interface IToilet
{
    bool IsUsable { get; }
    bool CanFlush { get; }
    bool NeedsCleaning { get; }
    bool IsClogged { get; }
    bool IsBroken { get; }

    void Use();
    void Flush();
    void Clean();
    void Unclog();
    void Repair();
}